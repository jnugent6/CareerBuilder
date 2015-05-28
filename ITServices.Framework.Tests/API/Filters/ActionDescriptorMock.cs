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
    public class ActionDescriptorMock : HttpActionDescriptor
    {
        private ControllerDescriptorMock _controllerDescriptor;
        public ActionDescriptorMock()
        {
            
        }

        public ActionDescriptorMock(ControllerDescriptorMock controllerDescriptor)
        {
            this._controllerDescriptor = controllerDescriptor;
        }
        public override string ActionName
        {
            get
            {
                return "Get";
            }
        }

        public ControllerDescriptorMock ControllerDescriptor
        {
            get
            {
                return _controllerDescriptor;
            }
            set
            {
                _controllerDescriptor = value;
                
            }
          
        }

        public override Type ReturnType
        {
            get { throw new NotImplementedException(); }
        }


        public override Collection<HttpParameterDescriptor> GetParameters()
        {
            throw new NotImplementedException();
        }

        public override Task<object> ExecuteAsync(HttpControllerContext controllerContext, IDictionary<string, object> arguments, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
