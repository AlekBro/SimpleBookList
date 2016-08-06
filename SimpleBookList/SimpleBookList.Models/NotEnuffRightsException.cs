// -----------------------------------------------------------------------
// <copyright file="ModelException.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models
{
    using System;

    /// <summary>
    /// Custom Exception for Event
    /// </summary>
    public class NotEnuffRightsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotEnuffRightsException" /> class.
        /// </summary>
        /// <param name="modelStateDictionary">Error message</param>
        public NotEnuffRightsException(string message) : base(message)
        {
        }
    }
}