using MayorAssistantApp.DAL;
using MayorAssistantApp.Models.ChatBotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayorAssistantApp.Controllers
{
    public class ChatBotController : Controller
    {
        // GET: ChatBot
        public ActionResult Index()
        {
            List<QA> list = new List<QA>();

            list = QADB.GetAllQA();


            return View(list);
        }

        // GET: ChatBot/Create/5
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View(id);
        }
        

        

        // GET: ChatBot/Edit/5
        public ActionResult Edit(int id)
        {
            QA qa = new QA();

            qa = QADB.GetQAById(id);



            return View(qa);
        }

        // POST: ChatBot/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChatBot/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatBot/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
