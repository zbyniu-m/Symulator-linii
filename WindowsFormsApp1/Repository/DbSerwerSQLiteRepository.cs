using SymulatroLinii.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Text;
using static SymulatroLinii.Model.DbSerwerSQLite;

namespace SymulatroLinii.Repository
{
    public class DbSerwerSQLiteRepository : IDbSerwerSQLiteRepository
    {
        DbSerwerContext db = new DbSerwerContext();

        public void Delete(string Nazwa)
        {
            db.Remove(Nazwa);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<DbSerwer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

   
    }
}
