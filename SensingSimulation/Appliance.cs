using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;


namespace SensingSimulation
{
    public class Appliance
    {
        public ApplianceButton applButton;
        private Point mouseDownLocation = Point.Empty;
        private Form1 theForm;
        private ArrayList sensorData;
        public readonly string node_name;

        public class SensorDataItem
        {
            public int sensortype;
            public int sensorvalue;
            public int sensorrange;
            public bool lineofsight;
            public int readingtime;
        }


        class service
        {
            public string name;

        }



        public Appliance(Form1 f, Point position, string _name)
        {
            node_name = _name;
            theForm = f;
            applButton = new ApplianceButton(position);
            this.applButton.node_name = _name;
            applButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            applButton.Click += new System.EventHandler(this.ButtonClick);
            //applButton.
            //applButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.Appliance1_DragDrop);
            applButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            //applButton.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);

            //applButton.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Appliance1_GiveFeedback);
            theForm.Controls.Add(applButton);

        }

        ~Appliance()
        {
            removeFromForm();
        }

        public void removeFromForm()
        {
            if (theForm.Controls.IndexOf(applButton) != -1)
            {
                theForm.Controls.Remove(applButton);
            }
        }





        public void getSensorData()
        {
            //sensorData = theForm.get
        }
        
        public void editData()
        {
            

        }

        private void ButtonClick(object sender, EventArgs e)
        {
        }

        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
            
            
            mouseDownLocation = new Point(e.X, e.Y);

        }

        private void ButtonMouseMove(object sender, MouseEventArgs e)
        {
            theForm.setToolStrip("MouseMove");
            if (e.Button == MouseButtons.Left)
            {
                // we know the mouse is down - has it the mouse moved enough that we should
                // consider it a drag?
                Size dragBoxSize = SystemInformation.DragSize;

                if ((dragBoxSize.Width > Math.Abs(mouseDownLocation.X - e.X))
                    || (dragBoxSize.Height > Math.Abs(mouseDownLocation.Y - e.Y)))
                {
                    // we should consider this a drag...
                    theForm.setToolStrip("START DRAG");
                    DragDropEffects d = this.applButton.DoDragDrop(applButton, DragDropEffects.All);
                    //Sensor s = new Sensor();
                    //DragDropEffects d = Appliance1.DoDragDrop(s, DragDropEffects.Copy);

                }
            }
        }

        private void ApplianceButton_rc(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("You selected: toolStripMenuItem1");


        }



    }
}
