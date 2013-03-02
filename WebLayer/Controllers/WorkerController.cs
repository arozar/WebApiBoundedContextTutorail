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
    public class WorkerController : ApiController
    {
        private AccountsContext _db = new AccountsContext();

        // GET api/worker
        public IEnumerable<Worker> Get()
        {
            var WorkerQuery = _db.Workers
                .Include(w => w.Tasks);

            return WorkerQuery;
        }

        // GET api/worker/5
        public HttpResponseMessage Get(int id)
        {
            var WorkerRecord = _db.Workers
                .Include(w => w.Tasks)
                .FirstOrDefault(w => w.Id == id);

            HttpResponseMessage response;

            if (WorkerRecord == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record could not be found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, WorkerRecord);
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
