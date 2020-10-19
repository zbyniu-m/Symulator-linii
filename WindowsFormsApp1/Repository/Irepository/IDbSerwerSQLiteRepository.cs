using System;
using System.Collections.Generic;
using System.Text;
using static SymulatroLinii.Model.DbSerwerSQLite;

namespace SymulatroLinii.Repository.Irepository
{
    public interface IDbSerwerSQLiteRepository:IDisposable
    {
        public void Delete(string Nazwa);
        public bool Insert(DbSerwer entity);

        public List<DbSerwer> GetAll();
        public List<string> GetAllColumnNazwa();


    }
}
