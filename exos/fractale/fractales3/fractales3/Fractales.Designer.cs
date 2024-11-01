namespace fractales3
{
    partial class Fractales
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
            drawingPanel = new Panel();
            nudDepth = new NumericUpDown();
            label1 = new Label();
            rbtLine = new RadioButton();
            rbtCurve = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)nudDepth).BeginInit();
            SuspendLayout();
            // 
            // drawingPanel
            // 
            drawingPanel.BorderStyle = BorderStyle.FixedSingle;
            drawingPanel.Location = new Point(12, 12);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(500, 500);
            drawingPanel.TabIndex = 0;
            drawingPanel.Paint += drawingPanel_Paint;
            // 
            // nudDepth
            // 
            nudDepth.Location = new Point(618, 96);
            nudDepth.Name = "nudDepth";
            nudDepth.Size = new Size(48, 23);
            nudDepth.TabIndex = 3;
            nudDepth.ValueChanged += nudDepth_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(573, 98);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 4;
            label1.Text = "Depth";
            // 
            // rbtLine
            // 
            rbtLine.AutoSize = true;
            rbtLine.Checked = true;
            rbtLine.Location = new Point(580, 25);
            rbtLine.Name = "rbtLine";
            rbtLine.Size = new Size(47, 19);
            rbtLine.TabIndex = 5;
            rbtLine.TabStop = true;
            rbtLine.Text = "Line";
            rbtLine.UseVisualStyleBackColor = true;
            rbtLine.CheckedChanged += rbtLine_CheckedChanged;
            // 
            // rbtCurve
            // 
            rbtCurve.AutoSize = true;
            rbtCurve.Location = new Point(580, 50);
            rbtCurve.Name = "rbtCurve";
            rbtCurve.Size = new Size(56, 19);
            rbtCurve.TabIndex = 6;
            rbtCurve.Text = "Curve";
            rbtCurve.UseVisualStyleBackColor = true;
            rbtCurve.CheckedChanged += rbtCurve_CheckedChanged;
            // 
            // Fractales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 634);
            Controls.Add(rbtCurve);
            Controls.Add(rbtLine);
            Controls.Add(label1);
            Controls.Add(nudDepth);
            Controls.Add(drawingPanel);
            Name = "Fractales";
            Text = "Fractales";
            ((System.ComponentModel.ISupportInitialize)nudDepth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel drawingPanel;
        private NumericUpDown nudDepth;
        private Label label1;
        private RadioButton rbtLine;
        private RadioButton rbtCurve;
    }
}
