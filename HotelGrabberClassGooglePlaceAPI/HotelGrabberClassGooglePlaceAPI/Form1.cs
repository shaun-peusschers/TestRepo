using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelGrabberClassGooglePlaceAPI
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            Grabber gb = new Grabber(textBox1.Text);

            textBox3.Text = "";
            List<Hotel> Hotels = gb.searchHotels(textBox2.Text, textBox5.Text, 50000);
            textBox4.Text = gb.LastStatus+", Count : "+gb.LastAddressCount ;

            for (int i = 0; i < Hotels.Count; i++)
            {
                textBox3.Text = textBox3.Text + "Place Id : " + Hotels[i].Place_Id + "\r\n";
                textBox3.Text = textBox3.Text + "Name : " + Hotels[i].Name + "\r\n";
                textBox3.Text = textBox3.Text + "Address : " + Hotels[i].Address + "\r\n";
                textBox3.Text = textBox3.Text + "Latitude : " + Hotels[i].Location.Latitude + "\r\n";
                textBox3.Text = textBox3.Text + "Longitude : " + Hotels[i].Location.Longitude + "\r\n";
                textBox3.Text = textBox3.Text + "=============================================================\r\n";
            }

           



        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox5.AutoCompleteCustomSource = Grabber.AutoCompleteData ;
           
        }
    }
}
