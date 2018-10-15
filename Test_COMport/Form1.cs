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

namespace Test_COMport
{
    public partial class Form1 : Form
    {
        string message;
        public Form1()
        {

            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            
            comboBox1.DataSource = ports;
            serialPort1.Close();
            
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) { 
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 115200;
                serialPort1.Open();
             }
            else
            {
                btn_Close.Enabled = true;
                btn_Open.Enabled = false;
            }


        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                btn_Close.Enabled = false;
                btn_Open.Enabled = true;
            }
        }

        private void btn_SendData_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(textBox2.Text);
                
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            message = serialPort1.ReadExisting();
            Invoke(new EventHandler(ReadData));
        }

        private void ReadData(object sender, EventArgs e)
        {
           textBox1.Text = textBox1.Text + message + Environment.NewLine;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
