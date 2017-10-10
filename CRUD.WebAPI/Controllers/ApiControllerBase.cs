using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CRUD.WebAPI.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {

        protected List<object> returnError(Exception ex, List<object> list = null)
        {
            if (list == null)
                list = new List<object>();
            list.Add(new { message = ex.Message, stackTrace = ex.StackTrace });

            if (ex.InnerException != null)
                list = returnError(ex.InnerException, list);

            return list;
        }
    }
}