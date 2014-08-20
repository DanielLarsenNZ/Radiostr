using System;
using System.ComponentModel.DataAnnotations;

namespace Radiostr.Model.Extensions
{
    /// <summary>
    /// Extenstion methods for the validation of objects using DataAnnotations.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates an object by inspecting its <see cref="System.ComponentModel.DataAnnotations"/>. Also validates 
        /// objects that implement <see cref="IValidatableObject "/>.
        /// </summary>
        /// <param name="instance">An instance of an object with <see cref="System.ComponentModel.DataAnnotations"/> or 
        /// implementing <see cref="IValidatableObject "/></param>
        public static void Validate<T>(this T instance) where T:class
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance",
                    string.Format("Instance of <{0}> cannot be null.", typeof (T).FullName));
            }

            Validator.ValidateObject(instance, new ValidationContext(instance));
        }
    }
}
