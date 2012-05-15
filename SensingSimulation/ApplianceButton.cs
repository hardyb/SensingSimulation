using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;

namespace SensingSimulation
{



    public class ApplianceButton : Button
    {
        public ENode eNode;
        public bool hasMoved = false;
        bool isSelected = false;
        Aggregation ag;

        // action indexes
        const int _null_action = 0;
        const int  _assign1	=	1;
        const int  _assign2	=	2;
        //const int  _messageIn	=	3;
        const int  _deliver	=	4;
        const int  _messageIn	=	5;
        const int  _gtr		=	6;
        const int  _ngtr		=	7;
        const int  _copyMessageIn	=8;
        const int  _forward	=	9;

        // aggregation states
        const int  IDLE_STATE	=	0;
        const int  ASSIGN_STATE=	1;
        const int  ASSIGN_TH	=	2;
        const int  ASSIGN_CO	=	3;
        const int  CHECK		=	4;
        const int  SENDPAUSE	=	5;
        const int  START_STATE	=	6;
        const int  NEXT_STATE	=	7;


        // data names
        const int  CONSUMPTION	=	5;
        const int  THRESH	=		6;
        const int  GRAB		=	7;
        const int  PAUSE		=	8;


        // variable indexes
        const int  _DATANAME =0;
        const int  _IN1 =1;
        const int  _IN2 =2;
        const int  _OUT1 =3;
        const int  _VAR1 =4;
        const int  _VAR2 =5;
        const int  _VAR3 =6;
        const int  _VAR4 =7;
        const int _VAR5 = 8;

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem toolStripMenuItemProperties;
        private ToolStripMenuItem toolStripMenuItemDisable;
        private ToolStripMenuItem toolStripMenuItemRole;
        private ToolStripMenuItem toolStripMenuItemStartup;
        public string node_name = null;


        static transition[] FSM =            
        { 
        new transition(START_STATE, new action2(_assign2, 9999, _VAR1, 0), NEXT_STATE),
        new transition(NEXT_STATE, new action2(_assign2, 0, _VAR2, 0), IDLE_STATE),
        new transition(IDLE_STATE, new action2(_copyMessageIn, THRESH, _VAR1, 0), IDLE_STATE),
        new transition(IDLE_STATE, new action2(_copyMessageIn, CONSUMPTION, _VAR2, 0), IDLE_STATE),
        new transition(IDLE_STATE, new action2(_messageIn, GRAB, 0, 0), CHECK),
        new transition(CHECK, new action2(_gtr, _VAR2, _IN1, _VAR1), SENDPAUSE),
        new transition(CHECK, new action2(_ngtr, _VAR2, _IN1, _VAR1), IDLE_STATE),
        new transition(SENDPAUSE, new action2(_deliver, PAUSE, 0, 0), IDLE_STATE)
        };

        Dictionary<string, int> d = new Dictionary<string, int>()
        {
            // action indexes
            { "_null_action", 0 },
            { "_assign1", 1 },
            { "_assign2", 2 },
            { "_deliver", 4 },
            { "_messageIn", 5 },
            { "_gtr", 6 },
            { "_ngtr", 7 },
            { "_copyMessageIn", 8 },
            { "_forward", 9 },
            // aggregation states
            { "IDLE_STATE", 0 },
            { "ASSIGN_STATE", 1 },
            { "ASSIGN_TH", 2 },
            { "ASSIGN_CO", 3 },
            { "CHECK", 4 },
            { "SENDPAUSE", 5 },
            { "START_STATE", 6 },
            { "NEXT_STATE", 7 },
            // data names
            { "CONSUMPTION", 5 },
            { "THRESH", 	6 },
            { "GRAB", 7 },
            { "PAUSE", 8 },
            // variable indexes
            { "_DATANAME", 0 },
            { "_IN1", 1 },
            { "_IN2", 2 },
            { "_OUT1", 3 },
            { "_VAR1", 4 },
            { "_VAR2", 5 },
            { "_VAR3", 6 },
            { "_VAR4", 7 },
            { "_VAR5",  8 }
        };
            













/*
            {
            new transition(0, new action2(0,0,0,0), 0),
            new transition(0, new action2(0,0,0,0), 0)
            };
*/
        
        //{ 0, {0, 9999, 0, 0}, 0 }};

