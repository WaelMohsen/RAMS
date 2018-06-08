using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OpenIdTester
{
    [Serializable]
    public class User
    {
        public string Email
        { get; set; }
        public bool ISApproved
        {
            get; set;
        }
        public DateTime LastLoginDate
        {
            get; set;
        }
        public DateTime LastActivityDate
        {
            get; set;
        }

        public long Id
        { get; set; }
        /// <summary>
        /// Gets or Sets the FirstName property.
        /// </summary>
        public string FirstName
        { get; set; }
        /// <summary>
        /// Gets or Sets the identifier property.
        /// </summary>
        public string SecondName
        { get; set; }
        /// <summary>
        /// Gets or Sets the ThirdName property.
        /// </summary>
        public string ThirdName
        { get; set; }

        /// <summary>
        /// Gets or Sets the FourthName property.
        /// </summary>
        public string FourthName
        { get; set; }
        /// <summary>
        /// Gets or Sets the Nationality property.
        /// </summary>
        public short? Nationality
        { get; set; }
        /// <summary>
        /// Gets or Sets the Gender property
        /// </summary>
        public string Gender
        { get; set; }

        /// <summary>
        /// Gets or sets the gender description.
        /// </summary>
        /// <value>The gender description.</value>
        public string GenderDescription
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the gender id.
        /// </summary>
        /// <value>The gender id.</value>
        public int? GenderId
        { get; set; }

        /// <summary>
        /// Gets or Sets the MaritalStatus property
        /// </summary>
        public string MaritalStatus
        { get; set; }

        /// <summary>
        /// Gets or sets the marital status description.
        /// </summary>
        /// <value>The marital status description.</value>
        public string MaritalStatusDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the marital status id.
        /// </summary>
        /// <value>The marital status id.</value>
        public int? MaritalStatusId
        { get; set; }

        /// <summary>
        /// Gets or Sets the BirthDate property.
        /// </summary>
        public DateTime? BirthDate
        { get; set; }

        /// <summary>
        /// Gets or Sets the PlaceOfBirth property.
        /// </summary>
        public string PlaceOfBirth
        { get; set; }

        /// <summary>
        /// Gets or Sets the IDNumber property.
        /// </summary>
        public long? IdNumber
        { get; set; }
        /// <summary>
        /// Gets or Sets the IDExpiryDate property.
        /// </summary>
        public DateTime? IdExpiryDate
        { get; set; }
        public string MobileNumber
        { get; set; }

        /// <summary>
        /// Gets or sets the FK_ labor office id.
        /// </summary>
        /// <value>The FK_ labor office id.</value>

        public int? EstablishmentLaborOfficeId
        { get; set; }
        public long? EstablishmentSequanceNumber
        { get; set; }
        public long? EstablishmentId
        { get; set; }
        public string EstablishmentName
        { get; set; }
        public string Area
        { get; set; }

    }
}