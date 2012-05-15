namespace SensingSimulation
{
    partial class PresentationDialog
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ReinforceDeliveryCheckBox = new System.Windows.Forms.CheckBox();
            this.ObtainGradientsCheckBox = new System.Windows.Forms.CheckBox();
            this.deliverGradientsCheckBox = new System.Windows.Forms.CheckBox();
            this.bestObtainGradientCheckBox = new System.Windows.Forms.CheckBox();
            this.bestDeliverGradientCheckBox = new System.Windows.Forms.CheckBox();
            this.obtainCostCheckBox = new System.Windows.Forms.CheckBox();
            this.reinforceObtainCheckBox = new System.Windows.Forms.CheckBox();
            this.deliveryCostCheckBox = new System.Windows.Forms.CheckBox();
            this.nodeValueCheckBox = new System.Windows.Forms.CheckBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "255",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "71"});
            this.comboBox1.Location = new System.Drawing.Point(76, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "State:";
            // 
            // ReinforceDeliveryCheckBox
            // 
            this.ReinforceDeliveryCheckBox.AutoSize = true;
            this.ReinforceDeliveryCheckBox.Location = new System.Drawing.Point(151, 146);
            this.ReinforceDeliveryCheckBox.Name = "ReinforceDeliveryCheckBox";
            this.ReinforceDeliveryCheckBox.Size = new System.Drawing.Size(113, 17);
            this.ReinforceDeliveryCheckBox.TabIndex = 2;
            this.ReinforceDeliveryCheckBox.Text = "Reinforce Delivery";
            this.ReinforceDeliveryCheckBox.UseVisualStyleBackColor = true;
            // 
            // ObtainGradientsCheckBox
            // 
            this.ObtainGradientsCheckBox.AutoSize = true;
            this.ObtainGradientsCheckBox.Location = new System.Drawing.Point(7, 75);
            this.ObtainGradientsCheckBox.Name = "ObtainGradientsCheckBox";
            this.ObtainGradientsCheckBox.Size = new System.Drawing.Size(105, 17);
            this.ObtainGradientsCheckBox.TabIndex = 3;
            this.ObtainGradientsCheckBox.Text = "Obtain Gradients";
            this.ObtainGradientsCheckBox.UseVisualStyleBackColor = true;
            // 
            // deliverGradientsCheckBox
            // 
            this.deliverGradientsCheckBox.AutoSize = true;
            this.deliverGradientsCheckBox.Location = new System.Drawing.Point(151, 75);
            this.deliverGradientsCheckBox.Name = "deliverGradientsCheckBox";
            this.deliverGradientsCheckBox.Size = new System.Drawing.Size(107, 17);
            this.deliverGradientsCheckBox.TabIndex = 4;
            this.deliverGradientsCheckBox.Text = "Deliver Gradients";
            this.deliverGradientsCheckBox.UseVisualStyleBackColor = true;
            // 
            // bestObtainGradientCheckBox
            // 
            this.bestObtainGradientCheckBox.AutoSize = true;
            this.bestObtainGradientCheckBox.Location = new System.Drawing.Point(7, 123);
            this.bestObtainGradientCheckBox.Name = "bestObtainGradientCheckBox";
            this.bestObtainGradientCheckBox.Size = new System.Drawing.Size(124, 17);
            this.bestObtainGradientCheckBox.TabIndex = 5;
            this.bestObtainGradientCheckBox.Text = "Best Obtain Gradient";
            this.bestObtainGradientCheckBox.UseVisualStyleBackColor = true;
            // 
            // bestDeliverGradientCheckBox
            // 
            this.bestDeliverGradientCheckBox.AutoSize = true;
            this.bestDeliverGradientCheckBox.Location = new System.Drawing.Point(151, 123);
            this.bestDeliverGradientCheckBox.Name = "bestDeliverGradientCheckBox";
            this.bestDeliverGradientCheckBox.Size = new System.Drawing.Size(126, 17);
            this.bestDeliverGradientCheckBox.TabIndex = 6;
            this.bestDeliverGradientCheckBox.Text = "Best Deliver Gradient";
            this.bestDeliverGradientCheckBox.UseVisualStyleBackColor = true;
            // 
            // obtainCostCheckBox
            // 
            this.obtainCostCheckBox.AutoSize = true;
            this.obtainCostCheckBox.Location = new System.Drawing.Point(7, 99);
            this.obtainCostCheckBox.Name = "obtainCostCheckBox";
            this.obtainCostCheckBox.Size = new System.Drawing.Size(81, 17);
            this.obtainCostCheckBox.TabIndex = 7;
            this.obtainCostCheckBox.Text = "Obtain Cost";
            this.obtainCostCheckBox.UseVisualStyleBackColor = true;
            // 
            // reinforceObtainCheckBox
            // 
            this.reinforceObtainCheckBox.AutoSize = true;
            this.reinforceObtainCheckBox.Location = new System.Drawing.Point(7, 146);
            this.reinforceObtainCheckBox.Name = "reinforceObtainCheckBox";
            this.reinforceObtainCheckBox.Size = new System.Drawing.Size(106, 17);
            this.reinforceObtainCheckBox.TabIndex = 8;
            this.reinforceObtainCheckBox.Text = "Reinforce Obtain";
            this.reinforceObtainCheckBox.UseVisualStyleBackColor = true;
            // 
            // deliveryCostCheckBox
            // 
            this.deliveryCostCheckBox.AutoSize = true;
            this.deliveryCostCheckBox.Location = new System.Drawing.Point(151, 99);
            this.deliveryCostCheckBox.Name = "deliveryCostCheckBox";
            this.deliveryCostCheckBox.Size = new System.Drawing.Size(88, 17);
            this.deliveryCostCheckBox.TabIndex = 9;
            this.deliveryCostCheckBox.Text = "Delivery Cost";
            this.deliveryCostCheckBox.UseVisualStyleBackColor = true;
            // 
            // nodeValueCheckBox
            // 
            this.nodeValueCheckBox.AutoSize = true;
            this.nodeValueCheckBox.Location = new System.Drawing.Point(10, 211);
            this.nodeValueCheckBox.Name = "nodeValueCheckBox";
            this.nodeValueCheckBox.Size = new System.Drawing.Size(82, 17);
            this.nodeValueCheckBox.TabIndex = 10;
            this.nodeValueCheckBox.Text = "Node Value";
            this.nodeValueCheckBox.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(76, 184);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Node Type:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(202, 205);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Update";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "128",
            "0"});
            this.comboBox3.Location = new System.Drawing.Point(76, 12);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 14;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Type:";
            // 
            // PresentationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 235);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.nodeValueCheckBox);
            this.Controls.Add(this.deliveryCostCheckBox);
            this.Controls.Add(this.reinforceObtainCheckBox);
            this.Controls.Add(this.obtainCostCheckBox);
            this.Controls.Add(this.bestDeliverGradientCheckBox);
            this.Controls.Add(this.bestObtainGradientCheckBox);
            this.Controls.Add(this.deliverGradientsCheckBox);
            this.Controls.Add(this.ObtainGradientsCheckBox);
            this.Controls.Add(this.ReinforceDeliveryCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PresentationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PresentationDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ReinforceDeliveryCheckBox;
        private System.Windows.Forms.CheckBox ObtainGradientsCheckBox;
        private System.Windows.Forms.CheckBox deliverGradientsCheckBox;
        private System.Windows.Forms.CheckBox bestObtainGradientCheckBox;
        private System.Windows.Forms.CheckBox bestDeliverGradientCheckBox;
        private System.Windows.Forms.CheckBox obtainCostCheckBox;
        private System.Windows.Forms.CheckBox reinforceObtainCheckBox;
        private System.Windows.Forms.CheckBox deliveryCostCheckBox;
        private System.Windows.Forms.CheckBox nodeValueCheckBox;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
    }
}