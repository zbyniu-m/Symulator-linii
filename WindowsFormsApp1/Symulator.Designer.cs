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
            this.checkBox_symulacja = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_stop_wydajnosc = new System.Windows.Forms.Button();
            this.button_start_wydajnosc = new System.Windows.Forms.Button();
            this.textBox_wydajnosc = new System.Windows.Forms.TextBox();
            this.hScrollBar_wydajnosc = new System.Windows.Forms.HScrollBar();
            this.groupBox_dane_serwera = new System.Windows.Forms.GroupBox();
            this.button_serwer_usun = new System.Windows.Forms.Button();
            this.button_serwer_zapisz = new System.Windows.Forms.Button();
            this.label_haslo_serwer = new System.Windows.Forms.Label();
            this.label_login_serwer = new System.Windows.Forms.Label();
            this.label_adres_serwera = new System.Windows.Forms.Label();
            this.label_nazwa_serwera = new System.Windows.Forms.Label();
            this.comboBox_serwer = new System.Windows.Forms.ComboBox();
            this.textBox_serwer_haslo = new System.Windows.Forms.TextBox();
            this.textBox_serwer_login = new System.Windows.Forms.TextBox();
            this.textBox_serwer_adres = new System.Windows.Forms.TextBox();
            this.textBox_serwer_nazwa = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GBSymulacja.SuspendLayout();
            this.groupBox_dane_serwera.SuspendLayout();
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
            this.button_start_symulator.Click += new System.EventHandler(this.button_start_symulator_Click);
            // 
            // GBSymulacja
            // 
            this.GBSymulacja.Controls.Add(this.checkBox_symulacja);
            this.GBSymulacja.Controls.Add(this.button1);
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
            // checkBox_symulacja
            // 
            this.checkBox_symulacja.AutoSize = true;
            this.checkBox_symulacja.Enabled = false;
            this.checkBox_symulacja.Location = new System.Drawing.Point(7, 62);
            this.checkBox_symulacja.Name = "checkBox_symulacja";
            this.checkBox_symulacja.Size = new System.Drawing.Size(123, 24);
            this.checkBox_symulacja.TabIndex = 6;
            this.checkBox_symulacja.Text = "stan symulacji";
            this.checkBox_symulacja.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_stop_wydajnosc
            // 
            this.button_stop_wydajnosc.Location = new System.Drawing.Point(200, 88);
            this.button_stop_wydajnosc.Name = "button_stop_wydajnosc";
            this.button_stop_wydajnosc.Size = new System.Drawing.Size(190, 27);
            this.button_stop_wydajnosc.TabIndex = 4;
            this.button_stop_wydajnosc.Text = "Stop linii";
            this.button_stop_wydajnosc.UseVisualStyleBackColor = true;
            this.button_stop_wydajnosc.Click += new System.EventHandler(this.button_stop_wydajnosc_Click);
            // 
            // button_start_wydajnosc
            // 
            this.button_start_wydajnosc.Location = new System.Drawing.Point(6, 88);
            this.button_start_wydajnosc.Name = "button_start_wydajnosc";
            this.button_start_wydajnosc.Size = new System.Drawing.Size(190, 27);
            this.button_start_wydajnosc.TabIndex = 3;
            this.button_start_wydajnosc.Text = "Start linii";
            this.button_start_wydajnosc.UseVisualStyleBackColor = true;
            this.button_start_wydajnosc.Click += new System.EventHandler(this.button_start_wydajnosc_Click);
            // 
            // textBox_wydajnosc
            // 
            this.textBox_wydajnosc.Location = new System.Drawing.Point(0, 123);
            this.textBox_wydajnosc.Name = "textBox_wydajnosc";
            this.textBox_wydajnosc.Size = new System.Drawing.Size(392, 27);
            this.textBox_wydajnosc.TabIndex = 2;
            // 
            // hScrollBar_wydajnosc
            // 
            this.hScrollBar_wydajnosc.LargeChange = 3000;
            this.hScrollBar_wydajnosc.Location = new System.Drawing.Point(0, 153);
            this.hScrollBar_wydajnosc.Maximum = 33000;
            this.hScrollBar_wydajnosc.Name = "hScrollBar_wydajnosc";
            this.hScrollBar_wydajnosc.Size = new System.Drawing.Size(392, 24);
            this.hScrollBar_wydajnosc.TabIndex = 1;
            this.hScrollBar_wydajnosc.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_wydajnosc_Scroll);
            this.hScrollBar_wydajnosc.ValueChanged += new System.EventHandler(this.hScrollBar_wydajnosc_ValueChanged);
            // 
            // groupBox_dane_serwera
            // 
            this.groupBox_dane_serwera.Controls.Add(this.button_serwer_usun);
            this.groupBox_dane_serwera.Controls.Add(this.button_serwer_zapisz);
            this.groupBox_dane_serwera.Controls.Add(this.label_haslo_serwer);
            this.groupBox_dane_serwera.Controls.Add(this.label_login_serwer);
            this.groupBox_dane_serwera.Controls.Add(this.label_adres_serwera);
            this.groupBox_dane_serwera.Controls.Add(this.label_nazwa_serwera);
            this.groupBox_dane_serwera.Controls.Add(this.comboBox_serwer);
            this.groupBox_dane_serwera.Controls.Add(this.textBox_serwer_haslo);
            this.groupBox_dane_serwera.Controls.Add(this.textBox_serwer_login);
            this.groupBox_dane_serwera.Controls.Add(this.textBox_serwer_adres);
            this.groupBox_dane_serwera.Controls.Add(this.textBox_serwer_nazwa);
            this.groupBox_dane_serwera.Location = new System.Drawing.Point(411, 12);
            this.groupBox_dane_serwera.Name = "groupBox_dane_serwera";
            this.groupBox_dane_serwera.Size = new System.Drawing.Size(495, 426);
            this.groupBox_dane_serwera.TabIndex = 5;
            this.groupBox_dane_serwera.TabStop = false;
            this.groupBox_dane_serwera.Text = "Dane serwera";
            // 
            // button_serwer_usun
            // 
            this.button_serwer_usun.Location = new System.Drawing.Point(16, 193);
            this.button_serwer_usun.Name = "button_serwer_usun";
            this.button_serwer_usun.Size = new System.Drawing.Size(240, 29);
            this.button_serwer_usun.TabIndex = 10;
            this.button_serwer_usun.Text = "Usuń";
            this.button_serwer_usun.UseVisualStyleBackColor = true;
            this.button_serwer_usun.Click += new System.EventHandler(this.button_serwer_usun_Click);
            // 
            // button_serwer_zapisz
            // 
            this.button_serwer_zapisz.Location = new System.Drawing.Point(262, 193);
            this.button_serwer_zapisz.Name = "button_serwer_zapisz";
            this.button_serwer_zapisz.Size = new System.Drawing.Size(228, 29);
            this.button_serwer_zapisz.TabIndex = 9;
            this.button_serwer_zapisz.Text = "Zapisz";
            this.button_serwer_zapisz.UseVisualStyleBackColor = true;
            this.button_serwer_zapisz.Click += new System.EventHandler(this.button_serwer_zapisz_Click);
            // 
            // label_haslo_serwer
            // 
            this.label_haslo_serwer.AutoSize = true;
            this.label_haslo_serwer.Location = new System.Drawing.Point(7, 157);
            this.label_haslo_serwer.Name = "label_haslo_serwer";
            this.label_haslo_serwer.Size = new System.Drawing.Size(47, 20);
            this.label_haslo_serwer.TabIndex = 8;
            this.label_haslo_serwer.Text = "Hasło";
            // 
            // label_login_serwer
            // 
            this.label_login_serwer.AutoSize = true;
            this.label_login_serwer.Location = new System.Drawing.Point(6, 124);
            this.label_login_serwer.Name = "label_login_serwer";
            this.label_login_serwer.Size = new System.Drawing.Size(46, 20);
            this.label_login_serwer.TabIndex = 7;
            this.label_login_serwer.Text = "Login";
            // 
            // label_adres_serwera
            // 
            this.label_adres_serwera.AutoSize = true;
            this.label_adres_serwera.Location = new System.Drawing.Point(7, 91);
            this.label_adres_serwera.Name = "label_adres_serwera";
            this.label_adres_serwera.Size = new System.Drawing.Size(102, 20);
            this.label_adres_serwera.TabIndex = 6;
            this.label_adres_serwera.Text = "Adres serwera";
            // 
            // label_nazwa_serwera
            // 
            this.label_nazwa_serwera.AutoSize = true;
            this.label_nazwa_serwera.Location = new System.Drawing.Point(7, 58);
            this.label_nazwa_serwera.Name = "label_nazwa_serwera";
            this.label_nazwa_serwera.Size = new System.Drawing.Size(112, 20);
            this.label_nazwa_serwera.TabIndex = 5;
            this.label_nazwa_serwera.Text = "Nazwa serwera:";
            // 
            // comboBox_serwer
            // 
            this.comboBox_serwer.FormattingEnabled = true;
            this.comboBox_serwer.Location = new System.Drawing.Point(6, 27);
            this.comboBox_serwer.Name = "comboBox_serwer";
            this.comboBox_serwer.Size = new System.Drawing.Size(484, 28);
            this.comboBox_serwer.TabIndex = 4;
            this.comboBox_serwer.SelectedIndexChanged += new System.EventHandler(this.comboBox_serwer_SelectedIndexChanged);
            // 
            // textBox_serwer_haslo
            // 
            this.textBox_serwer_haslo.Location = new System.Drawing.Point(125, 160);
            this.textBox_serwer_haslo.Name = "textBox_serwer_haslo";
            this.textBox_serwer_haslo.PasswordChar = '*';
            this.textBox_serwer_haslo.Size = new System.Drawing.Size(365, 27);
            this.textBox_serwer_haslo.TabIndex = 3;
            // 
            // textBox_serwer_login
            // 
            this.textBox_serwer_login.Location = new System.Drawing.Point(125, 127);
            this.textBox_serwer_login.Name = "textBox_serwer_login";
            this.textBox_serwer_login.Size = new System.Drawing.Size(365, 27);
            this.textBox_serwer_login.TabIndex = 2;
            // 
            // textBox_serwer_adres
            // 
            this.textBox_serwer_adres.Location = new System.Drawing.Point(125, 94);
            this.textBox_serwer_adres.Name = "textBox_serwer_adres";
            this.textBox_serwer_adres.Size = new System.Drawing.Size(365, 27);
            this.textBox_serwer_adres.TabIndex = 1;
            // 
            // textBox_serwer_nazwa
            // 
            this.textBox_serwer_nazwa.Location = new System.Drawing.Point(125, 61);
            this.textBox_serwer_nazwa.Name = "textBox_serwer_nazwa";
            this.textBox_serwer_nazwa.Size = new System.Drawing.Size(365, 27);
            this.textBox_serwer_nazwa.TabIndex = 0;
            // 
            // Symulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 714);
            this.Controls.Add(this.groupBox_dane_serwera);
            this.Controls.Add(this.GBSymulacja);
            this.Name = "Symulator";
            this.Text = "Symulator ";
            this.Load += new System.EventHandler(this.Symulator_Load);
            this.GBSymulacja.ResumeLayout(false);
            this.GBSymulacja.PerformLayout();
            this.groupBox_dane_serwera.ResumeLayout(false);
            this.groupBox_dane_serwera.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_haslo_serwer;
        private System.Windows.Forms.Label label_login_serwer;
        private System.Windows.Forms.Label label_adres_serwera;
        private System.Windows.Forms.Label label_nazwa_serwera;
        private System.Windows.Forms.ComboBox comboBox_serwer;
        private System.Windows.Forms.TextBox textBox_serwer_haslo;
        private System.Windows.Forms.TextBox textBox_serwer_login;
        private System.Windows.Forms.TextBox textBox_serwer_adres;
        private System.Windows.Forms.TextBox textBox_serwer_nazwa;
        private System.Windows.Forms.Button button_serwer_usun;
        private System.Windows.Forms.Button button_serwer_zapisz;
        private System.Windows.Forms.CheckBox checkBox_symulacja;
    }
}

