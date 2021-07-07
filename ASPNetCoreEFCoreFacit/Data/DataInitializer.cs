using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreEFCoreFacit.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();

            SeedKurser(dbContext);
            SeedCountries(dbContext);
            SeedUtbildningar(dbContext);

            SeedManufacturers(dbContext);
            SeedBilar(dbContext);
            SeedLastbilar(dbContext);
            FixManufacturersForBilAndLastbil(dbContext);
        }

        private static void SeedKurser(ApplicationDbContext dbContext)
        {
            if (!dbContext.Kurser.Any(r => r.Namn == "C#"))
                dbContext.Kurser.Add(new Kurs
                {
                    Namn = "C#", Beskrivning = "12",
                    Created = DateTime.UtcNow,
                    DayOfWeek = DayOfWeek.Monday,
                    LastModified = DateTime.UtcNow,
                    StartDay = DateTime.UtcNow.AddDays(40)
                });
            dbContext.SaveChanges();
        }

        private static void SeedUtbildningar(ApplicationDbContext dbContext)
        {
            if (!dbContext.Utbildningar.Any(r => r.Namn == "Högskoleutbildning"))
                dbContext.Utbildningar.Add(new Utbildning{ Namn = "Högskoleutbildning" });
            if (!dbContext.Utbildningar.Any(r => r.Namn == "Yrkeshögskola"))
                dbContext.Utbildningar.Add(new Utbildning { Namn = "Yrkeshögskola" });
            if (!dbContext.Utbildningar.Any(r => r.Namn == "Gymnasial utbildning"))
                dbContext.Utbildningar.Add(new Utbildning { Namn = "Gymnasial utbildning" });
            dbContext.SaveChanges();
        }

        private static void SeedCountries(ApplicationDbContext dbContext)
        {
            if(!dbContext.Countries.Any(r=>r.Namn == "Sverige"))
                dbContext.Countries.Add(new Country {Namn= "Sverige" });
            if (!dbContext.Countries.Any(r => r.Namn == "Danmark"))
                dbContext.Countries.Add(new Country { Namn = "Danmark" });
            if (!dbContext.Countries.Any(r => r.Namn == "Norge"))
                dbContext.Countries.Add(new Country { Namn = "Norge" });
            dbContext.SaveChanges();
        }

        static void FixManufacturersForBilAndLastbil(ApplicationDbContext dbContext)
        {
            var volvo = dbContext.Manufacturers.First(r => r.Namn == "Volvo");
            var scania = dbContext.Manufacturers.First(r => r.Namn == "Scania");
            dbContext.Lastbilar.First(r => r.RegNo == "BBB111").Manufacturer = volvo;
            dbContext.Lastbilar.First(r => r.RegNo == "RBB111").Manufacturer = volvo;
            dbContext.Lastbilar.First(r => r.RegNo == "CBB111").Manufacturer = scania;

            var saab = dbContext.Manufacturers.First(r => r.Namn == "Saab");
            dbContext.Bilar.First(r => r.RegNo == "AAA115").Manufacturer = saab;
            dbContext.Bilar.First(r => r.RegNo == "AAA114").Manufacturer = saab;


            dbContext.Bilar.First(r => r.RegNo == "AAA113").Manufacturer = saab;
            dbContext.Bilar.First(r => r.RegNo == "AAA112").Manufacturer = volvo;
            dbContext.Bilar.First(r => r.RegNo == "QAA111").Manufacturer = volvo;
            dbContext.Bilar.First(r => r.RegNo == "DAA111").Manufacturer = volvo;
            
            dbContext.SaveChanges();
        }

        private static void SeedManufacturers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Manufacturers.Any(r => r.Namn == "Scania"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "Scania",
                });
            }
            if (!dbContext.Manufacturers.Any(r => r.Namn == "Saab"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "Saab",
                });
            }
            if (!dbContext.Manufacturers.Any(r => r.Namn == "Volvo"))
            {
                dbContext.Manufacturers.Add(new Manufacturer()
                {
                    Namn = "Volvo",
                });
            }

            dbContext.SaveChanges();
        }

        private static void SeedLastbilar(ApplicationDbContext dbContext)
        {
            var volvo = dbContext.Manufacturers.First(r => r.Namn == "Volvo");
            var scania = dbContext.Manufacturers.First(r => r.Namn == "Scania");
            if (!dbContext.Lastbilar.Any(r => r.RegNo == "BBB111"))
            {
                dbContext.Lastbilar.Add(new Lastbil()
                {
                    Manufacturer = volvo,
                    RegNo = "BBB111",
                    LoadVolumeKvm = 12
                });
            }
            if (!dbContext.Lastbilar.Any(r => r.RegNo == "RBB111"))
            {
                dbContext.Lastbilar.Add(new Lastbil()
                {
                    Manufacturer = volvo,
                    RegNo = "RBB111",
                    LoadVolumeKvm = 11
                });
            }
            if (!dbContext.Lastbilar.Any(r => r.RegNo == "CBB111"))
            {
                dbContext.Lastbilar.Add(new Lastbil()
                {
                    Manufacturer = scania,
                    RegNo = "CBB111",
                    LoadVolumeKvm = 121
                });
            }

            dbContext.SaveChanges();
        }

        private static void SeedBilar(ApplicationDbContext dbContext)
        {
            var volvo = dbContext.Manufacturers.First(r => r.Namn == "Volvo");
            var saab = dbContext.Manufacturers.First(r => r.Namn == "Saab");
            if (!dbContext.Bilar.Any(r=>r.RegNo == "QAA111"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    HasRadio = true, Manufacturer = volvo, Model = "XC60",
                    Price = 12000, RegNo = "QAA111", Year = 2015
                });
            }

            if (!dbContext.Bilar.Any(r => r.RegNo == "AAA112"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    HasRadio = true,
                    Manufacturer = volvo,
                    Model = "XC70",
                    Price = 1000,
                    RegNo = "AAA112",
                    Year = 2014
                });
            }

            if (!dbContext.Bilar.Any(r => r.RegNo == "AAA113"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    HasRadio = true,
                    Manufacturer = saab,
                    Model = "V4",
                    Price = 1000,
                    RegNo = "AAA113",
                    Year = 1973
                });
            }


            if (!dbContext.Bilar.Any(r => r.RegNo == "AAA114"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    HasRadio = true,
                    Manufacturer = saab,
                    Model = "V4",
                    Price = 1200,
                    RegNo = "AAA114",
                    Year = 1974
                });
            }

            if (!dbContext.Bilar.Any(r => r.RegNo == "AAA115"))
            {
                dbContext.Bilar.Add(new Bil
                {
                    HasRadio = true,
                    Manufacturer = saab,
                    Model = "V4",
                    Price = 12200,
                    RegNo = "AAA115",
                    Year = 1975
                });
            }

            dbContext.SaveChanges();



        }
    }
}