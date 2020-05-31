using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ARC2019
{
    public partial class MOISTURE : Form
    {
        private SerialPort myport;
        private DateTime datetime;
        private string in_data;

        public object SeriesChartType { get; private set; }

        //Dim aw As String
        //  aw= 300
        // Chart1.Series("Moisture").Points.addY(aw)
        // Chart1.Series("Moisture").IsValueShownAsLabel = false
        // Chart1.ChartAreas("Moisture").AxisX.Enabled = DataVisualization.Charting.AxisEnabled.False


        public MOISTURE()
        {
            InitializeComponent();
        }

        private void start_btn_click(object sender, EventArgs e)
        {
            myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = port_name_tb.Text;
            myport.Parity = Parity.None;
            myport.DataBits = 8;
            myport.StopBits = StopBits.One;
            myport.DataReceived += Myport_DataReceived;

            


            //this.chart1.Series["moisture"].Points.AddXY.("time","in_data");



            try {
                myport.Open();
                data_tb.Text = "";
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");

            }

        }

        private void Myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
            in_data = myport.ReadLine();

            this.Invoke(new EventHandler(displaydata_event));

            
          
        }

        private void displaydata_event(object sender, EventArgs e)
        {
           datetime = DateTime.Now;
            string time = datetime.Hour + ":" + datetime.Minute + ":" + datetime.Second;
            data_tb.AppendText ( time + "\t\t\t" + in_data + "\n");

            //int data_value = Convert.ToInt32(in_data);

            //value_pb.Value = data_value;

        }

        private void stop_btn_click(object sender, EventArgs e)
        {
            try
            {
                myport.Close();
            }

            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message, "Error");
            }
        }

        private void save_btn_click(object sender, EventArgs e)
        {
            try
            {
                string pathfile = @"C:\Users\Mobusshar islam\Desktop\DATA\";
                string filename = "Moisture_data.txt";
                System.IO.File.WriteAllText(pathfile + filename, data_tb.Text);
                MessageBox.Show("Data has been stored to" + pathfile, "Save File");
            }
            catch (Exception ex3)
            {
                MessageBox.Show(ex3.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 main = new Form1();
            main.Show();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void MOISTURE_Load(object sender, EventArgs e)
        {

        }
    }
    }
