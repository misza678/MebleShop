﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MebleShop.Controllers
{
    public class LiveChatController : Controller
    {
        // GET: LiveChat
        public ActionResult Chat()
        {
            return View();
        }
    }
}