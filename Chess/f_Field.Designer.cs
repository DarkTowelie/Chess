
namespace Chess
{
    partial class f_Field
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.p_FormBorder = new System.Windows.Forms.Panel();
            this.l_Turn = new System.Windows.Forms.Label();
            this.b_Close = new System.Windows.Forms.Button();
            this.p_FormBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrameTimer
            // 
            this.FrameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // p_FormBorder
            // 
            this.p_FormBorder.Controls.Add(this.l_Turn);
            this.p_FormBorder.Controls.Add(this.b_Close);
            this.p_FormBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_FormBorder.Location = new System.Drawing.Point(0, 0);
            this.p_FormBorder.Name = "p_FormBorder";
            this.p_FormBorder.Size = new System.Drawing.Size(636, 40);
            this.p_FormBorder.TabIndex = 0;
            this.p_FormBorder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p_FormBorder_MouseDown);
            this.p_FormBorder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.p_FormBorder_MouseMove);
            this.p_FormBorder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.p_FormBorder_MouseUp);
            // 
            // l_Turn
            // 
            this.l_Turn.AutoSize = true;
            this.l_Turn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_Turn.Location = new System.Drawing.Point(280, 9);
            this.l_Turn.Name = "l_Turn";
            this.l_Turn.Size = new System.Drawing.Size(52, 21);
            this.l_Turn.TabIndex = 1;
            this.l_Turn.Text = "label1";
            // 
            // b_Close
            // 
            this.b_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.b_Close.Location = new System.Drawing.Point(597, 0);
            this.b_Close.Name = "b_Close";
            this.b_Close.Size = new System.Drawing.Size(39, 40);
            this.b_Close.TabIndex = 0;
            this.b_Close.Text = "X";
            this.b_Close.UseVisualStyleBackColor = true;
            this.b_Close.Click += new System.EventHandler(this.b_Close_Click);
            // 
            // f_Field
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 613);
            this.Controls.Add(this.p_FormBorder);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "f_Field";
            this.Text = "Шахматы";
            this.Click += new System.EventHandler(this.f_Field_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.f_Field_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.f_Field_MouseMove);
            this.p_FormBorder.ResumeLayout(false);
            this.p_FormBorder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer FrameTimer;
        private System.Windows.Forms.Panel p_FormBorder;
        private System.Windows.Forms.Button b_Close;
        private System.Windows.Forms.Label l_Turn;
    }
}

