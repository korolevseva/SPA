using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.Common;
using System.Collections;
namespace WindowsFormsApplication1
{
  public partial class AddPers : Form
  {
    OleDbConnection myOleDbConnection;
    OleDbDataAdapter myDataAdapter;
    DataSet myDataSet;
    public OleDbConnection obj_connect = null;
    public AddPers()
    {
      
      InitializeComponent();
    }

    private void AddPers_Load(object sender, EventArgs e)
    {
        string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "data source=C:\\Users\\student\\Desktop\\WindowsFormsApplication1 - копия//SPA_for_VIP.accdb";//Properties.Resources1.DataSourceCUsersСеваDesktopSPA_for_VIPAccd;//"data source=C:\\Users\\Сева\\Desktop\\курсовая\\курсовая\\Мед_центр.mdb";
      //"data source=C:\\Users\\Сева\\Desktop\\SPA_for_VIP.accdb";"data source=C:\\Users\\Сева\\Desktop\\курсовая\\курсовая\\Мед_центр.mdb";
     // myOleDbConnection = new OleDbConnection(connectionString);

      myOleDbConnection = new OleDbConnection(connectionString);
      myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Сотрудники", myOleDbConnection);
      myDataSet = new DataSet("Сотрудники");
      myDataAdapter.Fill(myDataSet, "Персонал");     
      myDataAdapter.SelectCommand.Connection.Close();

      //this.dataGridView6.DataSource = myDataSet.Tables[0].DefaultView;
      this.dataGridView2.DataSource = myDataSet.Tables["Персонал"].DefaultView;

      //this.dataGridView2.Columns["ID"].Visible = false;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      //string cmd = String.Format("INSERT INTO Сотрудники (ID,Фамилия,Имя,Отчество,Контакты)  VALUES ({0},'{1}','{2}''{3}','{4}')", textBox4.Text, textBox1.Text, textBox2.Text, textBox3.Text, maskedTextBox1.Text);
      string cmd = "INSERT INTO Сотрудники(ID,Фамилия,Имя,Отчество,Контакты)   VALUES (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + maskedTextBox1.Text + "' )";
      try
      {
        myDataAdapter.InsertCommand = new OleDbCommand(cmd, myOleDbConnection);

        myDataAdapter.InsertCommand.Connection.Open();
        myDataAdapter.InsertCommand.ExecuteNonQuery();
        myDataAdapter.InsertCommand.Connection.Close();

        myDataAdapter.SelectCommand = new OleDbCommand("Select * FROM Сотрудники", myOleDbConnection);
        myDataAdapter.SelectCommand.Connection.Open();
        myDataAdapter.SelectCommand.ExecuteNonQuery();
        myDataAdapter.SelectCommand.Connection.Close();
        textBox1.Clear();
        textBox2.Clear();
        textBox3.Clear();

        myDataSet.Tables["Персонал"].Clear();
        myDataAdapter.Fill(myDataSet, "Персонал");
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        obj_connect = null;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      myDataAdapter.DeleteCommand = new OleDbCommand("DELETE FROM Сотрудники WHERE ID=" + dataGridView2.SelectedRows[0].Cells[0].Value, myOleDbConnection);

      myDataAdapter.DeleteCommand.Connection.Open();
      myDataAdapter.DeleteCommand.ExecuteNonQuery();
      MessageBox.Show(myDataAdapter.DeleteCommand.CommandText);
      myDataAdapter.DeleteCommand.Connection.Close();

      myDataAdapter.SelectCommand = new OleDbCommand("Select * FROM Сотрудники", myOleDbConnection);
      myDataAdapter.SelectCommand.Connection.Open();
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.SelectCommand.Connection.Close();

      myDataSet.Tables["Персонал"].Clear();
      myDataAdapter.Fill(myDataSet, "Персонал");
    }
  }
}
