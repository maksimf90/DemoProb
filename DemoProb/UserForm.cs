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
using Npgsql;

namespace DemoProb
{
    public partial class UserForm : Form
    {
        
        public UserForm()
        {
            InitializeComponent();
        
        }

 

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=11111;Database=DemoProb";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO users (fio, birth_date, gender) VALUES (@fio, @birth_date, @gender)";
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fio", txtFIO.Text);
                    command.Parameters.AddWithValue("@birth_date", dtpBirthDate.Value);
                    command.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data submitted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: " + ex.Message);
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
