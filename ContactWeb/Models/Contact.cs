using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactWeb.Models
{
    public class Contact         // contact object with each property 
    {
        public int id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhonePrimary { get; set; }
        public string PhoneSecondary { get; set; }
        public DateTime Birthday { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }


    }
}