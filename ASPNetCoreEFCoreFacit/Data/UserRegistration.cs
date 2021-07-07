using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreEFCoreFacit.Data
{
    public class UserRegistration
    {
        public int Id { get; set; }

        public bool OkUpdates { get; set; }

        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string Last { get; set; }

        [MaxLength(100)]
        public string First { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }


        public Usertype UserType { get; set; }

        public Country Country { get; set; }

    }

    public class Country
    {
        public int Id { get; set; }
        public string Namn { get; set; }

    }
}