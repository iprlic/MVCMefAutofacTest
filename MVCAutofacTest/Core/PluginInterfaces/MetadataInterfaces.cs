using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutofacTest.Core.PluginInterfaces
{
    public interface IControllerMetaData
    {
        string ControllerName { get; }
    }
}