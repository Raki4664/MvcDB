using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdbase.Models;
using System.Net;

namespace mvcdbase.Controllers
{
    public class PersonController : Controller
    {
        ConnEntities db = new ConnEntities();
        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            return View(db.tblPersons.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblPerson person)
        {
            if (ModelState.IsValid)
            {
                db.tblPersons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id Required");
                }
                tblPerson person = db.tblPersons.Find(id);
                if (person == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                return View(person);
            }
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id Required");
                }
                tblPerson person = db.tblPersons.Find(id);
                if (person == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                return View(person);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {


            tblPerson person = db.tblPersons.Find(id);
            UpdateModel(person);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Id Required");
                }
                tblPerson person = db.tblPersons.Find(id);
                if (person == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                return View(person);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {


            tblPerson person = db.tblPersons.Find(id);
            db.tblPersons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        
        public ActionResult Show()
        {
            return View(db.tblPersons.ToList());
        }
        
    }
}