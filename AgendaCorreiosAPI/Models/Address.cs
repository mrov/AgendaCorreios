using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string CEP {get; set;}
        public string Street { get; set;}
        public string City { get; set;}
        public string State { get; set;}
        public string Number { get; set;}
        public string Complement { get; set;}
        public string Neighborhood { get; set;}
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
