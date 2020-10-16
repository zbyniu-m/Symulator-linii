namespace WindowsFormsApp1
{
    partial class Symulator
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
            this.button_start_symulator = new System.Windows.Forms.Button();
            this.GBSymulacja = new System.Windows.Forms.GroupBox();
            this.button_stop_wydajnosc = new System.Windows.Forms.Button();
            this.button_start_wydajnosc = new System.Windows.Forms.Button();
            this.textBox_wydajnosc = new System.Windows.Forms.TextBox();
            this.hScrollBar_wydajnosc = new System.Windows.Forms.HScrollBar();
            this.groupBox_dane_serwera = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GBSymulacja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_start_symulator
            // 
            this.button_start_symulator.Location = new System.Drawing.Point(6, 26);
            this.button_start_symulator.Name = "button_start_symulator";
            this.button_start_symulator.Size = new System.Drawing.Size(386, 29);
            this.button_start_symulator.TabIndex = 0;
            this.button_start_symulator.Text = "Start symulacji";
            this.button_start_symulator.UseVisualStyleBackColor = true;
            // 
            // GBSymulacja
            // 
            this.GBSymulacja.Controls.Add(this.button_stop_wydajnosc);
            this.GBSymulacja.Controls.Add(this.button_start_wydajnosc);
            this.GBSymulacja.Controls.Add(this.textBox_wydajnosc);
            this.GBSymulacja.Controls.Add(this.hScrollBar_wydajnosc);
            this.GBSymulacja.Controls.Add(this.button_start_symulator);
            this.GBSymulacja.Location = new System.Drawing.Point(12, 12);
            this.GBSymulacja.Name = "GBSymulacja";
            this.GBSymulacja.Size = new System.Drawing.Size(409, 426);
            this.GBSymulacja.TabIndex = 1;
            this.GBSymulacja.TabStop = false;
            this.GBSymulacja.Text = "Symulator";
            // 
            // button_stop_wydajnosc
            // 
            this.button_stop_wydajnosc.Location = new System.Drawing.Point(200, 319);
            this.button_stop_wydajnosc.Name = "button_stop_wydajnosc";
            this.button_stop_wydajnosc.Size = new System.Drawing.Size(190, 29);
            this.button_stop_wydajnosc.TabIndex = 4;
            this.button_stop_wydajnosc.Text = "Stop linii";
            this.button_stop_wydajnosc.UseVisualStyleBackColor = true;
            this.button_stop_wydajnosc.Click += new System.EventHandler(this.button_stop_wydajnosc_Click);
            // 
            // button_start_wydajnosc
            // 
            this.button_start_wydajnosc.Location = new System.Drawing.Point(6, 319);
            this.button_start_wydajnosc.Name = "button_start_wydajnosc";
            this.button_start_wydajnosc.Size = new System.Drawing.Size(190, 29);
            this.button_start_wydajnosc.TabIndex = 3;
            this.button_start_wydajnosc.Text = "Start linii";
            this.button_start_wydajnosc.UseVisualStyleBackColor = true;
            this.button_start_wydajnosc.Click += new System.EventHandler(this.button_start_wydajnosc_Click);
            // 
            // textBox_wydajnosc
            // 
            this.textBox_wydajnosc.Location = new System.Drawing.Point(0, 354);
            this.textBox_wydajnosc.Name = "textBox_wydajnosc";
            this.textBox_wydajnosc.Size = new System.Drawing.Size(392, 27);
            this.textBox_wydajnosc.TabIndex = 2;
            // 
            // hScrollBar_wydajnosc
            // 
            this.hScrollBar_wydajnosc.LargeChange = 3000;
            this.hScrollBar_wydajnosc.Location = new System.Drawing.Point(0, 384);
            this.hScrollBar_wydajnosc.Maximum = 33000;
            this.hScrollBar_wydajnosc.Name = "hScrollBar_wydajnosc";
            this.hScrollBar_wydajnosc.Size = new System.Drawing.Size(392, 26);
            this.hScrollBar_wydajnosc.TabIndex = 1;
            this.hScrollBar_wydajnosc.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_wydajnosc_Scroll);
            // 
            // groupBox_dane_serwera
            // 
            this.groupBox_dane_serwera.Location = new System.Drawing.Point(427, 12);
            this.groupBox_dane_serwera.Name = "groupBox_dane_serwera";
            this.groupBox_dane_serwera.Size = new System.Drawing.Size(490, 426);
            this.groupBox_dane_serwera.TabIndex = 5;
            this.groupBox_dane_serwera.TabStop = false;
            this.groupBox_dane_serwera.Text = "Dane serwera";
            // 
            // Symulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 450);
            this.Controls.Add(this.groupBox_dane_serwera);
            this.Controls.Add(this.GBSymulacja);
            this.Name = "Symulator";
            this.Text = "Symulator ";
            this.GBSymulacja.ResumeLayout(false);
            this.GBSymulacja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_start_symulator;
        private System.Windows.Forms.GroupBox GBSymulacja;
        private System.Windows.Forms.Button button_stop_wydajnosc;
        private System.Windows.Forms.Button button_start_wydajnosc;
        private System.Windows.Forms.TextBox textBox_wydajnosc;
        private System.Windows.Forms.HScrollBar hScrollBar_wydajnosc;
        private System.Windows.Forms.GroupBox groupBox_dane_serwera;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

