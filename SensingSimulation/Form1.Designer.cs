namespace SensingSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Sensor1 = new System.Windows.Forms.Button();
            this.Appliance1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoadNodesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArrangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresentationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinforcementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadConnectionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatus.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sensor1
            // 
            this.Sensor1.AllowDrop = true;
            this.Sensor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Sensor1.BackColor = System.Drawing.Color.White;
            this.Sensor1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sensor1.BackgroundImage")));
            this.Sensor1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sensor1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Sensor1.Location = new System.Drawing.Point(350, 167);
            this.Sensor1.Name = "Sensor1";
            this.Sensor1.Size = new System.Drawing.Size(33, 34);
            this.Sensor1.TabIndex = 0;
            this.Sensor1.UseVisualStyleBackColor = false;
            this.Sensor1.Visible = false;
            this.Sensor1.DragOver += new System.Windows.Forms.DragEventHandler(this.Sensor1_DragOver);
            this.Sensor1.Click += new System.EventHandler(this.Sensor1_Click);
            this.Sensor1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Sensor1_MouseClick);
            this.Sensor1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Sensor1_MouseDown);
            this.Sensor1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Sensor1_MouseUp);
            this.Sensor1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Sensor1_GiveFeedback);
            // 
            // Appliance1
            // 
            this.Appliance1.BackColor = System.Drawing.Color.White;
            this.Appliance1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Appliance1.BackgroundImage")));
            this.Appliance1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Appliance1.Location = new System.Drawing.Point(623, 324);
            this.Appliance1.Name = "Appliance1";
            this.Appliance1.Size = new System.Drawing.Size(38, 35);
            this.Appliance1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Appliance1, "Hi there!");
            this.Appliance1.UseVisualStyleBackColor = false;
            this.Appliance1.Visible = false;
            this.Appliance1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Appliance1_MouseMove);
            this.Appliance1.Click += new System.EventHandler(this.Appliance1_Click);
            this.Appliance1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Appliance1_DragDrop);
            this.Appliance1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Appliance1_MouseDown);
            this.Appliance1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Appliance1_GiveFeedback);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1;
            this.toolTip1.AutoPopDelay = 2000;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 0;
            this.toolTip1.ToolTipTitle = "Title";
            // 
            // mainStatus
            // 
            this.mainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripSplitButton1});
            this.mainStatus.Location = new System.Drawing.Point(0, 607);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(882, 22);
            this.mainStatus.TabIndex = 2;
            this.mainStatus.Text = "statusxxxxxxxx";
            this.mainStatus.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainStatus_ItemClicked);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel.Text = "hhhh";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadNodesMenuItem,
            this.LoadConnectionsMenuItem,
            this.ArrangeMenuItem,
            this.PresentationMenu,
            this.saveToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.reinforcementToolStripMenuItem,
            this.testToolStripMenuItem,
            this.contextToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(179, 202);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // LoadNodesMenuItem
            // 
            this.LoadNodesMenuItem.Name = "LoadNodesMenuItem";
            this.LoadNodesMenuItem.Size = new System.Drawing.Size(170, 22);
            this.LoadNodesMenuItem.Text = "Load";
            this.LoadNodesMenuItem.Click += new System.EventHandler(this.LoadNodesMenuItem_Click);
            // 
            // ArrangeMenuItem
            // 
            this.ArrangeMenuItem.Name = "ArrangeMenuItem";
            this.ArrangeMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ArrangeMenuItem.Text = "Arrange nodes";
            this.ArrangeMenuItem.Click += new System.EventHandler(this.ArrangeMenuItem_Click);
            // 
            // PresentationMenu
            // 
            this.PresentationMenu.Name = "PresentationMenu";
            this.PresentationMenu.Size = new System.Drawing.Size(170, 22);
            this.PresentationMenu.Text = "Show";
            this.PresentationMenu.Click += new System.EventHandler(this.PresentationMenu_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.dataToolStripMenuItem.Text = "Export Positions";
            this.dataToolStripMenuItem.Click += new System.EventHandler(this.dataToolStripMenuItem_Click);
            // 
            // reinforcementToolStripMenuItem
            // 
            this.reinforcementToolStripMenuItem.Name = "reinforcementToolStripMenuItem";
            this.reinforcementToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.reinforcementToolStripMenuItem.Text = "Four";
            this.reinforcementToolStripMenuItem.Visible = false;
            this.reinforcementToolStripMenuItem.Click += new System.EventHandler(this.reinforcementToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // contextToolStripMenuItem
            // 
            this.contextToolStripMenuItem.Name = "contextToolStripMenuItem";
            this.contextToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.contextToolStripMenuItem.Text = "context";
            this.contextToolStripMenuItem.Click += new System.EventHandler(this.contextToolStripMenuItem_Click);
            // 
            // LoadConnectionsMenuItem
            // 
            this.LoadConnectionsMenuItem.Name = "LoadConnectionsMenuItem";
            this.LoadConnectionsMenuItem.Size = new System.Drawing.Size(178, 22);
            this.LoadConnectionsMenuItem.Text = "Reload connections";
            this.LoadConnectionsMenuItem.Click += new System.EventHandler(this.LoadConnectionsMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(882, 629);
            this.Controls.Add(this.mainStatus);
            this.Controls.Add(this.Appliance1);
            this.Controls.Add(this.Sensor1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MaximizedBoundsChanged += new System.EventHandler(this.Form1_MaximizedBoundsChanged);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Form1_GiveFeedback);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            this.mainStatus.ResumeLayout(false);
            this.mainStatus.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Sensor1;
        private System.Windows.Forms.Button Appliance1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LoadNodesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reinforcementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PresentationMenu;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ArrangeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadConnectionsMenuItem;
    }
}

