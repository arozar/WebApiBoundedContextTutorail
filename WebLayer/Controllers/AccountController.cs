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
   
    public class AccountController : ApiController
    {
        private AccountsContext _db = new AccountsContext();

        // GET api/account
        public IEnumerable<Account> Get()
        {
            var AccountQuery = _db.Accounts
                .Include(a => a.Repairs);

            return AccountQuery;
        }

        // GET api/account/5
        public HttpResponseMessage Get(int id)
        {
            var AccountInfo = _db.Accounts
                .Include(a => a.Repairs)
                .FirstOrDefault(a=>a.AccountId == id);
            
            HttpResponseMessage response;

            if (AccountInfo == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record could not be found");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, AccountInfo);
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
