using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentNamespace.Web.Helpers
{

    /// <summary>
    /// Enums which describe script libraries
    /// </summary>
    public enum ScriptLibrary
    {
        Ajax,
        StateDropDown
    }

    /// <summary>
    /// Types of HTML Lists
    /// </summary>
    public enum ListType
    {
        Ordered,
        Unordered,
        TableCell
    }

    public enum ContentControls
    {
        ProductDisplay,
        AddressEntry,
        CardSpaceLogin,
        OpenIDLogin,
        UserNamePasswordLogin,
        AddressDisplay,
        OrderItems,
        OrderHeader

    }


}
