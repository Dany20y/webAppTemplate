using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebApp.BusinessLogic.Interfaces;

namespace WebApp.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSession()
        {
            return new SessionBL();
        }
    }
}