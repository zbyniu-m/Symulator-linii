﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SymulatroLinii.Model
{
    class DbSerwerSQLite
    {
        public class DbSerwerContext : DbContext
    {
        public DbSet<DbSerwer> DbSerwers { get; set; }  

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=myBase.db");
    }

    public class DbSerwer
    {
        [Key]
        public string Nazwa { get; set; }
        public string Adres { get; set; }
        public string Login { get; set; }

        public string Haslo { get; set; }
    }
}
}
