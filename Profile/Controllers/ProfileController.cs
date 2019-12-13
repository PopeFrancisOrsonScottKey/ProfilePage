using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Profile.Models;

namespace Profile.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet(Name = "profile")]
        public ActionResult Profile()
        {
            ProfileModel model = new ProfileModel();
            return View(model);
        }
    }
}