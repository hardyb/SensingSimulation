using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace SensingSimulation
{
    class NodeConnection
    {
        public Appliance node1 = null;
        public Appliance node2 = null;
        Form1 currentForm = null;
        public string state;
        public string gradient;
        
        public NodeConnection(Form1 f, Appliance n1, Appliance n2, string state_name, string gradient_type)
        {
            node1 = n1;
            node2 = n2;
            currentForm = f;
            //f.Controls.Add(this);
            state = state_name;
            gradient = gradient_type;

        }

        
        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            

            Graphics gfx = e.Graphics;
            //Graphics gfx = this.CreateGraphics();
            //Graphics gfx = currentForm.CreateGraphics();
            //this.Crea
            Pen myPen = new Pen(Color.Black);
            this.Location = node1.applButton.Location;
            gfx.DrawLine(myPen, new Point(0,0), node2.applButton.Location);



        }
         * */


    }
}
