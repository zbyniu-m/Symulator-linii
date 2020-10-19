using Microsoft.EntityFrameworkCore;
using SymulatroLinii.Repository;
using SymulatroLinii.Repository.Irepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SymulatroLinii.Model.DbSerwerSQLite;

namespace SymulatroLinii.Repository
{
    public class DbSerwerSQLiteRepository : IDbSerwerSQLiteRepository
    {
        
        public void Delete(string Nazwa)
        {
            using (DbSerwerContext db = new DbSerwerContext())
            {

                var ObjFromDb = db.DbSerwers.FirstOrDefault(Q => Q.Nazwa == Nazwa);
                if (ObjFromDb != null)
                {
                    db.DbSerwers.Remove(ObjFromDb);
                    db.SaveChanges();
                }                
            }
        }

        public void Dispose()
        {
            using (DbSerwerContext db = new DbSerwerContext())
            {
                db.Dispose();
            }
        }

        public List<DbSerwer> GetAll()
        {
            List<DbSerwer> lists = new List<DbSerwer>();
            using (DbSerwerContext db = new DbSerwerContext())
            {                
                lists = db.DbSerwers.ToList();
            }
            return lists;
        }

        public List<string> GetAllColumnNazwa()
        {
            var nazwa = new List<string>();
            //nazwa.Add("dodaj nowy");
            using (DbSerwerContext db = new DbSerwerContext())
            {
                db.Database.Migrate();
                System.Diagnostics.Debug.WriteLine(db.Database.ProviderName);
                int ilosc = db.DbSerwers.Select(c => c.Nazwa).Count();
                if (ilosc > 0) { 
                nazwa = db.DbSerwers
                    .Select(c => c.Nazwa)
                    .ToList();
                }
            }
            return nazwa;
        }

        public bool Insert(DbSerwer entity)
        {
            bool result = false;
            try
            {
                using(DbSerwerContext db = new DbSerwerContext())
                {
                    var ObjFromDb = db.DbSerwers.FirstOrDefault(Q => Q.Nazwa == entity.Nazwa);
                    if (ObjFromDb != null)
                    {
                        ObjFromDb.Nazwa = entity.Nazwa;
                        ObjFromDb.Login = entity.Login;
                        ObjFromDb.Adres = entity.Adres;
                        ObjFromDb.Haslo = entity.Haslo;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Add(entity);
                        db.SaveChanges();
                        result = true;
                    }
              
                }
            }
            catch (Exception)
            {
                throw;
            }            
            
            return result;
        }

        public DbSerwer GetDbSerwer(string nazwa)
        {
            var daneSerwera = new DbSerwer();
            using (DbSerwerContext db = new DbSerwerContext())
            {
                 daneSerwera = db.DbSerwers.FirstOrDefault(q => q.Nazwa == nazwa);
            }
            return daneSerwera;
        }
     
    }
}
