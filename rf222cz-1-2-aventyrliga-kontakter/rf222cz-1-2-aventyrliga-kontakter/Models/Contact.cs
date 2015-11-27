using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace rf222cz_1_2_aventyrliga_kontakter.Models
{
    [MetadataType(typeof(Contact_Metadata))]
    public partial class Contact
    {
        //public int ContactID { get; set; }
        //public int EmailAddress { get; set; }
        //public int FirstName { get; set; }
        //public int LastName { get; set; }

        private class Contact_Metadata
        {
            public int ContactID { get; set; }

            [Required(ErrorMessage = "Firstname cannot be empty.")]
            //[DisplayName("Firstname")]
            public int FirstName { get; set; }

            [Required(ErrorMessage = "Lastname cannot be empty.")]
            //[DisplayName("Lastname")]
            public int LastName { get; set; }

            [Required(ErrorMessage = "EmailAddress cannot be empty.")]
            //[DisplayName("EmailAdress")]
            public int EmailAddress { get; set; }

        }
    }
}