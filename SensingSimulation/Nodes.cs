using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace SensingSimulation
{
    public class Nodes : Dictionary<string, Appliance>
    {
        private static Nodes instance;

        private Nodes() 
        { 
        }

        public static Nodes Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Nodes();
                }
                return instance;
            }
        }

        public void removeAllFromForm()
        {
            foreach (KeyValuePair<string, SensingSimulation.Appliance> p in this)
            {
                p.Value.removeFromForm();
            }


        }



    }
}
