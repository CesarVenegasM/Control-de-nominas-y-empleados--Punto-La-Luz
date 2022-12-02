namespace PuntoLaLuz
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btn_log = new System.Windows.Forms.Button();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_passw = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_log
            // 
            this.btn_log.BackColor = System.Drawing.Color.Transparent;
            this.btn_log.FlatAppearance.BorderSize = 0;
            this.btn_log.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightPink;
            this.btn_log.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_log.ForeColor = System.Drawing.Color.Transparent;
            this.btn_log.Location = new System.Drawing.Point(119, 293);
            this.btn_log.Margin = new System.Windows.Forms.Padding(3, 1, 1, 3);
            this.btn_log.Name = "btn_log";
            this.btn_log.Padding = new System.Windows.Forms.Padding(20, 2, 2, 20);
            this.btn_log.Size = new System.Drawing.Size(177, 45);
            this.btn_log.TabIndex = 0;
            this.btn_log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_log.UseVisualStyleBackColor = false;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // txt_user
            // 
            this.txt_user.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_user.Font = new System.Drawing.Font("Arial", 12F);
            this.txt_user.ForeColor = System.Drawing.Color.Gray;
            this.txt_user.Location = new System.Drawing.Point(131, 172);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(192, 19);
            this.txt_user.TabIndex = 1;
            // 
            // txt_passw
            // 
            this.txt_passw.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_passw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_passw.Font = new System.Drawing.Font("Arial", 12F);
            this.txt_passw.ForeColor = System.Drawing.Color.Gray;
            this.txt_passw.Location = new System.Drawing.Point(131, 242);
            this.txt_passw.Name = "txt_passw";
            this.txt_passw.Size = new System.Drawing.Size(192, 19);
            this.txt_passw.TabIndex = 2;
            this.txt_passw.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(409, 388);
            this.Controls.Add(this.txt_passw);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.btn_log);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_passw;
    }
}

