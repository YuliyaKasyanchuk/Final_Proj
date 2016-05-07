using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using InternetApp.Filters;
using InternetApp.Models;
using InternetApp.Models.ModelLogick;


namespace InternetApp.Controllers
{
    public class TestsController : Controller
    {

        private Model testModel = new Model();
        private int counter = 0;

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Counter = ++counter;
            // Необходимо узнать, аутентифицирован ли пользователь
            if (WebSecurity.IsAuthenticated)
            {
                // формируем список тестов для зарегистрированных пользователей
                return View(testModel.ListOfTestBlocks);
            }
            else
            {
                // тут будем выдавать страницу с информацией об ошибке
                return View("ErrorPage");
            }
        }

    }
}
