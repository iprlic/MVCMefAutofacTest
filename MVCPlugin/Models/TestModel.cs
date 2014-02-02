using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAutofacTest.Models;

namespace MVCPlugin.Models
{
    public class TestModel: BaseModel
    {
        public override string Text
        {
            get { return "Plugin"; }
        }
    }
}