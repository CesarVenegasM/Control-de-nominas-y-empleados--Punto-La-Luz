namespace PuntoLaLuz
{
    partial class Entradas_y_salidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entradas_y_salidas));
            this.btn_entrada = new System.Windows.Forms.Button();
            this.txt_asistencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_salida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_entrada
            // 
            this.btn_entrada.BackColor = System.Drawing.Color.Transparent;
            this.btn_entrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_entrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_entrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_entrada.ForeColor = System.Drawing.Color.Transparent;
            this.btn_entrada.Location = new System.Drawing.Point(91, 228);
            this.btn_entrada.Name = "btn_entrada";
            this.btn_entrada.Size = new System.Drawing.Size(96, 47);
            this.btn_entrada.TabIndex = 0;
            this.btn_entrada.UseVisualStyleBackColor = false;
            this.btn_entrada.Click += new System.EventHandler(this.btn_entrada_Click);
            // 
            // txt_asistencia
            // 
            this.txt_asistencia.BackColor = System.Drawing.Color.MistyRose;
            this.txt_asistencia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_asistencia.Location = new System.Drawing.Point(232, 173);
            this.txt_asistencia.Name = "txt_asistencia";
            this.txt_asistencia.Size = new System.Drawing.Size(163, 26);
            this.txt_asistencia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 2;
            // 
            // btn_salida
            // 
            this.btn_salida.BackColor = System.Drawing.Color.Transparent;
            this.btn_salida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_salida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salida.ForeColor = System.Drawing.Color.Transparent;
            this.btn_salida.Location = new System.Drawing.Point(245, 236);
            this.btn_salida.Name = "btn_salida";
            this.btn_salida.Size = new System.Drawing.Size(93, 39);
            this.btn_salida.TabIndex = 4;
            this.btn_salida.UseVisualStyleBackColor = false;
            this.btn_salida.Click += new System.EventHandler(this.btn_salida_Click);
            // 
            // Entradas_y_salidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(426, 305);
            this.Controls.Add(this.btn_salida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_asistencia);
            this.Controls.Add(this.btn_entrada);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Entradas_y_salidas";
            this.Text = "Entradas_y_salidas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_entrada;
        private System.Windows.Forms.TextBox txt_asistencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_salida;
    }
}