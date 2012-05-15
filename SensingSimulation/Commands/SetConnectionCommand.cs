using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace SensingSimulation.Commands
{
    class SetConnectionCommand : SimulationCommand
    {
        public SetConnectionCommand()
        {
        }

        public override void execute()
        {
            string state_name = rdr.ReadLine();
            IncrementLineNumber();
            string node1_name = rdr.ReadLine();
            IncrementLineNumber();
            
            string gradient_type = rdr.ReadLine();
            IncrementLineNumber();
            string node2_name = rdr.ReadLine();
            IncrementLineNumber();
            string costDeliv = rdr.ReadLine();
            IncrementLineNumber();
            if (Nodes.Instance.ContainsKey(node1_name) &&
                 Nodes.Instance.ContainsKey(node2_name))
            {
                Appliance node1 = Nodes.Instance[node1_name];
                Appliance node2 = Nodes.Instance[node2_name];
                NodeConnections.Instance.Add(new NodeConnection(currentForm, node1, node2, state_name, gradient_type));
            }


            gradient_type = rdr.ReadLine();
            IncrementLineNumber();
            string node3_name = rdr.ReadLine();
            IncrementLineNumber();
            string costObt = rdr.ReadLine();
            IncrementLineNumber();
            if (Nodes.Instance.ContainsKey(node1_name) &&
                 Nodes.Instance.ContainsKey(node3_name))
            {
                Appliance node1 = Nodes.Instance[node1_name];
                Appliance node3 = Nodes.Instance[node3_name];
                NodeConnections.Instance.Add(new NodeConnection(currentForm, node1, node3, state_name, gradient_type));
            }






        }

    }


}
