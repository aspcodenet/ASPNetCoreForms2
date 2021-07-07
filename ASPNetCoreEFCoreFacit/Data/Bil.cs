using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreEFCoreFacit.Data
{
    public class Bil
    {
        public int Id { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [MaxLength(20)]
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public bool HasRadio { get; set; }

        [MaxLength(6)]
        public string RegNo { get; set; }



        public DateTime FirstSalesDate { get; set; } //Dag och tid!
        public string Email { get; set; }
        public DateTime BirthForOwnerDate { get; set; } //Dag
    }
}