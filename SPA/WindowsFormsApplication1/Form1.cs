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

using System.IO;

namespace WindowsFormsApplication1
{
 
  public partial class Form1 : Form
  {
    OleDbConnection myOleDbConnection;
    OleDbDataAdapter myDataAdapter;
    DataSet myDataSet;

    AddPers AddPers;
    AddCl AddCl;
    AddServ AddServ;
    public OleDbConnection obj_connect = null;

    public Form1()
    {
      InitializeComponent();
    }

    private void button12_Click(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
      string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "data source=C:\\Users\\student\\Desktop\\WindowsFormsApplication1 - копия\\SPA_for_VIP.accdb";//Properties.Resources1.DataSourceCUsersСеваDesktopSPA_for_VIPAccd;//"data source=C:\\Users\\Сева\\Desktop\\курсовая\\курсовая\\Мед_центр.mdb";
        
      myOleDbConnection = new OleDbConnection(connectionString);

      myOleDbConnection = new OleDbConnection(connectionString);
      myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Ингредиенты", myOleDbConnection);
      myDataSet = new DataSet("Ингредиенты");
      myDataAdapter.Fill(myDataSet, "Склад");

      myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Сотрудники", myOleDbConnection);
      myDataAdapter.SelectCommand.Connection.Open();
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "Персонал");

      myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Клиенты", myOleDbConnection);
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "Клиенты");

      myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Услуги", myOleDbConnection);
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "Услуги");

      myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM SPA", myOleDbConnection);
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "SPA");
      myDataAdapter.SelectCommand.Connection.Close();

      //this.dataGridView6.DataSource = myDataSet.Tables[0].DefaultView;
      this.dataGridView2.DataSource = myDataSet.Tables["Персонал"].DefaultView;
      this.dataGridView3.DataSource = myDataSet.Tables["Клиенты"].DefaultView;
      this.dataGridView4.DataSource = myDataSet.Tables["Услуги"].DefaultView;
      this.dataGridView5.DataSource = myDataSet.Tables["SPA"].DefaultView;
      this.dataGridView6.DataSource = myDataSet.Tables["Склад"].DefaultView;

      this.dataGridView2.Columns["ID"].Visible = false;
      this.dataGridView4.Columns["ID_услуги"].Visible = false;
      this.dataGridView6.Columns["ID_ингредиента"].Visible = false;
      
    }

    private void button1_Click(object sender, EventArgs e)
    {
      AddPers = new AddPers() { Owner = this };
      AddPers.ShowDialog();
      AddPers = new AddPers();    
    }

    private void button2_Click(object sender, EventArgs e)
    {
      AddCl = new AddCl() { Owner = this };
      AddCl.ShowDialog();
      AddCl = new AddCl();  
    }

    private void button3_Click(object sender, EventArgs e)
    {

        AddServ = new AddServ() { Owner = this };
        AddServ.ShowDialog();
        AddServ = new AddServ();  
    }
  }
}
