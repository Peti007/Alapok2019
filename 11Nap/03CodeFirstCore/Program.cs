using _03CodeFirstCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CodeFirstCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.\\SQLEXPRESS;Database=CodeFirstDB;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CodeFirstContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var db = new CodeFirstContext(optionsBuilder.Options);


            db.Database.Migrate();
            if (db.Teacher.Count() == 0)
            {// adatok ellenőrzése
                Seed(db);
            }

           

            Console.WriteLine($"A tanárok száma: {db.Teacher.Count()}, tantárgyak száma: {db.Subject.Count()}");

            Console.ReadLine();
        }

        private static void Seed(CodeFirstContext db)
        {
            var subjects = new List<Subject>();

            subjects.Add(new Subject() { Name = "Matek" });
            subjects.Add(new Subject() { Name = "Fizika" });

            db.Teacher.Add(new Teacher() { Name = "Matektanár", Subject = subjects });
            db.SaveChanges();
        }
    }
}
