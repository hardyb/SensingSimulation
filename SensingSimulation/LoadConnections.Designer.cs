namespace SensingSimulation
{
    partial class LoadConnections
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
            this.dataNamesCmbBox = new System.Windows.Forms.ComboBox();
            this.BestDeliverRButton = new System.Windows.Forms.RadioButton();
            this.ReinforceDeliverRButton = new System.Windows.Forms.RadioButton();
            this.BestObtainRButton = new System.Windows.Forms.RadioButton();
            this.ReinforceObtainRButton = new System.Windows.Forms.RadioButton();
            this.OKBtn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // dataNamesCmbBox
            // 
            this.dataNamesCmbBox.FormattingEnabled = true;
            this.dataNamesCmbBox.Location = new System.Drawing.Point(13, 13);
            this.dataNamesCmbBox.Name = "dataNamesCmbBox";
            this.dataNamesCmbBox.Size = new System.Drawing.Size(166, 21);
            this.dataNamesCmbBox.TabIndex = 0;
            this.dataNamesCmbBox.SelectedIndexChanged += new System.EventHandler(this.dataNamesCmbBox_SelectedIndexChanged);
            // 
            // BestDeliverRButton
            // 
            this.BestDeliverRButton.AutoSize = true;
            this.BestDeliverRButton.Location = new System.Drawing.Point(13, 41);
            this.BestDeliverRButton.Name = "BestDeliverRButton";
            this.BestDeliverRButton.Size = new System.Drawing.Size(82, 17);
            this.BestDeliverRButton.TabIndex = 1;
            this.BestDeliverRButton.TabStop = true;
            this.BestDeliverRButton.Text = "Best Deliver";
            this.BestDeliverRButton.UseVisualStyleBackColor = true;
            this.BestDeliverRButton.CheckedChanged += new System.EventHandler(this.BestDeliverRButton_CheckedChanged);
            // 
            // ReinforceDeliverRButton
            // 
            this.ReinforceDeliverRButton.AutoSize = true;
            this.ReinforceDeliverRButton.Location = new System.Drawing.Point(13, 64);
            this.ReinforceDeliverRButton.Name = "ReinforceDeliverRButton";
            this.ReinforceDeliverRButton.Size = new System.Drawing.Size(107, 17);
            this.ReinforceDeliverRButton.TabIndex = 1;
            this.ReinforceDeliverRButton.TabStop = true;
            this.ReinforceDeliverRButton.Text = "Reinforce Deliver";
            this.ReinforceDeliverRButton.UseVisualStyleBackColor = true;
            // 
            // BestObtainRButton
            // 
            this.BestObtainRButton.AutoSize = true;
            this.BestObtainRButton.Location = new System.Drawing.Point(13, 87);
            this.BestObtainRButton.Name = "BestObtainRButton";
            this.BestObtainRButton.Size = new System.Drawing.Size(80, 17);
            this.BestObtainRButton.TabIndex = 1;
            this.BestObtainRButton.TabStop = true;
            this.BestObtainRButton.Text = "Best Obtain";
            this.BestObtainRButton.UseVisualStyleBackColor = true;
            // 
            // ReinforceObtainRButton
            // 
            this.ReinforceObtainRButton.AutoSize = true;
            this.ReinforceObtainRButton.Location = new System.Drawing.Point(13, 110);
            this.ReinforceObtainRButton.Name = "ReinforceObtainRButton";
            this.ReinforceObtainRButton.Size = new System.Drawing.Size(105, 17);
            this.ReinforceObtainRButton.TabIndex = 1;
            this.ReinforceObtainRButton.TabStop = true;
            this.ReinforceObtainRButton.Text = "Reinforce Obtain";
            this.ReinforceObtainRButton.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(13, 133);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "Apply";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(104, 133);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(136, 41);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(127, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Best Deliver Selected";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // LoadConnections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 240);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.ReinforceObtainRButton);
            this.Controls.Add(this.BestObtainRButton);
            this.Controls.Add(this.ReinforceDeliverRButton);
            this.Controls.Add(this.BestDeliverRButton);
            this.Controls.Add(this.dataNamesCmbBox);
            this.Name = "LoadConnections";
            this.Text = "Manage connections";
            this.VisibleChanged += new System.EventHandler(this.LoadConnections_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dataNamesCmbBox;
        private System.Windows.Forms.RadioButton BestDeliverRButton;
        private System.Windows.Forms.RadioButton ReinforceDeliverRButton;
        private System.Windows.Forms.RadioButton BestObtainRButton;
        private System.Windows.Forms.RadioButton ReinforceObtainRButton;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}