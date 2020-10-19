using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using static SymulatroLinii.Model.DbSerwerSQLite;

namespace SymulatroLinii.Repository.Irepository
{
    public interface IDbSerwerSQLiteRepository : IDisposable
    {
        public void Insert();
        public void Delete(string nazwa);

        public List<DbSerwer> GetAll();


  

    }
}
