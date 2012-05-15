using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SensingSimulation.Commands
{
    public class SetPositionCommand : SimulationCommand
    {
        public SetPositionCommand()
        {
        }

        public override void execute()
        {
            int x = int.Parse(rdr.ReadLine());
            IncrementLineNumber();
            int y = int.Parse(rdr.ReadLine());
            IncrementLineNumber();
            currentNode.applButton.Location = new Point((int)(x*2.5), (int)(y*2.5));

        }

    }
}
