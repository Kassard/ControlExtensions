using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Extension.Extensions
{
    /// <summary>
    /// Some extension methods on argument checking etc.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws a ArgumentNullException if arg is null.
        /// </summary>
        /// <typeparam name="TArg">All reference types</typeparam>
        /// <param name="arg">Reference</param>
        /// <param name="name">Argument name</param>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        public static void NotNull<TArg>(this TArg arg, string name) where TArg : class
        {
            if (arg == null)
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Throws a ArgumentNullException if arg is null.
        /// </summary>
        /// <typeparam name="TArg">All reference types</typeparam>
        /// <param name="arg">Reference</param>
        /// <param name="name">Argument name</param>
        /// <param name="message">Extra message</param>
        /// <exception cref="System.ArgumentNullException">ArgumentNullException</exception>
        public static void NotNull<TArg>(this TArg arg, string name, string message) where TArg : class
        {
            if (arg == null)
                throw new ArgumentNullException(name, message);
        }

        /// <summary>
        /// Checks if a string is empty.
        /// </summary>
        /// <param name="value">Reference</param>
        /// <param name="name">Argument name</param>
        public static void NotEmpty(this string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(name);
        }
    }
}
