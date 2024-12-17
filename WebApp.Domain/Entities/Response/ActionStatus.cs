using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Domain.Entities.Enums;

namespace WebApp.Domain.Entities.Response
{
    public class ActionStatus
    {
        public bool IsSuccess { get; set; }
        public string StatusMessage { get; set; }
        public string SessionKey { get; set; }
        public bool IsAdmin { get; set; }
    }
}