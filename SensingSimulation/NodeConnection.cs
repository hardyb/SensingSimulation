using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace SensingSimulation
{
    public class NodeConnection
    {
        Form1 currentForm = null;
        public Appliance node1 = null;
        public Appliance node2 = null;
        public string state;

        public int action;
        public bool to_node_up;
        public int costToDeliver;
        public int costToObtain;
        public bool bestDeliver;
        public bool reinforcedDeliver;
        public bool bestObtain;
        public bool reinforcedObtain;



        
        public NodeConnection(Form1 f, Appliance n1, Appliance n2, string state_name,
            int _action, bool _to_node_up, int _costToDeliver, int _costToObtain,
            bool _bestDeliver, bool _reinforcedDeliver, bool _bestObtain, bool _reinforcedObtain)
        {
            currentForm = f;
            node1 = n1;
            node2 = n2;
            state = state_name;

            action = _action;
            to_node_up = _to_node_up;
            costToDeliver = _costToDeliver;
            costToObtain = _costToObtain;
            bestDeliver = _bestDeliver;
            reinforcedDeliver = _reinforcedDeliver;
            bestObtain = _bestObtain;
            reinforcedObtain = _reinforcedObtain;
        }

        public bool MatchesProfile(NodeConnection cp)
        {
            //if ( node2 != cp.node2 )
            //    return fale;
            if ( state != cp.state && cp.state != null )
                return false;
            if (bestDeliver != cp.bestDeliver && cp.bestDeliver != null)
                return false;
            if (reinforcedDeliver != cp.reinforcedDeliver && cp.bestDeliver != null)
                return false;
            if (bestObtain != cp.bestObtain && cp.bestDeliver != null)
                return false;
            if (reinforcedObtain != cp.reinforcedObtain && cp.bestDeliver != null)
                return false;

            //bool c = null;



            

            return true;


            //int action;
            //bool to_node_up;
            //int costToDeliver;
            //int costToObtain;



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
