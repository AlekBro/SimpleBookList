// -----------------------------------------------------------------------
// <copyright file="CustomException.cs" company="AlekBro">
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
    public class CustomException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException" /> class.
        /// </summary>
        /// <param name="modelStateDictionary">Model state dictionary</param>
        public CustomException(ModelStateDictionary modelStateDictionary) : base(BuildMessage(modelStateDictionary))
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