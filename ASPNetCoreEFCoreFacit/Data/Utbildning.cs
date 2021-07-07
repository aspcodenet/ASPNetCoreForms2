using System.Collections.Generic;

namespace ASPNetCoreEFCoreFacit.Data
{
    public class Utbildning
    {
        public int Id { get; set; }
        
        public string Namn { get; set; }

        public List<CV> Cvs { get; set; }
    }
}