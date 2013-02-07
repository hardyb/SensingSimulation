using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Collections;
using SensingSimulation.Commands;
using System.IO;


namespace SensingSimulation
{
    public partial class Form1 : Form
    {
        //List sensors;
        int x_from;
        int y_from;
        double dist;
        bool from_selected = false;
        ArrayList walls = new ArrayList();
        ArrayList sensors = new ArrayList();
        Dictionary<string, SimulationCommand> c = new Dictionary<string, SimulationCommand>();
        PresentationDialog pd;
        Aggregation ag;
        Point dragStart;
        Rectangle selectionRectangle;
        public Diagram mDiagram;
        LoadConnections lcForm;
        bool isDrawing = false;


        private Point mouseDownLocation = Point.Empty;

        public void setToolStrip(string theText)
        {
            //this.toolStripStatusLabel.Text = theText;
            this.toolStripSplitButton1.Text = theText;
        }




        public Form1()
        {
            InitializeComponent();
            //SimCommands.Instance.execute(Utilities.Helper.moduleList, this);
            //File.Delete(Utilities.Helper.moduleList);
            
            //Nodes.Instance.Add("temp1", new Appliance(this, new Point(10, 10)));
            //sensors.Add(new Sensor(this, new Point(10, 50)));
            //this.ContextMenuStrip = this.contextMenuStrip1;
            this.ContextMenuStrip = this.contextMenuStrip1;
            pd = new PresentationDialog();
            ag = new Aggregation();
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height - this.mainStatus.Height;
            Rectangle bounds = new Rectangle(0, 0, w, h);
            mDiagram = new Diagram(bounds);
            this.ResizeRedraw = false;
            lcForm = new LoadConnections(this);
            //this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);




        }

        private void Sensor1_Click(object sender, EventArgs e)
        {
        }

        private void Appliance1_Click(object sender, EventArgs e)
        {
            if (from_selected)
            {
                dist = Math.Sqrt(
                         Math.Pow(Math.Abs(x_from - Appliance1.Location.X), 2)
                       + Math.Pow(Math.Abs(y_from - Appliance1.Location.Y), 2)
                                 );
                from_selected = false;
                System.Windows.Forms.MessageBox.Show("Distance: " + dist.ToString());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("This is an appliance!");
                x_from = Appliance1.Location.X;
                y_from = Appliance1.Location.Y;
                from_selected = true;
            }

        }



        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs m = e as MouseEventArgs;
            Point newL = new Point(m.X, m.Y);
            Appliance1.Location = newL;

        }

