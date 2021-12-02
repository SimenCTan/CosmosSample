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

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code of the document identifier.</returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// Implements equality.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>A value indicating whether the unique identifiers match.</returns>
        public override bool Equals(object? obj) => obj is MemberEntity ds && ds.Email == Email;

        /// <summary>
        /// Gets the string representation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString() => $"member fullname {FullName} has email {Email}";
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
