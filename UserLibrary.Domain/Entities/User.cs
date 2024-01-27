﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Domain.Entities;

#nullable disable


// <Auto-Generated>
// This is here so CodeMaid doesn't reorganize this document
// </Auto-Generated>

namespace UserLibrary.Domain.Entities
{
    /// <summary>
    /// Persisted user entity
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Full name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Suite
        /// </summary>
        public string Suite { get; set; }
        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Company id (FK relation)
        /// </summary>
        public int? CompanyId { get; set; }
        /// <summary>
        /// Access property for related company
        /// </summary>
        public virtual Company Company { get; set; }
    }
}