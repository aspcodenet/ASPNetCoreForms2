using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreEFCoreFacit.Data
{
    public class CV
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public bool Bil { get; set; }
        public bool Korkort { get; set; }
        [MaxLength(50)]
        public string Postort { get; set; }

        [MaxLength(10)]
        public string Postnr { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        [MaxLength(20)]
        public string Mobil { get; set; }
        [MaxLength(50)]
        public string Namn { get; set; }

        public PossibleWorkLocation PossibleWorkLocation { get; set; }

        public List<Utbildning> Utbildningar { get; set; }

    }
}