using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SensingSimulation
{
    public class Sensor
    {
        public Button applButton;
        private Point mouseDownLocation = Point.Empty;
        private Form theForm;

        public int temp;
        public int light;
        public bool presence;

        class sensordata
        {
            public int sensortype;
            public int sensorvalue;
            public int sensorrange;
            public bool lineofsight;
            public int readingtime;
        }



        public Sensor(Form f, Point position)
        {
            theForm = f;
            applButton = new ApplianceButton(position);
            applButton.Text = "S";
            applButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseMove);
            applButton.Click += new System.EventHandler(this.ButtonClick);
            //applButton.DragDrop += new System.Windows.Forms.DragEventHandler(this.Appliance1_DragDrop);
            applButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            //applButton.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Appliance1_GiveFeedback);
            theForm.Controls.Add(applButton);

        }


        public void editData()
        {
            Form2 f2 = new Form2(this);
            f2.ShowDialog();
            

        }

        private void ButtonClick(object sender, EventArgs e)
        {
            editData();
        }

        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = new Point(e.X, e.Y);

        }

        private void ButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // we know the mouse is down - has it the mouse moved enough that we should
                // consider it a drag?
                Size dragBoxSize = SystemInformation.DragSize;

                if ((dragBoxSize.Width > Math.Abs(mouseDownLocation.X - e.X))
                    || (dragBoxSize.Height > Math.Abs(mouseDownLocation.Y - e.Y)))
                {
                    // we should consider this a drag...
                    DragDropEffects d = this.applButton.DoDragDrop(applButton, DragDropEffects.All);
                    //Sensor s = new Sensor();
                    //DragDropEffects d = Appliance1.DoDragDrop(s, DragDropEffects.Copy);
                    //this.toolStripStatusLabel.Text = d.ToString();

                }
            }
        }


    }
}
