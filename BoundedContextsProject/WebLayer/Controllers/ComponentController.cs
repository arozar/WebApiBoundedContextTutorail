using Accounts.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Accounts.Domain;

namespace WebLayer.Controllers
{
    public class ComponentController : ApiController
    {
        private AccountsContext _db = new AccountsContext();

        // GET api/component
        public IEnumerable<Component> Get()
        {
            var ComponentQuery = _db.Components
                .Include(c => c.Usage
                    .Select(r => r.Repair));

            return ComponentQuery;
        }

        // GET api/component/5
        public HttpResponseMessage Get(int id)
        {
            var ComponentInfo = _db.Components
                .Include(c => c.Usage
                    .Select(r => r.Repair))
                    .FirstOrDefault(c=>c.Id == id);
           
            HttpResponseMessage response;
 
            if (ComponentInfo == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound,"Record could not be found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, ComponentInfo);
            }
            return response;
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
