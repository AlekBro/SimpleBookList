// -----------------------------------------------------------------------
// <copyright file="ModelException.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Models
{
    using System;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// Custom Exception for Event
    /// </summary>
    public class ModelException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelException" /> class.
        /// </summary>
        /// <param name="modelStateDictionary">Model state dictionary</param>
        public ModelException(ModelStateDictionary modelStateDictionary) : base(BuildMessage(modelStateDictionary))
        {
        }

        /// <summary>
        /// Build message for Exception Message property from modelState.Errors ErrorMessages
        /// </summary>
        /// <param name="modelStateDictionary">Model state dictionary</param>
        /// <returns>error message for showing to user</returns>
        private static string BuildMessage(ModelStateDictionary modelStateDictionary)
        {
            StringBuilder messageString = new StringBuilder();
            foreach (ModelState modelState in modelStateDictionary.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    messageString.Append(error.ErrorMessage);
                    messageString.Append("\n");
                }
            }

            return messageString.ToString();
        }
    }
}