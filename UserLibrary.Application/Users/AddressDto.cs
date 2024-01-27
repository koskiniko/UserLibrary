using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLibrary.Application.Users
{
    /// <summary>
    /// Address data transfer object
    /// </summary>
    public record AddressDto
    {
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; } = null!;

        /// <summary>
        /// Suite
        /// </summary>
        public string Suite { get; set; } = null!;

        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; } = null!;
    }
}