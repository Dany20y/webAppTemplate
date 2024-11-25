using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Domain.Entities.Response;
using WebApp.Domain.Entities.User; 

namespace WebApp.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ActionStatus LoginUserStatus(User_Login_Data user);
        ActionStatus SigninUserStatus(User_Signin_Data user);
        List<CoCard> GetCards();
     /*   List<CoCard> CoCards { get; }*/
    };
}
