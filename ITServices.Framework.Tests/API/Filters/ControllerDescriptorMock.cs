using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace ITServices.Framework.Tests.API.Filters
{
    public class ControllerDescriptorMock : HttpControllerDescriptor
    {
        
        public Type ControllerType
        {
            get
            {
                return base.ControllerType;
            }
            set { base.ControllerType = value; }
        }

        public string ControllerName
        {
            get
            {
                return base.ControllerName;
            }
            set { base.ControllerName = value; }
        }
    }
}
