using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
  public partial class AddCl : Form
  {
    OleDbConnection myOleDbConnection;
    OleDbDataAdapter myDataAdapter;
    DataSet myDataSet;
    public OleDbConnection obj_connect = null;
    public AddCl()
    {
      InitializeComponent();
    }

    private void AddCl_Load(object sender, EventArgs e)
    {
        string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "data source=C:\\Users\\student\\Desktop\\WindowsFormsApplication1 - копия//SPA_for_VIP.accdb";//Properties.Resources1.DataSourceCUsersСеваDesktopSPA_for_VIPAccd;//"data source=C:\\Users\\Сева\\Desktop\\курсовая\\курсовая\\Мед_центр.mdb";
      
      myOleDbConnection = new OleDbConnection(connectionString);              
      myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Клиенты", myOleDbConnection);
      myDataSet = new DataSet("Клиенты");
      myDataAdapter.Fill(myDataSet, "Клиенты");
      myDataAdapter.SelectCommand.Connection.Close();
      
      this.dataGridView2.DataSource = myDataSet.Tables["Клиенты"].DefaultView;

      
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string cmd = "INSERT INTO Клиенты(ID_клиента,Фамилия,Имя,Отчество,Контакты)   VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + maskedTextBox1.Text + "' )";
        try
        {
            myDataAdapter.InsertCommand = new OleDbCommand(cmd, myOleDbConnection);

            myDataAdapter.InsertCommand.Connection.Open();
            myDataAdapter.InsertCommand.ExecuteNonQuery();
            myDataAdapter.InsertCommand.Connection.Close();

            myDataAdapter.SelectCommand = new OleDbCommand("Select * FROM Клиенты", myOleDbConnection);
            myDataAdapter.SelectCommand.Connection.Open();
            myDataAdapter.SelectCommand.ExecuteNonQuery();
            myDataAdapter.SelectCommand.Connection.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            myDataSet.Tables["Клиенты"].Clear();
            myDataAdapter.Fill(myDataSet, "Клиенты");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            obj_connect = null;
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        myDataAdapter.DeleteCommand = new OleDbCommand("DELETE FROM Клиенты WHERE ID_клиента=" + dataGridView2.SelectedRows[0].Cells[0].Value, myOleDbConnection);

        myDataAdapter.DeleteCommand.Connection.Open();
        myDataAdapter.DeleteCommand.ExecuteNonQuery();
        MessageBox.Show(myDataAdapter.DeleteCommand.CommandText);
        myDataAdapter.DeleteCommand.Connection.Close();

        myDataAdapter.SelectCommand = new OleDbCommand("Select * FROM Клиенты", myOleDbConnection);
        myDataAdapter.SelectCommand.Connection.Open();
        myDataAdapter.SelectCommand.ExecuteNonQuery();
        myDataAdapter.SelectCommand.Connection.Close();
        textBox1.Clear();
        textBox2.Clear();
        textBox3.Clear();

        myDataSet.Tables["Клиенты"].Clear();
        myDataAdapter.Fill(myDataSet, "Клиенты");
    }
  }
}
