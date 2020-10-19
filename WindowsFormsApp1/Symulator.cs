using SymulatroLinii.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
