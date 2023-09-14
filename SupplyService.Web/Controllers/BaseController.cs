using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SupplyService.Web.Controllers
{
    public class BaseController : Controller
    {
        public string UserId
        {
            get
            {
                if (User != null) /* The user object is found to be null here. */
                {
                    var userIdNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                    if (userIdNameClaim != null)
                    {
                        return userIdNameClaim.Value;
                    }
                }

                return null;
            }
        }
        public string UserName
        {
            get
            {
                if (User != null) /* The user object is found to be null here. */
                {
                    var userIdNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                    if (userIdNameClaim != null)
                    {
                        return userIdNameClaim.Value;
                    }
                }

                return null;
            }
        }
    }
}
