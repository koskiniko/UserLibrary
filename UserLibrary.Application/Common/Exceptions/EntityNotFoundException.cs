using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLibrary.Domain.Entities;

namespace UserLibrary.Application.Common.Exceptions
{
    /// <summary>
    /// Entity with given parameters, was not found
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        public EntityNotFoundException(string propertyName, int propertyValue) : base($"'{propertyName}:{propertyValue}' could not be found.")
        {
            EntityName = propertyName;
            Id = propertyValue;
        }

        /// <summary>
        /// Name of entity not found
        /// </summary>
        public string EntityName { get; }

        /// <summary>
        /// Id of entity not found
        /// </summary>
        public int Id { get; }
    }
}