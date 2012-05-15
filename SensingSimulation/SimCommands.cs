using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SensingSimulation.Commands;
using System.IO;

namespace SensingSimulation
{
    public class SimCommands : Dictionary<string, SimulationCommand>
    {
        private static SimCommands instance;

        private SimCommands() 
        {
            this["POSITION"] = new SetPositionCommand();
            this["IMAGE"] = new SetImageCommand();
            this["NODE"] = new SetNodeCommand();
            this["CONNECTION"] = new SetConnectionCommand();

        }

        public void execute(string filename, Form1 f)
        {
            TextReader rdr = SimulationCommand.SetFile(filename);
            SimulationCommand.SetForm(f);
            string line;
            while ((line = rdr.ReadLine()) != null)
            {
                SimulationCommand.IncrementLineNumber();
                this[line].execute();
            }
            rdr.Close();
        }


        public static SimCommands Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SimCommands();
                }
                return instance;
            }
        }
    }

}
