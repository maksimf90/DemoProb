using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProb
{
    public partial class AdminForm : Form
    {
       
        public AdminForm()
        {
            InitializeComponent();
            
        } 

        private void AdminForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=11111;Database=DemoProb";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM users";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
    
}

