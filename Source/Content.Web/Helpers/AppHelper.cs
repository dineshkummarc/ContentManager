using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Helpers
{

    public static class AppHelper
    {

        /// <summary>
        /// Builds an Image URL
        /// </summary>
        /// <param name="imageFile">The file name of the image</param>
        public static string ImageUrl(string imageFile)
        {
            return VirtualPathUtility.ToAbsolute("~/content/images/" + imageFile);
        }

        /// <summary>
        /// Builds a CSS URL
        /// </summary>
        /// <param name="cssFile">The name of the CSS file</param>
        public static string CssUrl(string cssFile)
        {
            return VirtualPathUtility.ToAbsolute("~/content/css/" + cssFile);
        }

    }


}
