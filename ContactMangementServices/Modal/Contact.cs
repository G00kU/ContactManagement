using System.Diagnostics.Metrics;

namespace ContactMangementServices.Modal
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }

        public int StateId { get; set; }

        public int CountryId { get; set; }

        public string PostalCode { get; set; }

        public City City { get; set; }

        public State State { get; set; }

        public Country Country { get; set; }
    }
    public class Country
    {
        public int CountryId { get; set; }

        public string Name { get; set; }
    }

    public class State
    {
        public int StateId { get; set; }

        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class City
    {
        public int CityId { get; set; }

        public string Name { get; set; }
        public int StateId { get; set; }


        public State State { get; set; }
    }
}
