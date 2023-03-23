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
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ImageDBTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //constructor have the CLASS NAME AND CALL ITSELF
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OD = new OpenFileDialog();

            OD.FileName = "";
            OD.Filter = "Supported Images|*.jpg;*.jpeg;*.png";
            if (OD.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(OD.FileName);
            }
        }

        //connection string
        string connectionString = "Data Source=ALEXLAPTOP;Initial Catalog = ImageDB; Integrated Security = True";


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command = con.CreateCommand();

            var image = new ImageConverter().ConvertTo(pictureBox1.Image, typeof(Byte[]));

            command.Parameters.AddWithValue("@image", image);

            command.CommandText = "INSERT INTO ImageTable (image) VALUES(@image)";

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Image was Saved at DB");

            } else
                MessageBox.Show("Image was NOT Saved at DB");

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
