using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Domain.Entities.Response
{
    public class ActionStatus
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
        public string SessionKey { get; set; }
    }
}