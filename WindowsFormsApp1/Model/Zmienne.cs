using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SymulatroLinii.Model
{
    public class Zmienne
    {
        public bool symulacjaONOFF { get; set; }

    }
    public class DbTempTable 
    {
        [Key]
        public DateTime Time_Stamp { get; set; } = DateTime.Now;
        public int L_Opakowan { get; set; } = 0;
        public float Wydajnosc { get; set; } = 0;
        public int L_OpAplikator { get; set; } = 0;
        public int WydajnoscAplikator { get; set; } = 0;
        public  int FilTrybCIP { get; set; } = 0;
        public int FilRezerwa1 { get; set; } = 0;
        public int FilRezerwa2 { get; set; } = 0;
        public int FilRezerwa3 { get; set; } = 0;
        public int FilSterylizacja { get; set; } = 0;
        public int FilReadyProd { get; set; } = 0;
        public int FilRun { get; set; } = 0;
        public int FilRezerwa4 { get; set; } = 0;
        public int ErrorCode1 { get; set; } = 0;
        public int ErrorCode2 { get; set; } = 0;
        public int Nr_lini { get; set; } = 0;
        public int MaxWydajnosc { get; set; } = 0;
        public int Time_Stamp_ms { get; set; } = 0;
        public int Bias { get; set; } = 0;

        

        public class DbTempTableNotifyPropretyChange : INotifyPropertyChanged
        {
            public DateTime _time_Stamp;
            public int _l_Opakowan;
            public float _wydajnosc;
            public int _nr_lini;

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string proprtyName)
            {
                if (PropertyChanged != null)
                {
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(proprtyName));
                    }
                }
            }
        }
    }
}
