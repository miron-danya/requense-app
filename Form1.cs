using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppForRequence
{
    
    public partial class LOGIN : Form
    {
        string sqlConnection = @"Data Source=MIRONPC;Initial Catalog=AppForRescues;Integrated Security=True";

        public LOGIN()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();


            var loginUser = txt_login.Text;
            var passUser = txt_pass.Text;
            var loginWorker = txt_login.Text;
            var passWorker = txt_pass.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select username, password from Login where username = '{loginUser}' and password = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, connection);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable table2 = new DataTable();

            string querystring2 = $"select username, password from LoginForWorkers where username = '{loginWorker}' and password = '{passWorker}'";
            SqlCommand command2 = new SqlCommand(querystring2, connection);

            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен успешно");
                MENU menu = new MENU(loginUser);
                this.Hide();
                menu.ShowDialog();

            }
            if (table2.Rows.Count == 1)
            {
                MessageBox.Show("Вход выполнен успешно");
                MenuForWorkers menu2 = new MenuForWorkers();
                this.Hide();
                menu2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Данные некорректны");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}