using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SensingSimulation.Commands
{
    class SetImageCommand : SimulationCommand
    {
        public SetImageCommand()
        {
        }

        public override void execute()
        {
            string line = rdr.ReadLine();
            line.Replace("/", "\\");
            IncrementLineNumber();
            currentNode.applButton.SetBackground(line);
        }


    }
}