        //{0, {0, 0, 0, 0}, 0}
        //};
  //      IDLE_STATE, {_copyMessageIn, THRESH, _VAR1, 0}, IDLE_STATE,
  //      IDLE_STATE, {_copyMessageIn, CONSUMPTION, _VAR2, 0}, IDLE_STATE,
  //      IDLE_STATE, {_messageIn, GRAB, 0, 0}, CHECK,
  //      CHECK, {_gtr, _VAR2, _IN1, _VAR1}, SENDPAUSE,
  //      CHECK, {_ngtr, _VAR2, _IN1, _VAR1}, IDLE_STATE,
  //      SENDPAUSE, {_deliver, PAUSE, 0, 0}, IDLE_STATE
  //      };

        /*
        const transition[] FSM =
        { 
        new transition(START_STATE, new action2(_assign2, 9999, _VAR1, 0), NEXT_STATE),
        new transition(NEXT_STATE, new action2(_assign2, 0, _VAR2, 0), IDLE_STATE),
        new transition(IDLE_STATE, new action2(_copyMessageIn, THRESH, _VAR1, 0), IDLE_STATE),
        new transition(IDLE_STATE, new action2(_copyMessageIn, CONSUMPTION, _VAR2, 0), IDLE_STATE),
        new transition(IDLE_STATE, new action2(_messageIn, GRAB, 0, 0), CHECK),
        new transition(CHECK, new action2(_gtr, _VAR2, _IN1, _VAR1), SENDPAUSE),
        new transition(CHECK, new action2(_ngtr, _VAR2, _IN1, _VAR1), IDLE_STATE),
        new transition(SENDPAUSE, new action2(_deliver, PAUSE, 0, 0), IDLE_STATE)
        };
         * */



        public ApplianceButton() : this(new Point(10, 10))
        {

        }

        public ApplianceButton(Point position)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.White;
            //this
            //this.SetBackground("C:\\Users\\Andrew Hardy\\Pictures\\Old\\Appliance_Icon.jpg");
            this.Location = new System.Drawing.Point(position.X, position.Y);
            this.Name = "Appliance1";
            this.Size = new System.Drawing.Size(38, 35);
            this.TabIndex = 1;
            //this.toolTip1.SetToolTip(this.Appliance1, "Hi there!");
            this.UseVisualStyleBackColor = false;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            //this.toolStripMenuItem1.Click += new System.EventHandler(
            eNode = new ENode(this);
            ag = new Aggregation();


        }

