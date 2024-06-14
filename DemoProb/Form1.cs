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
    public partial class LoginForm : Form
    {
        private NpgsqlConnection connection;
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=11111;Database=DemoProb";

        public LoginForm()
        {
            InitializeComponent();
            connection = new NpgsqlConnection(connectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=11111;Database=DemoProb";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT role FROM role WHERE username=@username AND password=@password";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@password", txtPassword.Text);
                var role = command.ExecuteScalar();

                if (role != null)
                {
                    if (role.ToString() == "admin")
                    {
                        AdminForm formAdmin = new AdminForm();
                        formAdmin.Show();
                    }
                    else if (role.ToString() == "user")
                    {
                        UserForm formUser = new UserForm();
                        formUser.Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
        }

      

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            RegisterForm formRegister = new RegisterForm();
            formRegister.Show();
        }
    }
}
