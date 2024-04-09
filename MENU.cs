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

    public partial class MENU : Form
    {
        string sqlConnection = @"Data Source=MIRONPC;Initial Catalog=AppForRescues;Integrated Security=True";

        string loginUser2;
        
        private GMapOverlay markersOverlay;
        private GMapMarker markerFrom;
        private GMapMarker markerTo;
        private GMapRoute route;
        public MENU(string loginUser)
        {

            InitializeComponent();
            loginUser2 = loginUser;
           
        }

        private void MENU_Load(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void UserPage1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            gMapControl1.MinZoom = 2;
            gMapControl1.MaxZoom = 18;
            gMapControl1.Zoom = 6;
            gMapControl1.Position = new GMap.NET.PointLatLng(66.4169575018027, 94.25025752215694);
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.ShowCenter = false;
            gMapControl1.ShowTileGridLines = false;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.ShowCenter = false;

            markersOverlay = new GMapOverlay("markers");
            gMapControl1.Overlays.Add(markersOverlay);

        }
        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {

            PointLatLng point = gMapControl1.FromLocalToLatLng(e.X, e.Y);

            if (markerFrom == null)
            {
                markerFrom = new GMarkerGoogle(point, GMarkerGoogleType.green);
                markersOverlay.Markers.Add(markerFrom);
                latUser_txt.Text = point.Lat.ToString();
                lngUser_txt.Text = point.Lng.ToString();
            }
            else if (markerTo == null)
            {
                markerTo = new GMarkerGoogle(point, GMarkerGoogleType.red);
                markersOverlay.Markers.Add(markerTo);
                lat2User_txt.Text = point.Lat.ToString();
                lng2User_txt.Text = point.Lng.ToString();

                route = new GMapRoute(new List<PointLatLng> { markerFrom.Position, markerTo.Position }, "Route");
                GMapOverlay routesOverlay = new GMapOverlay("routes");
                routesOverlay.Routes.Add(route);
                gMapControl1.Overlays.Add(routesOverlay);

                gMapControl1.ZoomAndCenterMarkers("markers");
            }






        }
       
        public void coordinate1_TextChanged(object sender, EventArgs e)
        {


        }

        public void coordinate2_TextChanged(object sender, EventArgs e)
        {


        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();
            
            var planUser = planUser_txt.Text;
            var styleUser = styleUser_txt.Text;
            var dataUser = System.Convert.ChangeType(dataUser_txt.Value, typeof(System.DateTime));
            var durationUser = durationUser_txt.Text;
            var latUser = latUser_txt.Text;
            var lngUser = lngUser_txt.Text;
            var lat2User = lat2User_txt.Text;
            var lng2User = lng2User_txt.Text;
            var partyUser = partyUser_txt.Text;

            string querystring = $"update Login set planUser = '{planUser}', styleUser = '{styleUser}', dataUser = '{dataUser}', durationUser = '{durationUser}', latUser = '{latUser}' , lngUser = '{lngUser}',lat2User = '{lat2User}' , lng2User = '{lng2User}', partyUser = '{partyUser}', login2 = '{loginUser2}' where username = '{loginUser2}'";
            SqlCommand command = new SqlCommand(querystring, connection);



            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно отправлены");
                
            }



        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {




        }


        private void button2_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();
            var fio = fioUser_txt.Text;
            var username = loginUser_txt.Text;
            var pass = passUser_txt.Text;
            var mailUser = mailUser_txt.Text;
            var phoneUser = phoneUser_txt.Text;
            var cityUser = cityUser_txt.Text;
            var birthUser = birthUser_txt.Text;
            var ageUser = ageUser_txt.Text;
            var bloodUser = bloodUser_txt.Text;
            var illnessUser = illnessUser_txt.Text;
            var sizeUser = sizeUser_txt.Text;
            var peopleUser = peopleUser_txt.Text;

            string querystring = $"update Login set name = '{fio}', mail = '{mailUser}', username = '{username}', password = '{pass}', phoneUser = '{phoneUser}', cityUser = '{cityUser}', birthUser = '{birthUser}'  , ageUser = '{ageUser}', bloodUser = '{bloodUser}' , illnessUser = '{illnessUser}', sizeUser = '{sizeUser}', peopleUser = '{peopleUser}' where username = '{loginUser2}'";
            SqlCommand command = new SqlCommand(querystring, connection);


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Данные успешно отправлены");
                

            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }



        }

        private void phoneUser_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void account_click(object sender, MouseEventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();
            string querystring = $"select name, mail, username, password, phoneUser, cityUser, birthUser, ageUser, bloodUser, illnessUser, sizeUser, peopleUser, planUser, styleUser, dataUser, durationUser, latUser, lngUser, lat2User, lng2User, partyUser from Login where username = '{loginUser2}'";
            SqlCommand command = new SqlCommand(querystring, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                reader.Read();
                fioUser_txt.Text = reader.GetString(0);
                mailUser_txt.Text = reader.GetString(1);
                loginUser_txt.Text = reader.GetString(2);
                passUser_txt.Text = reader.GetString(3);
                phoneUser_txt.Text = reader.IsDBNull(4) ? null : reader.GetString(4);
                cityUser_txt.Text = reader.IsDBNull(5) ? null : reader.GetString(5);
                birthUser_txt.Text = reader.IsDBNull(6) ? null : reader.GetString(6);
                ageUser_txt.Text = reader.IsDBNull(7) ? null : reader.GetString(7);
                bloodUser_txt.Text = reader.IsDBNull(8) ? null : reader.GetString(8);
                illnessUser_txt.Text = reader.IsDBNull(9) ? null : reader.GetString(9);
                sizeUser_txt.Text = reader.IsDBNull(10) ? null : reader.GetString(10);
                peopleUser_txt.Text = reader.IsDBNull(11) ? null : reader.GetString(11);
                planUser_txt.Text = reader.IsDBNull(12) ? null : reader.GetString(12);
                styleUser_txt.Text = reader.IsDBNull(13) ? null : reader.GetString(13);
                durationUser_txt.Text = reader.IsDBNull(15) ? null : reader.GetString(15);
                latUser_txt.Text = reader.IsDBNull(16) ? null : reader.GetString(16);
                lngUser_txt.Text = reader.IsDBNull(17) ? null : reader.GetString(17);
                lat2User_txt.Text = reader.IsDBNull(18) ? null : reader.GetString(18);
                lng2User_txt.Text = reader.IsDBNull(19) ? null : reader.GetString(19);
                partyUser_txt.Text = reader.IsDBNull(20) ? null : reader.GetString(20);
                
            }

            reader.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();
            string querystring = $"update Login set planUser = '', styleUser = '', dataUser = ''  , durationUser = '', latUser = '' , lngUser = '', lat2User = '' , lng2User = '', partyUser = '', login2 = '{loginUser2}' where username = '{loginUser2}'";
            SqlCommand command = new SqlCommand(querystring, connection);
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Маршрут завершен");
                planUser_txt.Text = "";
                styleUser_txt.Text = "";
                dataUser_txt.Text = "";
                durationUser_txt.Text = "";
                latUser_txt.Text = "";
                lngUser_txt.Text = "";
                lat2User_txt.Text = "";
                lng2User_txt.Text = "";
                partyUser_txt.Text = "";


            }

        }

        private void dataUser_txt_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void lat2User_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuForWorkers menu2 = new MenuForWorkers();
            this.Hide();
            menu2.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LOGIN lgn1 = new LOGIN();
            this.Hide();
            lgn1.ShowDialog();
        }

        private void styleUser_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
