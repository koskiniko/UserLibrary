﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

// <Auto-Generated>
// This is here so CodeMaid doesn't reorganize this document
// </Auto-Generated>

namespace UserLibrary.Domain.Entities
{
    /// <summary>
    /// Common columns for all entities
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Surrogate key
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        /// <summary>
        /// Modification date
        /// </summary>
        public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;
    }
}