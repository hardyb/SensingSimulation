using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SensingSimulation
{
    public partial class Form2 : Form
    {
        Sensor thesensor;
        public Form2(Sensor s)
        {
            InitializeComponent();
            thesensor = s;
            this.tempScrollBar.Value = thesensor.temp;
            this.lightScrollBar.Value = thesensor.light;
            this.presenceCheckBox.Checked = thesensor.presence;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            thesensor.temp = this.tempScrollBar.Value;
            thesensor.light = this.lightScrollBar.Value;
            thesensor.presence = this.presenceCheckBox.Checked;
        }
    }
}
