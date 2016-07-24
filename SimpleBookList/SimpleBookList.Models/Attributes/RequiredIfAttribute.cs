// -----------------------------------------------------------------------
// <copyright file="RequiredIfAttribute.cs" company="Apriorit">
//     apriorit.com. All rights reserved.
// </copyright>
// <author>Brova Aleksandr</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.Attributes.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    using System.Web.Mvc;

    /// <summary>
    /// Custom Attribute
    /// </summary>
    public class RequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// Property for required attribute
        /// </summary>
        private RequiredAttribute innerAttribute = new RequiredAttribute();

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredIfAttribute" /> class.
        /// </summary>
        /// <param name="dependentPropertyName">dependent property</param>
        /// <param name="targetValue">target value</param>
        public RequiredIfAttribute(string dependentPropertyName)
        {
            this.DependentPropertyName = dependentPropertyName;

        }

        /// <summary>
        /// Gets or sets dependent property string
        /// </summary>
        public string DependentPropertyName { get; set; }



        /// <summary>
        /// Get client validation rules
        /// </summary>
        /// <param name="metadata">Model metadata</param>
        /// <param name="context">Context controller</param>
        /// <returns>Model client validation rules list</returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "requiredif",
            };

            string depProp = this.BuildDependentPropertyId(metadata, context as ViewContext);

            /*
            // find the value on the control we depend on;
            // if it's a bool, format it javascript style 
            // (the default is True or False!)
            string targetValue = (this.TargetValue ?? string.Empty).ToString();
            if (this.TargetValue.GetType() == typeof(bool))
            {
                targetValue = targetValue.ToLower();
            }
            */

            rule.ValidationParameters.Add("dependentproperty", depProp);
            //rule.ValidationParameters.Add("targetvalue", targetValue);

            yield return rule;

        }

        /// <summary>
        /// Implementing for ValidationResult method
        /// </summary>
        /// <param name="value">Value for validation</param>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation result</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            /*
            // get a reference to the property this validation depends upon
            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(this.DependentPropertyName);

            if (field != null)
            {
                // get the value of the dependent property
                var dependentvalue = field.GetValue(validationContext.ObjectInstance, null);

                // compare the value against the target value
                if ((dependentvalue == null && this.TargetValue == null) ||
                    (dependentvalue != null && dependentvalue.Equals(this.TargetValue)))
                {
                    // match => means we should try validating this field
                    if (!this.innerAttribute.IsValid(value))
                    {
                        // validation failed - return an error
                        return new ValidationResult(this.ErrorMessage, new[] { validationContext.MemberName });
                    }
                }
            }

            return ValidationResult.Success;
            */


            PropertyInfo property = validationContext.ObjectInstance.GetType().GetProperty(DependentPropertyName);
            object dependentPropertyValue = property.GetValue(validationContext.ObjectInstance, null);

            if (dependentPropertyValue != null && value == null)
            {
                return new ValidationResult(string.Format(ErrorMessageString, validationContext.DisplayName));
            }


            return ValidationResult.Success;


        }

        /// <summary>
        /// Get dependent property Id
        /// </summary>
        /// <param name="metadata">Model metadata</param>
        /// <param name="viewContext">View context</param>
        /// <returns>Dependent property Id</returns>
        private string BuildDependentPropertyId(ModelMetadata metadata, ViewContext viewContext)
        {
            // build the ID of the property
            string depProp = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(this.DependentPropertyName);

            // unfortunately this will have the name of the current field appended to the beginning,
            // because the TemplateInfo's context has had this fieldname appended to it. Instead, we
            // want to get the context as though it was one level higher (i.e. outside the current property,
            // which is the containing object (our Person), and hence the same level as the dependent property.
            var thisField = metadata.PropertyName + "_";
            if (depProp.StartsWith(thisField))
            {
                // strip it off again
                depProp = depProp.Substring(thisField.Length);
            }

            return depProp;
        }
    }
}