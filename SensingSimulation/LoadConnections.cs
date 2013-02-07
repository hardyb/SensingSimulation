using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SensingSimulation.Commands;


namespace SensingSimulation
{
    public partial class LoadConnections : Form
    {
        Form1 mainForm;
        public LoadConnections()
        {
            InitializeComponent();

        }
        
        public LoadConnections(Form1 _mainForm)
        {
            InitializeComponent();


            //dataNamesCmbBox.SelectedText = "0202FF06";
            //dataNamesCmbBox.SelectedItem = dataNamesCmbBox.Items.get
            mainForm = _mainForm;
            this.BestDeliverRButton.Select();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetConnectionCommand c = (SetConnectionCommand)SimCommands.Instance["CONNECTION"];
            c.DataNameParam = dataNamesCmbBox.SelectedItem as string;
            //c.DataNameParam = dataNamesCmbBox.SelectedText;
            //c.DataNameParam = (string)dataNamesCmbBox.SelectedValue;
            //dataNamesCmbBox.SelectedItem
            if ( this.BestDeliverRButton.Checked )
            {
                c.connectionSet = SetConnectionCommand.ConnectionSetType.BestDeliver;
            }
            if ( this.ReinforceDeliverRButton.Checked )
            {
                c.connectionSet = SetConnectionCommand.ConnectionSetType.ReinforceDeliver;
            }
            if ( this.BestObtainRButton.Checked )
            {
                c.connectionSet = SetConnectionCommand.ConnectionSetType.BestObtain;
            }
            if (this.ReinforceObtainRButton.Checked)
            {
                c.connectionSet = SetConnectionCommand.ConnectionSetType.ReinforceObtain;
            }
            if (this.radioButton1.Checked)
            {
                c.connectionSet = SetConnectionCommand.ConnectionSetType.Deliver;
            }

            mainForm.ReloadConnections();

        }

        private void BestDeliverRButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataNamesCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //c.DataNameParam = dataNamesCmbBox.SelectedItem;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.dataNamesCmbBox.Items.Clear();
            this.Hide();
        }

        private void LoadConnections_Shown(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                resetDataNamesCombo();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void resetDataNamesCombo()
        {
            this.dataNamesCmbBox.Items.Clear();
            foreach (string s in States.Instance)
            {
                this.dataNamesCmbBox.Items.Add(s);
            }
            this.dataNamesCmbBox.SelectedIndex = 0;

        }
    }
}
