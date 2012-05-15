using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using SensingSimulation.Utilities;



namespace SensingSimulation
{
    public partial class Context : Form
    {
        private static Context instance;
        public Dictionary<string, byte> d8 = new Dictionary<string, byte>();

        public Context()
        {
            InitializeComponent();
        }

        public bool Edit
        {
            set
            {
                this.treeView1.LabelEdit = value;
                if (this.treeView1.LabelEdit)
                {
                    this.contextMenuStrip1.Items["toolStripAdd"].Visible = true;
                    this.contextMenuStrip1.Items["toolStripDelete"].Visible = true;
                    this.contextMenuStrip1.Items["toolStripSet"].Visible = false;
                }
                else
                {
                    this.contextMenuStrip1.Items["toolStripAdd"].Visible = false;
                    this.contextMenuStrip1.Items["toolStripDelete"].Visible = false;
                    this.contextMenuStrip1.Items["toolStripSet"].Visible = true;
                }
            }
        }

        public static Context Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Context();
                }
                return instance;
            }
        }

        public void SaveTreeTop()
        {
            TextWriter tw = new StreamWriter(Helper.ProjFolder + "tree.txt", false);
            SaveTree(tw, this.treeView1.Nodes);
            tw.Close();

        }


        public void SaveTree(TextWriter tw, TreeNodeCollection c)
        {
            if (c.Count > 0)
            {
                tw.WriteLine("IN");
                foreach (TreeNode n in c)
                {
                    tw.WriteLine(n.Name);
                    SaveTree(tw, n.Nodes);
                }
                tw.WriteLine("OUT");
            }

        }



        public void ReadTreeTop()
        {
            this.treeView1.Nodes.Clear();
            TextReader tr = new StreamReader(Helper.ProjFolder + "tree.txt");
            string s = tr.ReadLine();
            if (s == "IN")
            {
                ReadTree(tr, this.treeView1.Nodes);
            }
            tr.Close();
        }

        
        /*
         * Method in support of reading in the tree.txt file into a tree
         * 
         * This is the general idea, but the method has some issue IRO
         * How it starts off.  Need to look at it some more
         */
        public void ReadTree(TextReader tr, TreeNodeCollection c)
        {
            TreeNode n = null;
            string s = tr.ReadLine();
            while (s != "OUT")
            {
                if (s == "IN" && n != null)
                {
                    ReadTree(tr, n.Nodes);
                }
                else
                {
                    n = c.Add(s, s);
                    n.Tag = d8[s];
                }
                s = tr.ReadLine();
            }
        }


        private void ReadNames()
        {
            TextReader tr = new StreamReader(Helper.ProjFolder + "context.txt");
            string s = tr.ReadLine();
            string n = tr.ReadLine();
            while ( s != null && n != null )
            {
                d8[s] = byte.Parse(n);
                s = tr.ReadLine();
                n = tr.ReadLine();
            }
            tr.Close();
        }


        private void WriteNames()
        {
            TextWriter wr = new StreamWriter(Helper.ProjFolder + "context.txt", false);
            foreach (KeyValuePair<string, byte> p in d8)
            {
                wr.WriteLine(p.Key);
                wr.WriteLine(p.Value);

            }
            wr.Close();
        }

        private void AddName(string s)
        {
            if (!d8.ContainsKey(s))
            {
                byte n = (byte)d8.Count;
                d8[s] = (byte)(n + 1);
                //d8[s] = n + byte.Parse("1");
            }
        }




        private void Context_Load(object sender, EventArgs e)
        {
            ReadNames();
            ReadTreeTop();
            return;

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //this.label1.Text = treeView1.SelectedNode.ToString();
            //string[] y = this.label1.Text.Split('\');

            //string xx;
            //int.Parse(xx);

            //int n = y.Count();
            //TreeNodeCollection t = treeView1.Nodes;
            //for ( int i = 0; i < n; i++ )
            //{
                //t[y[i]].Tag;
                //t = t[y[i]].Nodes;
            //}

            //byte x = (byte)treeView1.SelectedNode.Tag;

            this.label1.Text = treeView1.SelectedNode.FullPath + "  -  " + treeView1.SelectedNode.Tag;

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //this.treeView1.GetChildAtPoint(
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode n = this.treeView1.GetNodeAt(e.Location);
                if ( n != null )
                {
                    this.treeView1.SelectedNode = n;
                    this.contextMenuStrip1.Show(this.treeView1, e.Location);
                    //n.IsSelected
                }
            }

        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            TreeNode a = this.treeView1.SelectedNode.Nodes.Add("new", "new");
            this.AddName(a.Text);
            a.Tag = d8[a.Text];
            this.label1.Text = treeView1.SelectedNode.FullPath + "  -  " + treeView1.SelectedNode.Tag;

        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            this.treeView1.SelectedNode.Remove();

        }

        private void toolStripSet_Click(object sender, EventArgs e)
        {
            string[] y = this.treeView1.SelectedNode.FullPath.Split('\\');



            foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
            {
                if (p.Value.applButton.Selected)
                {
                    TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + p.Value.node_name + ".txt");
                    wtr.WriteLine("1");
                    foreach (string s in y)
                    {
                        wtr.Write(" ");
                        wtr.Write(d8[s].ToString());
                        //System.Windows.Forms.MessageBox.Show(p.Value.node_name + "  -  " + d8[s].ToString());
                    }
                    wtr.Close();
                }
            }
            this.Close();

        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.SaveTreeTop();
            this.WriteNames();
            this.Close();
            return;

        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.Node.Name = e.Label;
            this.AddName(e.Label);
            e.Node.Tag = d8[e.Label];
            this.label1.Text = treeView1.SelectedNode.FullPath + "  -  " + treeView1.SelectedNode.Tag;

        }
    }
}
