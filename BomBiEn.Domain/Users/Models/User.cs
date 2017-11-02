using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using BomBiEn.Infrastructure.Domain;
using BomBiEn.Infrastructure.Identity.MongoDb;
using BomBiEn.Shared.Enums;

namespace BomBiEn.Domain.Users.Models
{
    [BsonIgnoreExtraElements]
    public class User : IdentityUser<string>, IAggregateRoot
    {
        public User()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// User type
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public UserType UserType { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public GenderType Gender { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName
        {
            get
            {
                if (String.IsNullOrEmpty(MiddleName))
                {
                    return String.Format("{0} {1}", FirstName, LastName);
                }

                return String.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            }
        }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Preferred language
        /// </summary>
        public string PreferredLanguage { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Photo
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Agency id
        /// </summary>
        public string AgencyId { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [BsonRepresentation(BsonType.String)]
        public UserStatus Status { get; set; }

        /// <summary>
        /// Payment profiles
        /// </summary>
        public ICollection<UserPaymentProfile> PaymentProfiles { get; set; }

        /// <summary>
        /// App tokens
        /// </summary>
        public ICollection<UserAppToken> AppTokens { get; set; }

        /// <summary>
        /// Id from ExactOnline
        /// </summary>
        public string IdExactOnline { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsValidAccount()
        {
            if (UserType == UserType.Guest)
            {
                return false;
            }

            if (Status != UserStatus.Approved)
            {
                return false;
            }

            return true;
        }
    }
}