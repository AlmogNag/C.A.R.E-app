namespace C.A.R.E_app
{
    partial class Form1
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
            lblStatus = new Label();
            picCamera = new PictureBox();
            btnReset = new Button();
            ((System.ComponentModel.ISupportInitialize)picCamera).BeginInit();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Britannic Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(228, 309);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(321, 31);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "C.A.R.E - waiting for data";
            // 
            // picCamera
            // 
            picCamera.Location = new Point(242, 114);
            picCamera.Name = "picCamera";
            picCamera.Size = new Size(288, 192);
            picCamera.SizeMode = PictureBoxSizeMode.Zoom;
            picCamera.TabIndex = 1;
            picCamera.TabStop = false;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Aharoni", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(332, 368);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(108, 40);
            btnReset.TabIndex = 2;
            btnReset.Text = "OK";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(picCamera);
            Controls.Add(lblStatus);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picCamera).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private PictureBox picCamera;
        private Button btnReset;
    }
}
