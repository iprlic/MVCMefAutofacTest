using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAutofacTest.Models
{
    public class BaseModel
    {
        public virtual string Text
        {
            get { return "Test"; }
        }
    }
}