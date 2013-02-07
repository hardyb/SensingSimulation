using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace SensingSimulation
{
    public class States : HashSet<string>
    {
        private static States instance;

        private States() 
        { 
        }

        public static States Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new States();
                }
                return instance;
            }
        }




    }
}
