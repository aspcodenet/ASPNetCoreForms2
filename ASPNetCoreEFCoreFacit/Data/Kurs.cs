using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreEFCoreFacit.Data
{
    public class Kurs
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Namn { get; set; }
        [MaxLength(512)]
        public string Beskrivning { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime StartDay { get; set; } // Date

        //        id, namn, created(datetime), lastmodified(datetime), startday(datetime - fast dag), beskrivning(512 tecken), foreläsnings-veckodag(ex måndag eller fredag)
    }
}