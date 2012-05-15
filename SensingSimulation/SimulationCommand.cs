using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SensingSimulation
{
    public class SimulationCommand
    {
        protected static Appliance currentNode = null;
        protected static TextReader rdr = null;
        protected static int lineNumber = 0;
        //protected static Form currentForm = null;
        protected static Form1 currentForm = null;


        public SimulationCommand()
        {
        }

        public static TextReader SetFile(string filename)
        {
            rdr = File.OpenText(filename);
            lineNumber = 0;
            return rdr;
        }

        public static void SetForm(Form1 f)
        {
            currentForm = f;
        }

        public static void IncrementLineNumber()
        {
            lineNumber++;
        }

        public virtual void execute()
        {
        }


    }
}
