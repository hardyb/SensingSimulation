using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;


namespace SensingSimulation.Commands
{
    class SetConnectionCommand : SimulationCommand
    {
        //string currentName = "AAA0000004C";
        public string DataNameParam;
        public enum ConnectionSetType { Deliver, BestDeliver, ReinforceDeliver, BestObtain, ReinforceObtain};
        public ConnectionSetType connectionSet = ConnectionSetType.BestDeliver;

        public SetConnectionCommand()
        {
        }

        public override void execute()
        {
            //execute1();
            execute2();
        }


        public void execute1()
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

                //currentForm.mDiagram.AddNode(node2.applButton.eNode);
                node2.applButton.eNode.AddChild(node1.applButton.eNode);
                //NodeConnections.Instance.Add(new NodeConnection(currentForm, node1, node2, state_name, gradient_type));

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
                //NodeConnections.Instance.Add(new NodeConnection(currentForm, node1, node3, state_name, gradient_type));
            }
        }



        public void execute2()
        {
            string from_node = rdr.ReadLine();
            IncrementLineNumber();
            
            string state_name = rdr.ReadLine();
            States.Instance.Add(state_name);

            int[] state_array = new int[20];
            //for (int i = 0;
            //    int.TryParse(state_name.Substring(i * 2, 2),
            //    System.Globalization.NumberStyles.HexNumber, null, out state_array[i]);
            //    i++) ;
            IncrementLineNumber();
            string state_action = rdr.ReadLine();
            IncrementLineNumber();
            string to_node = rdr.ReadLine();
            IncrementLineNumber();

            string dummySeqno = rdr.ReadLine(); // not in use just yet
            IncrementLineNumber();

            bool to_node_up;
            bool.TryParse(rdr.ReadLine(), out to_node_up);
            IncrementLineNumber();
            string costDeliv = rdr.ReadLine();
            IncrementLineNumber();
            string costObt = rdr.ReadLine();
            IncrementLineNumber();



            bool bestDeliver;
            bool.TryParse(rdr.ReadLine(), out bestDeliver);
            IncrementLineNumber();
            bool reinforcedDeliver;
            bool.TryParse(rdr.ReadLine(), out reinforcedDeliver);
            IncrementLineNumber();


            bool bestObtain;
            bool.TryParse(rdr.ReadLine(), out bestObtain);
            IncrementLineNumber();
            bool reinforcedObtain;
            bool.TryParse(rdr.ReadLine(), out reinforcedObtain);
            IncrementLineNumber();


            if (Nodes.Instance.ContainsKey(from_node) &&
                 Nodes.Instance.ContainsKey(to_node))
            {
                Appliance node1 = Nodes.Instance[from_node];
                Appliance node2 = Nodes.Instance[to_node];

                //currentForm.mDiagram.AddNode(node2.applButton.eNode);
                //node2.applButton.eNode.AddChild(node1.applButton.eNode);

                NodeConnection c = new NodeConnection(currentForm, node1, node2, state_name,
                    int.Parse(state_action), to_node_up, int.Parse(costDeliv), int.Parse(costObt), 
                    bestDeliver, reinforcedDeliver, bestObtain, reinforcedObtain);
                NodeConnections.Instance.Add(c);
                if (!c.to_node_up)
                {
                    node2.applButton.Text = "DOWN";
                    node2.applButton.BackColor = Color.Black;
                }

                if (DataNameParam == "")
                {
                    return;
                }











                if (c.state == this.DataNameParam &&
                    c.bestDeliver && connectionSet == ConnectionSetType.BestDeliver)
                {
                    currentForm.mDiagram.AddNode(node2.applButton.eNode);
                    node2.applButton.eNode.AddChild(node1.applButton.eNode);
                    //node1.applButton.eNode.AddGradient(c);
                }

                if (c.state == this.DataNameParam &&
                    c.reinforcedDeliver && connectionSet == ConnectionSetType.ReinforceDeliver)
                {
                    currentForm.mDiagram.AddNode(node2.applButton.eNode);
                    node2.applButton.eNode.AddChild(node1.applButton.eNode);
                    //node1.applButton.eNode.AddGradient(c);
                }



                if (c.state == this.DataNameParam &&
                    c.bestDeliver && connectionSet == ConnectionSetType.Deliver
                    && node1.applButton.Selected )
                {
                    //IterateGradients();
                    //string currentName = "AAA0000004C";
                    //while (currentName != "0")
                    //{
                    //}

                    //currentForm.mDiagram.AddNode(node2.applButton.eNode);
                    //node2.applButton.eNode.AddChild(node1.applButton.eNode);
                }

                //currentForm.mDiagram


                //Nodes.Instance["AAA0000004C"].applButton.eNode.
                    
                     



                //NodeConnections.Instance.Add(c);
            }

            



            //while ( true )
            //{
                //NodeConnections.Instance.get

            //}



        }




        /*
        private void IterateGradients()
        {
            foreach (NodeConnection n in NodeConnections.Instance)
            {
                if (n.node1.node_name == currentName &&
                    n.bestDeliver)
                {
                    //currentForm.mDiagram.AddNode(n.node2.applButton.eNode);
                    n.node2.applButton.eNode.AddChild(n.node1.applButton.eNode);
                    currentName = n.node2.node_name;
                    IterateGradients();
                }
            }

        }
         * */






    }


}
