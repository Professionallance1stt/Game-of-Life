
namespace GOLLakheemDelk
{
    partial class Randomizer
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
            this.RandomValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelBut = new System.Windows.Forms.Button();
            this.Okay = new System.Windows.Forms.Button();
            this.Randomss = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RandomValue)).BeginInit();
            this.SuspendLayout();
            // 
            // RandomValue
            // 
            this.RandomValue.Location = new System.Drawing.Point(169, 46);
            this.RandomValue.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.RandomValue.Minimum = new decimal(new int[] {
            1000000000,
            0,
            0,
            -2147483648});
            this.RandomValue.Name = "RandomValue";
            this.RandomValue.Size = new System.Drawing.Size(49, 20);
            this.RandomValue.TabIndex = 7;
            this.RandomValue.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RandomValue.ValueChanged += new System.EventHandler(this.RandomValue_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Randomize by Seed ";
            // 
            // CancelBut
            // 
            this.CancelBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBut.Location = new System.Drawing.Point(169, 102);
            this.CancelBut.Name = "CancelBut";
            this.CancelBut.Size = new System.Drawing.Size(103, 46);
            this.CancelBut.TabIndex = 10;
            this.CancelBut.Text = "Cancel";
            this.CancelBut.UseVisualStyleBackColor = true;
            // 
            // Okay
            // 
            this.Okay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Okay.Location = new System.Drawing.Point(42, 102);
            this.Okay.Name = "Okay";
            this.Okay.Size = new System.Drawing.Size(103, 46);
            this.Okay.TabIndex = 9;
            this.Okay.Text = "OK";
            this.Okay.UseVisualStyleBackColor = true;
            // 
            // Randomss
            // 
            this.Randomss.Location = new System.Drawing.Point(238, 48);
            this.Randomss.Name = "Randomss";
            this.Randomss.Size = new System.Drawing.Size(75, 23);
            this.Randomss.TabIndex = 11;
            this.Randomss.Text = "Randomizer";
            this.Randomss.UseVisualStyleBackColor = true;
            this.Randomss.Click += new System.EventHandler(this.Randomss_Click);
            // 
            // Randomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 178);
            this.Controls.Add(this.Randomss);
            this.Controls.Add(this.CancelBut);
            this.Controls.Add(this.Okay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RandomValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Randomizer";
            this.Text = "Randomizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Randomizer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.RandomValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown RandomValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelBut;
        private System.Windows.Forms.Button Okay;
        private System.Windows.Forms.Button Randomss;
    }
}