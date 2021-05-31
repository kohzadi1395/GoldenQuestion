using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class GoldenControl : ControllerBase
    {
        public Guid UserId => Guid.Parse(HttpContext.User.Claims.ToList()[2].Value);
    }
}