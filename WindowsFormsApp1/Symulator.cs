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
            
            textBox_wydajnosc.DataBindings.Add("Text", _dbTempTable, "Wydajnosc", true, DataSourceUpdateMode.OnPropertyChanged);
            hScrollBar_wydajnosc.DataBindings.Add("Value", _dbTempTable, "Wydajnosc", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button_start_wydajnosc_Click(object sender, EventArgs e)
        {            
            textBox_wydajnosc.Text = "30000";
        }

        private void button_stop_wydajnosc_Click(object sender, EventArgs e)
        {            
            textBox_wydajnosc.Text = "0";
        }

        private void hScrollBar_wydajnosc_Scroll(object sender, ScrollEventArgs e)
        {
            _dbTempTable.Wydajnosc = hScrollBar_wydajnosc.Value;
            if (hScrollBar_wydajnosc.Value > 0)
                _dbTempTable.FilRun = 1;
            else
                _dbTempTable.FilRun = 0;
        }
    }
}
