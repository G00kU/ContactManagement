﻿using System.Diagnostics.Metrics;

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

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Gender { get; set; }

    }
}
