namespace EscuelaTicket
{
    partial class ProblemasFrecuentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProblemasFrecuentes));
            this.label1 = new System.Windows.Forms.Label();
            this.problemas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_generart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSolucion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Salir = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Problemas frecuentes :";
            // 
            // problemas
            // 
            this.problemas.BackColor = System.Drawing.Color.White;
            this.problemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.problemas.FormattingEnabled = true;
            this.problemas.Location = new System.Drawing.Point(237, 54);
            this.problemas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.problemas.Name = "problemas";
            this.problemas.Size = new System.Drawing.Size(222, 28);
            this.problemas.TabIndex = 50;
            this.problemas.SelectedIndexChanged += new System.EventHandler(this.problemas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "¿No está tu problema?";
            // 
            // btn_generart
            // 
            this.btn_generart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_generart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_generart.Location = new System.Drawing.Point(346, 292);
            this.btn_generart.Name = "btn_generart";
            this.btn_generart.Size = new System.Drawing.Size(113, 60);
            this.btn_generart.TabIndex = 2;
            this.btn_generart.Text = "Generar ticket";
            this.btn_generart.UseVisualStyleBackColor = false;
            this.btn_generart.Click += new System.EventHandler(this.GenerarTicket);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 53;
            this.label3.Text = "Solución";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.labelSolucion);
            this.panel2.Location = new System.Drawing.Point(22, 147);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 127);
            this.panel2.TabIndex = 52;
            // 
            // labelSolucion
            // 
            this.labelSolucion.AutoSize = true;
            this.labelSolucion.Location = new System.Drawing.Point(4, 4);
            this.labelSolucion.Name = "labelSolucion";
            this.labelSolucion.Size = new System.Drawing.Size(21, 20);
            this.labelSolucion.TabIndex = 0;
            this.labelSolucion.Text = "...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.Salir);
            this.panel1.Controls.Add(this.btn_generart);
            this.panel1.Controls.Add(this.problemas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(266, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 368);
            this.panel1.TabIndex = 57;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EscuelaTicket.Properties.Resources.BENITO_JUAREZ;
            this.pictureBox1.Location = new System.Drawing.Point(29, 114);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // Salir
            // 
            this.Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.Image = ((System.Drawing.Image)(resources.GetObject("Salir.Image")));
            this.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Salir.Location = new System.Drawing.Point(22, 292);
            this.Salir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(126, 60);
            this.Salir.TabIndex = 62;
            this.Salir.Text = "Cerrar Sesión";
            this.Salir.UseVisualStyleBackColor = false;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // ProblemasFrecuentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "ProblemasFrecuentes";
            this.Text = "ProblemasFrecuentes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox problemas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_generart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelSolucion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Salir;
    }
}