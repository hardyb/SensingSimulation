using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SensingSimulation
{
    class NodeConnections : ArrayList
    {
        private static NodeConnections instance;

        private NodeConnections() 
        { 
        }

        public static NodeConnections Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NodeConnections();
                }
                return instance;
            }
        }
    }


}
