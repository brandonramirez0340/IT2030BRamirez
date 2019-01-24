using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products/Browse
        public string Browse()
        {
            return "Browse displayed";
        }

        // GET: Products/Details/105
        public string Details(int id)
        {
            return "Details displayed for Id=" + id;
        }

        // GET: Products/Location?zip=44124
        public string Location(int zip)
        {
            return HttpUtility.HtmlEncode("Location displayed for zip=" + zip);
        }
    }
}