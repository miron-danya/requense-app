using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppForRequence
{
    
    public partial class Registration : Form
    {
        string sqlConnection = @"Data Source=MIRONPC;Initial Catalog=AppForRescues;Integrated Security=True";
        public Registration()
        {
            InitializeComponent();
        }
        
        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void txt_newfio_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();

            var loginUser = txt_newlogin.Text;
            var passUser = txt_newpass.Text;
            var fioUser = txt_newfio.Text;
            var mailUser = txt_newemail.Text;
            if (checkUser())

            {
                return;
            }

            string querystring = $"insert into Login (username, password, name, mail) values ('{loginUser}','{passUser}','{fioUser}','{mailUser}')";
            SqlCommand command = new SqlCommand(querystring, connection);


           
            
                
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация выполнена успешно");
                LOGIN lgn1 = new LOGIN();
                this.Hide();
                lgn1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Данные некорректны");
            }
               
            
        }

        private Boolean checkUser()
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();
            var loginUser = txt_newlogin.Text;
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select username from Login where username = '{loginUser}' UNION select username from LoginForWorkers where username = '{loginUser}'";
            SqlCommand command = new SqlCommand(querystring, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким именем уже существует");
                return true;
            }
            else
            {
                return false;
            }




        }

    }
}
