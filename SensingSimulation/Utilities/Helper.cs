using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;



namespace SensingSimulation.Utilities
{
    public class Helper
    {
        public static string eventsFolder = "C:\\omnetpp-4.2.2\\my_workspace\\datacentric\\src\\events\\";
        public static string displayFolder = "C:\\omnetpp-4.2.2\\my_workspace\\datacentric\\src\\display\\";
        public static string moduleList = "C:\\omnetpp-4.2.2\\my_workspace\\datacentric\\simulations\\ModuleList.txt";
        public static string ProjFolder = "C:\\Users\\Andrew Hardy\\Documents\\Visual Studio 2008\\Projects\\SensingSimulation\\";
        public static string simulationsFolder = "C:\\omnetpp-4.2.2\\my_workspace\\datacentric\\simulations\\";
        //public static string simulationsFolder = "C:\\omnetpp-4.2.2\\my_workspace\\datacentric\\simulations\\newconnectionfiles\\";


        public static NodeConnection profile = new NodeConnection(null, null, null, "",
                int.Parse("3"), true, int.Parse("12"), int.Parse("9999"), 
                true, false, false, false);


        //NodeConnection c = new NodeConnection(currentForm, node1, node2, state_name,
        //    int.Parse(state_action), to_node_up, int.Parse(costDeliv), int.Parse(costObt),
        //    bestDeliver, reinforcedDeliver, bestObtain, reinforcedObtain);

            
        //public static string eventsFolder = "C:\\omnetpp-4.1\\Mywork4\\src\\events\\";
        //public static string displayFolder = "C:\\omnetpp-4.1\\Mywork4\\src\\display\\";
        //public static string moduleList = "C:\\omnetpp-4.1\\Mywork4\\src\\ModuleList.txt";
        //public static string ProjFolder = "C:\\Users\\Andrew Hardy\\Documents\\Visual Studio 2008\\Projects\\SensingSimulation\\";
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.Multiline = true;
            textBox.SetBounds(12, 36, 372, 520);
            //textBox.Height = 500;
            buttonOk.SetBounds(228, 572, 75, 23);
            buttonCancel.SetBounds(309, 572, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 607);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }


    }
}