        public bool Selected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                isSelected = value;
                if (isSelected)
                {
                    this.FlatAppearance.BorderColor = Color.Black;
                    this.FlatAppearance.BorderSize = 4;
                }
                else
                {
                    this.FlatAppearance.BorderSize = 0;
                }
            }
        }



        public void SetFSM()
        {
            
            
            //ApplianceButton.FSM =            {
            //new transition(0, new action2(0,0,0,0), 0),
            //new transition(0, new action2(0,0,0,0), 0)
            //};



        }


        public void SetBackground(string filename)
        {
            //System.Windows.Forms.MessageBox.Show(FSM.ToString());

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(filename);
            this.BackgroundImage = bmp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRole = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItemDisable,
            this.toolStripMenuItemProperties,
            this.toolStripMenuItemRole,
            this.toolStripMenuItemStartup});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 180);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Interest";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "Advert";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "Data";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem4.Text = "Reinforcement";
            // 
            // toolStripMenuItemDisable
            // 
            this.toolStripMenuItemDisable.Name = "toolStripMenuItemDisable";
            this.toolStripMenuItemDisable.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemDisable.Text = "Disable/Enable";
            this.toolStripMenuItemDisable.Click += new System.EventHandler(this.toolStripMenuItemDisable_Click);
            // 
            // toolStripMenuItemProperties
            // 
            this.toolStripMenuItemProperties.Name = "toolStripMenuItemProperties";
            this.toolStripMenuItemProperties.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemProperties.Text = "Properties";
            this.toolStripMenuItemProperties.Click += new System.EventHandler(this.toolStripMenuItemProperties_Click);
            // 
            // toolStripMenuItemRole
            // 
            this.toolStripMenuItemRole.Name = "toolStripMenuItemRole";
            this.toolStripMenuItemRole.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemRole.Text = "Role";
            this.toolStripMenuItemRole.Click += new System.EventHandler(this.toolStripMenuItemRole_Click);
            // 
            // toolStripMenuItemStartup
            // 
            this.toolStripMenuItemStartup.Name = "toolStripMenuItemStartup";
            this.toolStripMenuItemStartup.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemStartup.Text = "Startup";
            this.toolStripMenuItemStartup.Click += new System.EventHandler(this.toolStripMenuItemStartup_Click);
            // 
            // ApplianceButton
            // 
            this.BackColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.UseVisualStyleBackColor = false;
            this.Click += new System.EventHandler(this.ApplianceButton_Click);
            this.Move += new System.EventHandler(this.ApplianceButton_Move);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Hi");

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string value = "";
            if (Utilities.Helper.InputBox("Send Interest",
                "Enter the value of interested data: ", ref value) == DialogResult.OK
                && value != "")
            {
                foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
                {
                    if (p.Value.applButton.Selected)
                    {
                        TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + p.Value.node_name + ".txt");
                        wtr.WriteLine("5");
                        wtr.WriteLine(value);
                        wtr.Close();
                    }
                }
            }
            int x = 2;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string value = "";
            if (Utilities.Helper.InputBox("Send Advert",
                "Enter the value of advertised data: ", ref value) == DialogResult.OK
                && value != "")
            {
                TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + node_name + ".txt");
                wtr.WriteLine("1");
                wtr.WriteLine(value);
                wtr.Close();
            }

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            string value = "";
            if (Utilities.Helper.InputBox("Send Reinforcement",
                "Enter the value of data you want to reinforce: ", ref value) == DialogResult.OK
                && value != "")
            {
                TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + node_name + ".txt");
                wtr.WriteLine("8");
                wtr.WriteLine(value);
                wtr.Close();
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string value = "";
            if (Utilities.Helper.InputBox("Send Data",
                "Enter the value of data you want to send: ", ref value) == DialogResult.OK
                && value != "")
            {
                TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + node_name + ".txt");
                wtr.WriteLine("2");
                wtr.WriteLine(value);
                wtr.Close();
            }

        }

        private void toolStripMenuItemProperties_Click(object sender, EventArgs e)
        {
            ApplianceDialog ad = new ApplianceDialog(this.node_name);
            ad.Show();
            return;

            Context ct = Context.Instance;
            ct.Edit = false;
            ct.ShowDialog();
            return;

        }

        private void toolStripMenuItemDisable_Click(object sender, EventArgs e)
        {
            TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + node_name + ".txt");
            wtr.WriteLine("3");
            wtr.WriteLine("1");
            wtr.Close();


        }



        private void toolStripMenuItemRole_Click(object sender, EventArgs e)
        {
            ag.currentNodeName = this.node_name;
            ag.ShowDialog();

            
            
            
            
            
            /*
            string value = "";
            if (Utilities.Helper.InputBox("Set Role",
                "Enter states <current> <incoming> <outgoing>: ", ref value) == DialogResult.OK
                && value != "")
            {
                TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + node_name + ".txt");
                //wtr.WriteLine("14");
                wtr.WriteLine("14");
                wtr.WriteLine(value);
                wtr.Close();
            }
             * */




            /*
            byte[] xx = null;

            string[] jj = new string[5];
            jj[3] = "hello";
            

            
            TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + node_name + ".txt");
            foreach (transition t in FSM)
            {
                string s = "";
                //s + 
                BitConverter.GetBytes(t.source);


                


            }
            */








        }

        private void toolStripMenuItemStartup_Click(object sender, EventArgs e)
        {
            string value = "";
            foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
            {
                if (p.Value.applButton.Selected)
                {
                    TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + p.Value.node_name + ".txt");
                    wtr.WriteLine("15");
                    wtr.WriteLine(value);
                    wtr.Close();
                }
            }





        }

        private void ApplianceButton_Move(object sender, EventArgs e)
        {
            hasMoved = true;

        }

        private void ApplianceButton_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != 0) 
            //if ((e.KeyState & 8) == 8 )
            {
                this.Selected = !this.Selected;
            }
            else
            {
                foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
                {
                    p.Value.applButton.Selected = false;
                }
                this.Selected = true;
            }

        }


    }


    public class action1
    {
        UInt16 type;
        UInt16[] param = new UInt16[3];
    };


    public struct action2
    {
        public UInt16 type;
        public UInt16 param1;
        public UInt16 param2;
        public UInt16 param3;
        public action2(UInt16 _type, UInt16 _param1, UInt16 _param2, UInt16 _param3)
        {
            type = _type;
            param1 = _param1;
            param2 = _param2;
            param3 = _param3;
        }
    };

    public struct transition
    {
        public UInt16 source;	// 2 bytes
        public action2 ac;				// 8 bytes
        public UInt16 dest;	// 2 bytes
        public transition(UInt16 _source, action2 _ac, UInt16 _dest)
        {
            source = _source;
            ac = _ac;
            dest = _dest;
        }
    };

    //union action // 8 bytes
    //{
    //    action1 _action1;
    //    action2 _action2;
    //};




}
