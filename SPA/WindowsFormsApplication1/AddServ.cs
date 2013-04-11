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
    public partial class AddServ : Form
    {
        OleDbConnection myOleDbConnection;
        OleDbDataAdapter myDataAdapter;
        DataSet myDataSet;
        public OleDbConnection obj_connect = null;
        public AddServ()
        {
            InitializeComponent();
        }

        private void AddServ_Load(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.ACE.OLEDB.12.0;" + "data source=C:\\Users\\student\\Desktop\\WindowsFormsApplication1 - копия\\SPA_for_VIP.accdb";//Properties.Resources1.DataSourceCUsersСеваDesktopSPA_for_VIPAccd;//"data source=C:\\Users\\Сева\\Desktop\\курсовая\\курсовая\\Мед_центр.mdb";
            myOleDbConnection = new OleDbConnection(connectionString);
            myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Услуги", myOleDbConnection);
            myDataSet = new DataSet("Услуги");
            myDataAdapter.Fill(myDataSet, "Услуги");
            myDataAdapter.SelectCommand.Connection.Close();
            this.dataGridView2.DataSource = myDataSet.Tables["Услуги"].DefaultView;
            //myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM SPA", myOleDbConnection);
            //myDataAdapter.SelectCommand.ExecuteNonQuery();
            //myDataAdapter.Fill(myDataSet, "SPA");
            //myDataAdapter.SelectCommand.Connection.Close();

            //myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM SPA", myOleDbConnection);
            //myDataAdapter.SelectCommand.ExecuteNonQuery();
            //myDataAdapter.Fill(myDataSet, "SPA");
            //myDataAdapter.SelectCommand.Connection.Close();
            //myOleDbConnection = new OleDbConnection(connectionString);
            myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM SPA", myOleDbConnection);
            myDataSet = new DataSet("SPA");
            myDataAdapter.Fill(myDataSet, "SPA");
            myDataAdapter.SelectCommand.Connection.Close();

           
            this.dataGridView1.DataSource = myDataSet.Tables["SPA"].DefaultView;

        }
    }
}
