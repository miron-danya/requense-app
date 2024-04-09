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
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.Internals;
using GMap.NET.MapProviders;
using GMap.NET.ObjectModel;
using GMap.NET.Projections;
using AppForRequence;

namespace AppForRequence
{


    public partial class MenuForWorkers : Form
    {
        string sqlConnection = @"Data Source=MIRONPC;Initial Catalog=AppForRescues;Integrated Security=True";


        public MenuForWorkers()
        {
            InitializeComponent();
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MenuForWorkers_Load_1(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            {
                string query = $"select id, name, username, phoneUser, mail, dataUser from Login";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            
            
            dataGridView1.Columns.Add(new DataGridViewButtonColumn() { Name = "Column_marshrut", HeaderText = "К маршруту", Width = 50 });

            dataGridView1.CellFormatting += DataGridView_CellFormatting;


            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.Show();


        }
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.Value is DateTime && dataGridView.Columns[e.ColumnIndex].Name == "dataUser")
            {
                DateTime cellDate = (DateTime)e.Value;

                if (cellDate < DateTime.Now.AddHours(-24))
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.Black;                   
                }
                else if (cellDate < DateTime.Now.AddHours(-8))
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }

            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Column_marshrut"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                var rowData = selectedRow.Cells["username"].Value.ToString(); 
                this.Hide();
                Marshrut marshrut = new Marshrut(rowData);
                marshrut.Show();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LOGIN lgn1 = new LOGIN();
            this.Hide();
            lgn1.ShowDialog();
        }
    }
}
