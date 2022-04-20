
namespace GOLLakheemDelk
{
    partial class Options
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
            this.Okay = new System.Windows.Forms.Button();
            this.CancelBut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeIntervald = new System.Windows.Forms.NumericUpDown();
            this.Heightd = new System.Windows.Forms.NumericUpDown();
            this.Widthd = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervald)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heightd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Widthd)).BeginInit();
            this.SuspendLayout();
            // 
            // Okay
            // 
            this.Okay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Okay.Location = new System.Drawing.Point(62, 213);
            this.Okay.Name = "Okay";
            this.Okay.Size = new System.Drawing.Size(103, 46);
            this.Okay.TabIndex = 0;
            this.Okay.Text = "OK";
            this.Okay.UseVisualStyleBackColor = true;
            // 
            // CancelBut
            // 
            this.CancelBut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBut.Location = new System.Drawing.Point(189, 213);
            this.CancelBut.Name = "CancelBut";
            this.CancelBut.Size = new System.Drawing.Size(103, 46);
            this.CancelBut.TabIndex = 1;
            this.CancelBut.Text = "Cancel";
            this.CancelBut.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time Interval";
            // 
            // TimeIntervald
            // 
            this.TimeIntervald.Location = new System.Drawing.Point(243, 47);
            this.TimeIntervald.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TimeIntervald.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.TimeIntervald.Name = "TimeIntervald";
            this.TimeIntervald.Size = new System.Drawing.Size(49, 20);
            this.TimeIntervald.TabIndex = 4;
            // 
            // Heightd
            // 
            this.Heightd.Location = new System.Drawing.Point(243, 158);
            this.Heightd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Heightd.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.Heightd.Name = "Heightd";
            this.Heightd.Size = new System.Drawing.Size(49, 20);
            this.Heightd.TabIndex = 5;
            // 
            // Widthd
            // 
            this.Widthd.Location = new System.Drawing.Point(243, 101);
            this.Widthd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Widthd.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.Widthd.Name = "Widthd";
            this.Widthd.Size = new System.Drawing.Size(49, 20);
            this.Widthd.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Width of the Array";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Height of the Array";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 282);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Widthd);
            this.Controls.Add(this.Heightd);
            this.Controls.Add(this.TimeIntervald);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelBut);
            this.Controls.Add(this.Okay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Options";
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Options_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervald)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heightd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Widthd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Okay;
        private System.Windows.Forms.Button CancelBut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TimeIntervald;
        private System.Windows.Forms.NumericUpDown Heightd;
        private System.Windows.Forms.NumericUpDown Widthd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}