using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SensingSimulation.Commands
{
    class SetNodeCommand : SimulationCommand
    {
        public SetNodeCommand()
        {
        }

        public override void execute()
        {
            string line = rdr.ReadLine();
            IncrementLineNumber();
            if ( !Nodes.Instance.ContainsKey(line) )
            {
                Nodes.Instance.Add(line, new Appliance(currentForm, new Point(0, 0), line));
            }
            currentNode = Nodes.Instance[line];
            //currentForm.mDiagram.AddNode(currentNode.applButton.eNode);
        }


    }
}
