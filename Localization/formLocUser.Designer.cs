namespace Localization
{
    partial class formLocUser
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.locationYText = new System.Windows.Forms.TextBox();
            this.userLocationPanel = new System.Windows.Forms.Panel();
            this.locViewPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addLocationResultButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.locationXText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.userLocationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locViewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.locationYText, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.userLocationPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.addLocationResultButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exitButton, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.locationXText, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 453);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // locationYText
            // 
            this.locationYText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.locationYText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.locationYText.Location = new System.Drawing.Point(459, 413);
            this.locationYText.Name = "locationYText";
            this.locationYText.Size = new System.Drawing.Size(77, 34);
            this.locationYText.TabIndex = 8;
            // 
            // userLocationPanel
            // 
            this.userLocationPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.userLocationPanel, 6);
            this.userLocationPanel.Controls.Add(this.locViewPictureBox);
            this.userLocationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userLocationPanel.Location = new System.Drawing.Point(3, 3);
            this.userLocationPanel.Name = "userLocationPanel";
            this.userLocationPanel.Size = new System.Drawing.Size(826, 401);
            this.userLocationPanel.TabIndex = 0;
            // 
            // locViewPictureBox
            // 
            this.locViewPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.locViewPictureBox.Location = new System.Drawing.Point(-2, -2);
            this.locViewPictureBox.Name = "locViewPictureBox";
            this.locViewPictureBox.Size = new System.Drawing.Size(491, 265);
            this.locViewPictureBox.TabIndex = 0;
            this.locViewPictureBox.TabStop = false;
            this.locViewPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.locViewPictureBox_MouseDown);
            this.locViewPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.locViewPictureBox_MouseMove);
            this.locViewPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.locViewPictureBox_MouseUp);
            this.locViewPictureBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.locViewPictureBox_MouseWheel);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(211, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前位置X:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(418, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y:";
            // 
            // addLocationResultButton
            // 
            this.addLocationResultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addLocationResultButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addLocationResultButton.Location = new System.Drawing.Point(3, 410);
            this.addLocationResultButton.Name = "addLocationResultButton";
            this.addLocationResultButton.Size = new System.Drawing.Size(202, 40);
            this.addLocationResultButton.TabIndex = 5;
            this.addLocationResultButton.Text = "添加一个位置";
            this.addLocationResultButton.UseVisualStyleBackColor = true;
            this.addLocationResultButton.Click += new System.EventHandler(this.addLocationResultButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exitButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitButton.Location = new System.Drawing.Point(625, 410);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(204, 40);
            this.exitButton.TabIndex = 6;
            this.exitButton.TabStop = false;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // locationXText
            // 
            this.locationXText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.locationXText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.locationXText.Location = new System.Drawing.Point(335, 413);
            this.locationXText.Name = "locationXText";
            this.locationXText.Size = new System.Drawing.Size(77, 34);
            this.locationXText.TabIndex = 7;
            // 
            // formLocUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formLocUser";
            this.Text = "Form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.userLocationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.locViewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel userLocationPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addLocationResultButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox locationYText;
        private System.Windows.Forms.TextBox locationXText;
        private System.Windows.Forms.PictureBox locViewPictureBox;
    }
}