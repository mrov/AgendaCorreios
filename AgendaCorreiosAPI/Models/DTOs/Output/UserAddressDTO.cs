namespace Models.DTOs.Output
{
    public class UserAddressDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public DateTime BirthDay { get; set; }
        public AddressDTO Address { get; set; }
    }

    public class AddressDTO
    {
        public int Id { get; set; }
        public string CEP { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
    }
}
