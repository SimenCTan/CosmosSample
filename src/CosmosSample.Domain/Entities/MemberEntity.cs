using System.ComponentModel.DataAnnotations;
using CosmosSample.Domain.Entities.Abstract;

namespace CosmosSample.Domain.Entities
{
    public class MemberEntity : EntityBase
    {
        public string Email { get; set; } = default!;

        [StringLength(64, MinimumLength = 6)]
        public string Password { get; set; } = default!;

        /// <summary>
        /// Mobile
        /// </summary>
        [StringLength(50, MinimumLength = 5)]
        public string Mobile { get; set; } = default!;

        public string FullName => $"{FirstName} {LastName}";

        [StringLength(50)]
        public string FirstName { get; set; } = default!;

        [StringLength(50)]
        public string LastName { get; set; } = default!;

        public byte Sex { get; set; }

        public Address? Address { get; set; }
    }

    public class Address
    {
        public string Country { get; set; } = string.Empty;

        [StringLength(50)]
        public string Province { get; set; } = string.Empty;

        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [StringLength(512)]
        public string AddressDetail { get; set; } = string.Empty;
    }
}
