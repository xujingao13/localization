namespace Localization
{
    partial class formUserManagement
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
            this.addUserDeviceButton = new System.Windows.Forms.Button();
            this.deleteUserDeviceButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.uControl_userInfoTitle1 = new Localization.UControl_userInfoTitle();
            this.deleteUserButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.addUserDeviceButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.deleteUserDeviceButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.deleteUserButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.returnButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 453);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // addUserDeviceButton
            // 
            this.addUserDeviceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addUserDeviceButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addUserDeviceButton.Location = new System.Drawing.Point(3, 388);
            this.addUserDeviceButton.Name = "addUserDeviceButton";
            this.addUserDeviceButton.Size = new System.Drawing.Size(204, 62);
            this.addUserDeviceButton.TabIndex = 4;
            this.addUserDeviceButton.Text = "添加设备关联";
            this.addUserDeviceButton.UseVisualStyleBackColor = true;
            this.addUserDeviceButton.Click += new System.EventHandler(this.addUserDeviceButton_Click);
            // 
            // deleteUserDeviceButton
            // 
            this.deleteUserDeviceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteUserDeviceButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteUserDeviceButton.Location = new System.Drawing.Point(213, 388);
            this.deleteUserDeviceButton.Name = "deleteUserDeviceButton";
            this.deleteUserDeviceButton.Size = new System.Drawing.Size(204, 62);
            this.deleteUserDeviceButton.TabIndex = 3;
            this.deleteUserDeviceButton.Text = "删除设备关联";
            this.deleteUserDeviceButton.UseVisualStyleBackColor = true;
            this.deleteUserDeviceButton.Click += new System.EventHandler(this.deleteUserDeviceButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 4);
            this.flowLayoutPanel1.Controls.Add(this.uControl_userInfoTitle1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(834, 379);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // uControl_userInfoTitle1
            // 
            this.uControl_userInfoTitle1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uControl_userInfoTitle1.Location = new System.Drawing.Point(3, 3);
            this.uControl_userInfoTitle1.Name = "uControl_userInfoTitle1";
            this.uControl_userInfoTitle1.Size = new System.Drawing.Size(818, 55);
            this.uControl_userInfoTitle1.TabIndex = 0;
            // 
            // deleteUserButton
            // 
            this.deleteUserButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteUserButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.deleteUserButton.Location = new System.Drawing.Point(423, 388);
            this.deleteUserButton.Name = "deleteUserButton";
            this.deleteUserButton.Size = new System.Drawing.Size(204, 62);
            this.deleteUserButton.TabIndex = 1;
            this.deleteUserButton.Text = "删除用户";
            this.deleteUserButton.UseVisualStyleBackColor = true;
            this.deleteUserButton.Click += new System.EventHandler(this.deleteUserButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.returnButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnButton.Location = new System.Drawing.Point(633, 388);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(204, 62);
            this.returnButton.TabIndex = 2;
            this.returnButton.Text = "返回";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // formUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formUserManagement";
            this.Text = "formUserManagement";
            this.Load += new System.EventHandler(this.formUserManagement_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button deleteUserButton;
        private System.Windows.Forms.Button returnButton;
        private UControl_userInfoTitle uControl_userInfoTitle1;
        private System.Windows.Forms.Button addUserDeviceButton;
        private System.Windows.Forms.Button deleteUserDeviceButton;
    }
}