using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SensingSimulation
{
    public partial class ApplianceDialog : Form
    {

        Appliance theappliance;
        Timer updateTimer;
        string nodename;
        string filename;
        DateTime lastwrite;
        
        public ApplianceDialog(string node_name)//Appliance a)
        {
            InitializeComponent();
            updateTimer = new Timer();
            updateTimer.Tick += new EventHandler(updateTimer_Tick);
            updateTimer.Interval = 500;

            nodename = node_name;
            filename = Utilities.Helper.displayFolder + node_name + ".txt";
            lastwrite = DateTime.MinValue;
            updateText();
            updateTimer.Start();
        }

        void updateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Stop();
            updateText();
            updateTimer.Start();

        }

        void updateText()
        {
            //return;
            if (File.GetLastWriteTime(filename) > lastwrite)
            {
                this.Text = nodename + ": " + File.GetLastWriteTime(filename).ToLongTimeString();
                //MessageBox.Show("Updating required!");
                try
                {
                    TextReader rdr = File.OpenText(filename);
                    this.textBoxNodeProperties.Text = rdr.ReadToEnd();
                    lastwrite = File.GetLastWriteTime(filename);
                    rdr.Close();
                }
                catch (Exception e)
                {
                    this.textBoxNodeProperties.Text = "Cannot read data: " + filename;
                }
            }




        }



    }
}
