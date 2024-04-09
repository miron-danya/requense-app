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
    public partial class Marshrut : Form
    {
        string sqlConnection = @"Data Source=MIRONPC;Initial Catalog=AppForRescues;Integrated Security=True";
        string rowData;
        private GMapOverlay routesOverlay;
        private GMapMarker markerFrom;
        private GMapMarker markerTo;
        private GMapRoute route;
        public Marshrut(string login)
        {
            InitializeComponent();
            rowData = login;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Position = new PointLatLng(55.7558, 37.6176);
            gMapControl1.ShowCenter = false;
            routesOverlay = new GMapOverlay("routes");
            gMapControl1.Overlays.Add(routesOverlay);

        }

        private void loginUser_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Marshrut_Load(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();
 
            string querystring = $"select name, mail, username, phoneUser, cityUser, birthUser, bloodUser, illnessUser, peopleUser, planUser, styleUser, durationUser, latUser, lngUser, lat2User, lng2User, dataUser, partyUser from Login where username = '{rowData}'";
            SqlCommand command = new SqlCommand(querystring, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) // если есть данные
            {
                reader.Read();
                fioUser_txt.Text = reader.GetString(0);
                mailUser_txt.Text = reader.GetString(1);
                usernameUser_txt.Text = reader.GetString(2);
                phoneUser_txt.Text = reader.IsDBNull(3) ? null : reader.GetString(3);
                cityUser_txt.Text = reader.IsDBNull(4) ? null : reader.GetString(4);
                birthUser_txt.Text = reader.IsDBNull(5) ? null : reader.GetString(5);
                bloodUser_txt.Text = reader.IsDBNull(6) ? null : reader.GetString(6);
                illnessUser_txt.Text = reader.IsDBNull(7) ? null : reader.GetString(7);
                peopleUser_txt.Text = reader.IsDBNull(8) ? null : reader.GetString(8);
                planUser_txt.Text = reader.IsDBNull(9) ? null : reader.GetString(9);
                styleUser_txt.Text = reader.IsDBNull(10) ? null : reader.GetString(10);
                durationUser_txt.Text = reader.IsDBNull(11) ? null : reader.GetString(11);
                latUser_txt.Text = reader.IsDBNull(12) ? null : reader.GetString(12);
               
                lngUser_txt.Text = reader.IsDBNull(13) ? null : reader.GetString(13);
                
                lat2User_txt.Text = reader.IsDBNull(14) ? null : reader.GetString(14);
                
                lng2User_txt.Text = reader.IsDBNull(15) ? null : reader.GetString(15);
                

                dataUser_txt.Value = reader.GetDateTime(16);
                partyUser_txt.Text = reader.IsDBNull(17) ? null : reader.GetString(17);
            }

            reader.Close();




        }

        private void planUser_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            using SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();

            string querystring = $"select latUser, lngUser from Login where username = '{rowData}'";
            SqlCommand command = new SqlCommand(querystring, connection);
            SqlDataReader reader = command.ExecuteReader();
            double lat1 = 0;
            double lon1 = 0;

            if (reader.Read())
            {
                lat1 = Convert.ToDouble(reader["latUser"]);
                lon1 = Convert.ToDouble(reader["lngUser"]);
            }

            reader.Close();
            command.CommandText = $"select lat2User, lng2User from Login where username = '{rowData}'";
            reader = command.ExecuteReader();

            double lat2 = 0;
            double lon2 = 0;

            if (reader.Read())
            {
                lat2 = Convert.ToDouble(reader["lat2User"]);
                lon2 = Convert.ToDouble(reader["lng2User"]);
            }
            reader.Close();

           



            gMapControl1.Position = new GMap.NET.PointLatLng(lat1, lon1);
            gMapControl1.Bearing = 0;
            gMapControl1.CanDragMap = true;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.GrayScaleMode = true;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 18;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Zoom = 8;


            PointLatLng point1 = new PointLatLng(lat1, lon1);
            PointLatLng point2 = new PointLatLng(lat2, lon2);

            markerFrom = new GMarkerGoogle(point1, GMarkerGoogleType.green);
            markerTo = new GMarkerGoogle(point2, GMarkerGoogleType.red);
            routesOverlay.Markers.Add(markerFrom);
            routesOverlay.Markers.Add(markerTo);
            route = new GMapRoute(new List<PointLatLng> { point1, point2 }, "Маршрут");
            route.Stroke = new Pen(System.Drawing.Color.Blue, 3);
            routesOverlay.Routes.Add(route);

            
            gMapControl1.ZoomAndCenterMarkers("markers");

            



           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuForWorkers menu2 = new MenuForWorkers();
            this.Hide();
            menu2.ShowDialog();
        }

        private void label17_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN lgn1 = new LOGIN();
            this.Hide();
            lgn1.ShowDialog();
        }
    }
        


    
}
