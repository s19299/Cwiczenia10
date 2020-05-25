using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wyklad10Sample.Models;

namespace MEDICAL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            seed();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });


        static void seed()
        {
            
            var db = new s19299DbContext();

            var p1 = new Prescription()
            {
                Date = DateTime.Now,
                DueDate = DateTime.Now,
                IdPatient = 2
            };
            var set1 = new HashSet<Prescription> { p1 };

            var d1 = new Doctor
            {
                FirstName ="Kamil",
                LastName ="Bednarski",
                Email ="bednar@wp.pl",
                Prescription = set1
            };

            var p2 = new Prescription()
            {
                Date = DateTime.Today,
                DueDate = DateTime.Now,
                IdPatient = 3,
            };
            
            var set2 = new HashSet<Prescription>{p2};

            var d2 = new Doctor
            {
                FirstName = "Herbert",
                LastName = "Daca",
                Email = "drdaca@wp.pl",
                Prescription = set2
            };

            db.Doctor.Add(d2);
            db.Doctor.Add(d1);

            db.SaveChanges();
        }
    }
}