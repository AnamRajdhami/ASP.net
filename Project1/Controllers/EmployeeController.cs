using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using Project1.Controllers;

namespace Project1.Controllers
{
    public class EmployeeController : Controller
    {
        studentEntities1 db = new studentEntities1();
        // GET: Employee
        public ActionResult Index()
        {
           
            List<dbo_employee> data = db.dbo_employee.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SaveData( dbo_employee dbo_employee)
        {
            db.dbo_employee.Add(dbo_employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateData(info info)
        {
            db.Entry(info).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
            {
            info data =  db.infoes.Find(id);
            return View(data);
        }

    }
}