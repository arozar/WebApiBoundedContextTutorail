using Repairs.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Repairs.Domain;

namespace WebLayer.Controllers
{
    public class RepairController : ApiController
    {
        private RepairsContext _db = new RepairsContext();

        // GET api/repairs
        public IEnumerable<Repair> Get()//use Repairs Domain
        {
            var RepairsQuery = _db.Repairs
                     .Include(r => r.Account)
                     .Include(r => r.Team)
                     .Include(r => r.PartsUsed
                         .Select(pu => pu.Component));

            return RepairsQuery;
        }

        // GET api/repairs/5
        public HttpResponseMessage Get(int id)
        {
            var RepairInfo = _db.Repairs
                     .Include(r => r.Account)
                     .Include(r => r.Team)
                     .Include(r => r.PartsUsed
                         .Select(pu => pu.Component))
                         .FirstOrDefault(r=>r.Id== id);
            
            HttpResponseMessage response;

            if (RepairInfo == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record could not be found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, RepairInfo);
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
