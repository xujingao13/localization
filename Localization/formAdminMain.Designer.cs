namespace Localization
{
    partial class formAdminMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.deviceManageButton = new System.Windows.Forms.Button();
            this.userManageButton = new System.Windows.Forms.Button();
            this.locAdminViewButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(84, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎管理员使用";
            // 
            // deviceManageButton
            // 
            this.deviceManageButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deviceManageButton.Location = new System.Drawing.Point(100, 107);
            this.deviceManageButton.Name = "deviceManageButton";
            this.deviceManageButton.Size = new System.Drawing.Size(150, 41);
            this.deviceManageButton.TabIndex = 1;
            this.deviceManageButton.Text = "设备管理";
            this.deviceManageButton.UseVisualStyleBackColor = true;
            this.deviceManageButton.Click += new System.EventHandler(this.deviceManageButton_Click);
            // 
            // userManageButton
            // 
            this.userManageButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userManageButton.Location = new System.Drawing.Point(100, 180);
            this.userManageButton.Name = "userManageButton";
            this.userManageButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userManageButton.Size = new System.Drawing.Size(150, 41);
            this.userManageButton.TabIndex = 2;
            this.userManageButton.Text = "用户管理";
            this.userManageButton.UseVisualStyleBackColor = true;
            this.userManageButton.Click += new System.EventHandler(this.userManageButton_Click);
            // 
            // locAdminViewButton
            // 
            this.locAdminViewButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.locAdminViewButton.Location = new System.Drawing.Point(100, 255);
            this.locAdminViewButton.Name = "locAdminViewButton";
            this.locAdminViewButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.locAdminViewButton.Size = new System.Drawing.Size(150, 41);
            this.locAdminViewButton.TabIndex = 3;
            this.locAdminViewButton.Text = "定位查看";
            this.locAdminViewButton.UseVisualStyleBackColor = true;
            this.locAdminViewButton.Click += new System.EventHandler(this.locAdminViewButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitButton.Location = new System.Drawing.Point(100, 330);
            this.exitButton.Name = "exitButton";
            this.exitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.exitButton.Size = new System.Drawing.Size(150, 41);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "退出";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // formAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 453);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.locAdminViewButton);
            this.Controls.Add(this.userManageButton);
            this.Controls.Add(this.deviceManageButton);
            this.Controls.Add(this.label1);
            this.Name = "formAdminMain";
            this.Text = "formRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deviceManageButton;
        private System.Windows.Forms.Button userManageButton;
        private System.Windows.Forms.Button locAdminViewButton;
        private System.Windows.Forms.Button exitButton;
    }
}