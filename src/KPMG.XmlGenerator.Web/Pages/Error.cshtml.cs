﻿namespace KPMG.XmlGenerator.Web.Pages
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// ErrorModel class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
#pragma warning disable SA1649 // File name must match first type name
    public class ErrorModel : PageModel
#pragma warning restore SA1649 // File name must match first type name
    {
        /// <summary>Gets or sets the request identifier.</summary>
        /// <value>The request identifier.</value>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether [show request identifier].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show request identifier]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

        /// <summary>
        /// Called when [get].
        /// </summary>
        public void OnGet()
        {
            this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
        }
    }
}
