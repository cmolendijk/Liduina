using System.ComponentModel.DataAnnotations;

namespace HangoverApp.DL.Models.Profile
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public short Type { get; set; }

        [MaxLength(250), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(25), DataType(DataType.Text)]
        public string FirstName { get; set; }

        [MaxLength(25), DataType(DataType.Text)]
        public string MiddleName { get; set; }

        [MaxLength(25), DataType(DataType.Text)]
        public string LastName { get; set; }

        [MaxLength(250), DataType(DataType.Text)]
        public string AddressLine { get; set; }

        [MaxLength(6), DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [MaxLength(100), DataType(DataType.Text)]
        public string City { get; set; }

        [MaxLength(100), DataType(DataType.Text)]
        public string Country { get; set; }

        [MaxLength(500), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [MaxLength(100), DataType(DataType.Text)]
        public string PhotoIdentifier { get; set; }
    }
}