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
    public partial class PresentationDialog : Form
    {
        public PresentationDialog()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + "presentation.txt");
            wtr.WriteLine(this.comboBox1.SelectedItem);
            wtr.WriteLine(this.comboBox3.SelectedItem);
            wtr.WriteLine(this.ObtainGradientsCheckBox.Checked);
            wtr.WriteLine(this.obtainCostCheckBox.Checked);
            wtr.WriteLine(this.bestObtainGradientCheckBox.Checked);
            wtr.WriteLine(this.reinforceObtainCheckBox.Checked);
            wtr.WriteLine(this.deliverGradientsCheckBox.Checked);
            wtr.WriteLine(this.deliveryCostCheckBox.Checked);
            wtr.WriteLine(this.bestDeliverGradientCheckBox.Checked);
            wtr.WriteLine(this.ReinforceDeliveryCheckBox.Checked);
            wtr.WriteLine(this.nodeValueCheckBox.Checked);
            wtr.Close();
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
