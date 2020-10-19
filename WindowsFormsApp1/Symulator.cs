using SymulatroLinii.Model;
using SymulatroLinii.Repository;
using SymulatroLinii.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SymulatroLinii.Model.DbSerwerSQLite;

namespace WindowsFormsApp1
{
    public partial class Symulator : Form
    {
        Zmienne _zmienne { get; set; } = new Zmienne();
        DbTempTable _dbTempTable { get; set; } = new DbTempTable();
        public Symulator()
        {
            InitializeComponent();
            checkBox_symulacja.DataBindings.Add("Checked", _zmienne, "symulacjaONOFF", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox_wydajnosc.DataBindings.Add("Text", _dbTempTable, "Wydajnosc", true, DataSourceUpdateMode.OnPropertyChanged);
            hScrollBar_wydajnosc.DataBindings.Add("Value", _dbTempTable, "Wydajnosc", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button_start_wydajnosc_Click(object sender, EventArgs e)
        {
            int maxWydajnosc = hScrollBar_wydajnosc.Maximum - hScrollBar_wydajnosc.LargeChange;
            textBox_wydajnosc.Text = maxWydajnosc.ToString();
        }

        private void button_stop_wydajnosc_Click(object sender, EventArgs e)
        {            
            textBox_wydajnosc.Text = hScrollBar_wydajnosc.Minimum.ToString();
        }

        private void hScrollBar_wydajnosc_Scroll(object sender, ScrollEventArgs e)
        {
            _dbTempTable.Wydajnosc = hScrollBar_wydajnosc.Value;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_dbTempTable.Wydajnosc + " " + _dbTempTable.FilRun + " " + _dbTempTable.Time_Stamp + " " + _zmienne.symulacjaONOFF);
        }

        private void hScrollBar_wydajnosc_ValueChanged(object sender, EventArgs e)
        {
            if (hScrollBar_wydajnosc.Value > 0)
                _dbTempTable.FilRun = 1;
            else
                _dbTempTable.FilRun = 0;
        }

        private void button_start_symulator_Click(object sender, EventArgs e)
        {
            checkBox_symulacja.Checked = !checkBox_symulacja.Checked;
            if (!checkBox_symulacja.Checked)
                button_start_symulator.Text = "Start symulacji";
            else
                button_start_symulator.Text = "Stop symulacji";

        }

        private void Symulator_Load(object sender, EventArgs e)
        {

            ZaczytajDaneDoComboboxa();
        }

        private void button_serwer_zapisz_Click(object sender, EventArgs e)
        {
            if(SerwerCzyNieMaPustychPol())
            {
                var daneSerwera = new DbSerwer();
                daneSerwera.Nazwa = textBox_serwer_nazwa.Text;
                daneSerwera.Adres = textBox_serwer_adres.Text;
                daneSerwera.Login = textBox_serwer_login.Text;
                daneSerwera.Haslo = textBox_serwer_haslo.Text;

                using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
                {
                     sqlite.Insert(daneSerwera);             

                }
                
                ZaczytajDaneDoComboboxa();
            }
        }

        bool SerwerCzyNieMaPustychPol()
        {
            var result = false;
            if (textBox_serwer_nazwa.Text != "" && textBox_serwer_adres.Text != "" && textBox_serwer_login.Text !="" && textBox_serwer_haslo.Text !="" )
            {
                result = true;
            }
            return result;
        }

        private void ZaczytajDaneDoComboboxa()
        {
            comboBox_serwer.Items.Clear();
            using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
            {
                var nazwy = sqlite.GetAllColumnNazwa();
                foreach (string nazwa in nazwy)
                {
                    comboBox_serwer.Items.Add(nazwa);
                }

            }
        }

        private void button_serwer_usun_Click(object sender, EventArgs e)
        {
            using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
            {
                sqlite.Delete(comboBox_serwer.Text);
                ZaczytajDaneDoComboboxa();
                wyczyscPolaDaneSerwera();
            }
        }

        private void comboBox_serwer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var daneSerwera = new DbSerwer();
            using (DbSerwerSQLiteRepository sqlite = new DbSerwerSQLiteRepository())
            {                
                daneSerwera= sqlite.GetDbSerwer(comboBox_serwer.Text);
            }
            if(daneSerwera != null) { 
            textBox_serwer_adres.Text = daneSerwera.Adres;
            textBox_serwer_haslo.Text = daneSerwera.Haslo;
            textBox_serwer_nazwa.Text = daneSerwera.Nazwa;
            textBox_serwer_login.Text = daneSerwera.Login;
            }
            else
            {
                wyczyscPolaDaneSerwera();
            }
        }
        private void wyczyscPolaDaneSerwera()
        {
            textBox_serwer_adres.Text = "";
            textBox_serwer_haslo.Text = "";
            textBox_serwer_nazwa.Text = "";
            textBox_serwer_login.Text = "";
            comboBox_serwer.Text = "";
        }
    }
}
