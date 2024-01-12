namespace websoket1.Vista
{
    partial class Form1
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
            this.button1_Conectar = new System.Windows.Forms.Button();
            this.textBox1_URL = new System.Windows.Forms.TextBox();
            this.textBox2_Nom = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox3_Textoo = new System.Windows.Forms.TextBox();
            this.button2_Enviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1_Conectar
            // 
            this.button1_Conectar.Location = new System.Drawing.Point(374, 12);
            this.button1_Conectar.Name = "button1_Conectar";
            this.button1_Conectar.Size = new System.Drawing.Size(107, 37);
            this.button1_Conectar.TabIndex = 0;
            this.button1_Conectar.Text = "Conectar";
            this.button1_Conectar.UseVisualStyleBackColor = true;
            this.button1_Conectar.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1_URL
            // 
            this.textBox1_URL.Location = new System.Drawing.Point(12, 21);
            this.textBox1_URL.Name = "textBox1_URL";
            this.textBox1_URL.Size = new System.Drawing.Size(250, 20);
            this.textBox1_URL.TabIndex = 1;
            this.textBox1_URL.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2_Nom
            // 
            this.textBox2_Nom.Location = new System.Drawing.Point(268, 21);
            this.textBox2_Nom.Name = "textBox2_Nom";
            this.textBox2_Nom.Size = new System.Drawing.Size(100, 20);
            this.textBox2_Nom.TabIndex = 2;
            this.textBox2_Nom.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(469, 407);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textBox3_Textoo
            // 
            this.textBox3_Textoo.Location = new System.Drawing.Point(12, 472);
            this.textBox3_Textoo.Name = "textBox3_Textoo";
            this.textBox3_Textoo.Size = new System.Drawing.Size(379, 20);
            this.textBox3_Textoo.TabIndex = 4;
            this.textBox3_Textoo.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button2_Enviar
            // 
            this.button2_Enviar.Location = new System.Drawing.Point(406, 469);
            this.button2_Enviar.Name = "button2_Enviar";
            this.button2_Enviar.Size = new System.Drawing.Size(75, 29);
            this.button2_Enviar.TabIndex = 5;
            this.button2_Enviar.Text = "Enviar";
            this.button2_Enviar.UseVisualStyleBackColor = true;
            this.button2_Enviar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 504);
            this.Controls.Add(this.button2_Enviar);
            this.Controls.Add(this.textBox3_Textoo);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2_Nom);
            this.Controls.Add(this.textBox1_URL);
            this.Controls.Add(this.button1_Conectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1_Conectar;
        public System.Windows.Forms.TextBox textBox1_URL;
        public System.Windows.Forms.TextBox textBox2_Nom;
        public System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.TextBox textBox3_Textoo;
        public System.Windows.Forms.Button button2_Enviar;
    }
}