        private void Sensor1_MouseClick(object sender, MouseEventArgs e)
        {

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (from_selected)
                {
                    dist = Math.Sqrt(
                             Math.Pow(Math.Abs(x_from - Sensor1.Location.X), 2)
                           + Math.Pow(Math.Abs(y_from - Sensor1.Location.Y), 2)
                                     );
                    from_selected = false;
                    System.Windows.Forms.MessageBox.Show("Distance: " + dist.ToString());
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("This is a sensor!");
                    x_from = Sensor1.Location.X;
                    y_from = Sensor1.Location.Y;
                    from_selected = true;
                }

            }

        }

        private void Sensor1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                //Form2 f2 = new Form2(5);
                //f2.ShowDialog();
                System.Windows.Forms.MessageBox.Show("Dialog closed!");

            }

        }

        private void Appliance1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = new Point(e.X, e.Y);
            
        }

        private void Appliance1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            this.Invalidate();
            try
            {
                Point dropLoc = PointToClient(new Point(e.X, e.Y));

                ApplianceButton b = e.Data.GetData(typeof(ApplianceButton)) as ApplianceButton;
                if (e.Effect == DragDropEffects.Move)
                {
                    //ApplianceButton b = e.Data.GetData(typeof(ApplianceButton)) as ApplianceButton;
                    //e.Data.GetType() == ApplianceButton.
                    b.Location = dropLoc;

                    TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + b.node_name + ".txt");
                    wtr.WriteLine("13");
                    wtr.Write(dropLoc.X.ToString());
                    wtr.Write(" ");
                    wtr.Write(dropLoc.Y.ToString());
                    wtr.Write("\n");
                    wtr.Close();


                    
                    //this.toolStripStatusLabel.Text = "MOVE ONE";
                }

                //if (e.Effect == DragDropEffects.Copy)
                //{
                    //if (b.Text == "A")
                    //{
                    //    Nodes.Instance.Add("newone", new Appliance(this, dropLoc, "newone"));
                    //}

                //}
                
            }
            catch (Exception ex)
            {
                this.toolStripStatusLabel.Text = "Exception thrown: " + ex.ToString();
            }





        }

        private void Appliance1_MouseMove(object sender, MouseEventArgs e)
        {
                if (e.Button == MouseButtons.Left) {
                    // we know the mouse is down - has it the mouse moved enough that we should
                    // consider it a drag?
                    Size dragBoxSize = SystemInformation.DragSize;

                    if ((dragBoxSize.Width > Math.Abs(mouseDownLocation.X - e.X))
                        ||(dragBoxSize.Height > Math.Abs(mouseDownLocation.Y - e.Y))) {
                        // we should consider this a drag...
                        DragDropEffects d = Appliance1.DoDragDrop(Appliance1, DragDropEffects.Copy);
                        //Sensor s = new Sensor();
                        //DragDropEffects d = Appliance1.DoDragDrop(s, DragDropEffects.Copy);
                        //this.toolStripStatusLabel.Text = d.ToString();

                    }
                }





            /*
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.toolStripStatusLabel.Text = "Drag";
                string x = "you dropped";
                Sensor s = new Sensor();
                DragDropEffects d = this.DoDragDrop(s, DragDropEffects.Copy);
                this.toolStripStatusLabel.Text = d.ToString();
            }
             * */


        }

        private void Appliance1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            this.toolStripStatusLabel.Text = "feedback_S";
            

        }

        private void Form1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            this.toolStripStatusLabel.Text = "feedback_T";

        }

        private void Sensor1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            this.toolStripStatusLabel.Text = "feedback_E";

        }

        private void Sensor1_DragOver(object sender, DragEventArgs e)
        {
            this.toolStripStatusLabel.Text = "DragOver";

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //e.Effect = DragDropEffects.Copy; 

        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            //this.toolStripStatusLabel.Text = "PREP SOMETHING";
            if ((e.KeyState & 8) == 8 &&
                            (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {

                // CTL KeyState for copy.
                //this.toolStripStatusLabel.Text = "PREP COPY";
                e.Effect = DragDropEffects.Copy;

            }
            else
            {
                //this.toolStripStatusLabel.Text = "PREP MOVE";
                e.Effect = DragDropEffects.Move;
            }



        }

        protected void DrawDiagram()
        {
            Graphics gfx = this.CreateGraphics();
            gfx.Clear(Color.White);

            Pen myPen = new Pen(Color.Black);
            gfx.DrawRectangle(myPen, this.selectionRectangle);
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height - this.mainStatus.Height;
            Rectangle bounds = new Rectangle(0, 0, w, h);

            this.mDiagram.Draw(gfx, bounds);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            return;

            //if (isDrawing)
            //{
            //    return;
            //}
            //e.ToString();
            //this.Invalidate(
            
            // Call the OnPaint method of the base class.
            Graphics gfx = this.CreateGraphics();
            
            //gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
//            gfx.ClipBounds.Size
            //this.Invalidate(
            //gfx.Clear(Color.White);

            //if (!e.ClipRectangle.IntersectsWith(this.mDiagram.mBounds))
            //{
            //    base.OnPaint(e);
            //    return;
            //}

            //if (!e.ClipRectangle.Equals(gfx.ClipBounds))
            //{
            //    base.OnPaint(e);
            //    return;
            //}
            
            Pen myPen = new Pen(Color.Black);
            gfx.DrawRectangle(myPen, this.selectionRectangle);
            //Rectangle bounds = new Rectangle(new Point(0, 0), gfx.ClipBounds.Size);
            //Rectangle bounds = new Rectangle(new Point(0,0), this.ClientRectangle.Size);
            int w = this.ClientRectangle.Width;
            int h = this.ClientRectangle.Height - this.mainStatus.Height;
            Rectangle bounds = new Rectangle(0, 0, w, h);
            
            //Rectangle bounds = new Rectangle(0, 0, this.Width-50, this.Height-50);
            //isDrawing = true;
            this.mDiagram.Draw(gfx, bounds);
            //isDrawing = false;

            //this.ClientRectangle
            
            

            /*
            foreach (NodeConnection n in NodeConnections.Instance)
            {
                if ( n.gradient == "best_deliver_to" )//&& n.state == "some name")
                {
                    myPen.CustomEndCap = new AdjustableArrowCap(10, 10, true);
                    int xAdjuster = 0;
                    int yAdjuster = 0;
                    Point toLocation = new Point(n.node2.applButton.Location.X,
                                                    n.node2.applButton.Location.Y);
                    if (n.node1.applButton.Location.X > n.node2.applButton.Location.X)
                    {
                        toLocation.X += n.node2.applButton.Width;
                    }
                    if (n.node1.applButton.Location.Y > n.node2.applButton.Location.Y)
                    {
                        toLocation.Y += n.node2.applButton.Height;
                    }
                    gfx.DrawLine(myPen, n.node1.applButton.Location, toLocation);
                }

            }
             * */

            base.OnPaint(e);

        } 


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //base.Paint();
            //base.pon
            //base.OnPaint(e);

            //foreach (NodeConnection n in NodeConnections.Instance)
            //{
                //Graphics gfx = this.CreateGraphics();
                //Graphics gfx = e.Graphics;
                //Pen myPen = new Pen(Color.Black);
                //gfx.DrawLine(myPen, n.node1.applButton.Location, n.node2.applButton.Location);

            //}


            // KEEP FOR TESTING STUFF
            //Graphics gfx = e.Graphics;
            //Pen myPen = new Pen(Color.Black);

            //Line line1 = new Line(new Point(10, 10), new Point(100, 100));
            //Line line3 = new Line(new Point(10, 50), new Point(60, 10));
            //Line line2 = new Line(new Point(50, 20), new Point(20, 100));

            //gfx.DrawLine(myPen, line1.StartPos, line1.EndPos);
            //gfx.DrawLine(myPen, new Point(10, 10), new Point(100, 100));

            //bool theyintersect = Intersect(line1, line2);
            //this.toolStripStatusLabel.Text = "Intersect? " + theyintersect.ToString();

            //return;

            //Pen newPen = new Pen(Color.Yellow, 10);
            //for (int i = 0; i < walls.Count; i++)
            //{
            //    Line currentLine = walls[i] as Line;
            //    gfx.DrawLine(newPen, currentLine.StartPos, currentLine.EndPos);
            //}

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void mainStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void LoadNodesMenuItem_Click(object sender, EventArgs e)
        {
            bool result;
            if (bool.TryParse("fal", out result) && result)
            {
                DialogResult r = System.Windows.Forms.MessageBox.Show("Reset Nodes?", "Refresh Display", MessageBoxButtons.YesNoCancel);
            }
            ReloadNodes();
            SetConnectionCommand c = (SetConnectionCommand)SimCommands.Instance["CONNECTION"];
            c.DataNameParam = "";
            //c.connectionSet = SetConnectionCommand.ConnectionSetType.BestDeliver;
            NodeConnections.Instance.Clear();
            foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
            {
                string nodeConnectionsFile = p.Key + "Connections.txt";
                SimCommands.Instance.execute(Utilities.Helper.simulationsFolder + nodeConnectionsFile, this);
            }


            //ReloadConnections();
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter wtr = File.CreateText("C:\\omnetpp-4.2.2\\my_workspace\\Mywork4\\src\\save.txt");
            foreach ( KeyValuePair<string, Appliance> p in Nodes.Instance )
            {
                wtr.WriteLine("NODE");
                wtr.WriteLine(p.Key);
                wtr.WriteLine("POSITION");
                wtr.WriteLine(p.Value.applButton.Location.X);
                wtr.WriteLine(p.Value.applButton.Location.Y);
            }
            wtr.Close();


        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
            {
                TextWriter wtr = File.CreateText(Utilities.Helper.eventsFolder + p.Key + ".txt");
                wtr.WriteLine("13");
                wtr.Write(p.Value.applButton.Location.X);
                wtr.Write(" ");
                wtr.Write(p.Value.applButton.Location.Y);
                wtr.Write("\n");
                wtr.Close();
            }


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void reinforcementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PresentationMenu_Click(object sender, EventArgs e)
        {
            pd.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ag.currentNodeName = "mytest";
            ag.ShowDialog();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Point dragTo = PointToClient(new Point(e.X, e.Y));
                Point dragTo = new Point(e.X, e.Y);
                int left = Math.Min(dragStart.X, dragTo.X);
                int top = Math.Min(dragStart.Y, dragTo.Y);
                int right = Math.Max(dragStart.X, dragTo.X);
                int bottom = Math.Max(dragStart.Y, dragTo.Y);

                int width = right - left;//Math.Abs(dragStart.X - dragTo.X);
                int height = bottom - top;//Math.Abs(dragStart.Y - dragTo.Y);
                //this.Invalidate();
                Rectangle r = new Rectangle(this.selectionRectangle.X, this.selectionRectangle.Y,
                    this.selectionRectangle.Width+4, this.selectionRectangle.Height+4);
                
                this.Invalidate(r);
                this.selectionRectangle = new Rectangle(left, top, width, height);
                
                
                this.toolStripStatusLabel.Text = left.ToString() + ":" + top.ToString() + ":" +
                    width.ToString() + ":" + height.ToString();            

                foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
                {
                    if (this.selectionRectangle.Contains(p.Value.applButton.Location))
                    {
                        p.Value.applButton.Selected = true;
                    }
                    else
                    {
                        p.Value.applButton.Selected = false;
                    }
                }





                // we know the mouse is down - has it the mouse moved enough that we should
                // consider it a drag?
                //Size dragBoxSize = SystemInformation.DragSize;

                //if ((dragBoxSize.Width > Math.Abs(mouseDownLocation.X - e.X))
                //    || (dragBoxSize.Height > Math.Abs(mouseDownLocation.Y - e.Y)))
                //{
                    // we should consider this a drag...
                    //theForm.setToolStrip("START DRAG");
                    //DragDropEffects d = this.applButton.DoDragDrop(applButton, DragDropEffects.All);
                //}
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.dragStart = new Point(e.X, e.Y);
            foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
            {
                p.Value.applButton.Selected = false;
            }


        }

        private void Sensor1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Rectangle r = new Rectangle(this.selectionRectangle.X, this.selectionRectangle.Y,
                this.selectionRectangle.Width + 4, this.selectionRectangle.Height + 4);
            this.Invalidate(r);
            this.selectionRectangle = new Rectangle(dragStart.X, dragStart.Y, 0, 0);

        }

        private void contextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Context ct = Context.Instance;
            ct.Edit = true;
            ct.ShowDialog();
            return;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void ArrangeMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //this.mDiagram.Arrange();
            this.mDiagram.Arrange();
            //this.mDiagram.Arrange(0.5, 10, 3, true);
            this.Cursor = Cursors.Arrow;

            //this.mDiagram.


            //this.Invalidate();
            this.DrawDiagram();

        }

        private void LoadConnectionsMenuItem_Click(object sender, EventArgs e)
        {
            this.lcForm.Show();
            //ReloadConnections();
        }

        public void ReloadConnections()
        {
            //DialogResult.
            
            //Utilities.Helper.InputBox("gradients", "best or reinforce?", 
            //    ref SimCommands.Instance["CONNECTION"].result);
            this.mDiagram.ClearConnections();
            NodeConnections.Instance.Clear();
            foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
            {
                string nodeConnectionsFile = p.Key + "Connections.txt";
                SimCommands.Instance.execute(Utilities.Helper.simulationsFolder + nodeConnectionsFile, this);
            }
            
            // Adds all connections (children only in diagram) starting
            // from each node that is selected
            foreach (KeyValuePair<string, Appliance> p in Nodes.Instance)
            {
                if (p.Value.applButton.Selected)
                {
                    IterateGradients(p.Value.node_name);
                }
            }

            //this.Invalidate();
            this.DrawDiagram();
        }

        private void ReloadNodes()
        {
            this.mDiagram.Clear();
            Nodes.Instance.removeAllFromForm();
            Nodes.Instance.Clear();
            SimCommands.Instance.execute(Utilities.Helper.moduleList, this);
            //this.Invalidate();
            this.DrawDiagram();
        }

        private void IterateGradients(string currentName)
        {
            foreach (NodeConnection n in NodeConnections.Instance)
            {
                if (n.node1.node_name == currentName &&
                    n.bestDeliver)
                {
                    //currentForm.mDiagram.AddNode(n.node2.applButton.eNode);
                    n.node2.applButton.eNode.AddChild(n.node1.applButton.eNode);
                    currentName = n.node2.node_name;
                    IterateGradients(currentName);
                }
            }

        }



        private void Form1_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            int x = 7;

        }


        private void DrawString(float x, float y)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            string drawString = "Sample Text";
            System.Drawing.Font drawFont = new System.Drawing.Font(
                "Arial", 8);
            System.Drawing.SolidBrush drawBrush = new
                System.Drawing.SolidBrush(System.Drawing.Color.Black);
            //float x = 150.0f;
            //float y = 50.0f;
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y);
//            GraphicsPath
            //formGraphics.DrawString(
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }


    }
}

/*
 *             DialogResult r = System.Windows.Forms.MessageBox.Show("Reset Nodes?", "Refresh Display", MessageBoxButtons.YesNoCancel);
            switch (r)
            {
                case DialogResult.Yes:
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    return;
                    break;
                default:
                    return;
                    break;

            }
            if (r == DialogResult.Yes)
            {
            }

*/