using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1.Models;
using Project1.Controllers;

namespace Project1.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        studentEntities1 db = new studentEntities1();
        // GET: EmployeeSalary
        public ActionResult Index1()
        {
            var employee_salary_details = db.employee_salary_details.ToList();
            return View(employee_salary_details);
        }
        public ActionResult Search(DateTime paid_date,DateTime paid_date2)
        {
            var employee_salary_details = db.employee_salary_details.Where(x=>x.paid_date>=paid_date && x.paid_date<=paid_date2).ToList();
            return View("Index1", employee_salary_details);
        }

        public ActionResult Create()
        {
            var employeeList = db.dbo_employee.ToList();
            ViewBag.employeeList = new SelectList(employeeList, "id", "FirstName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(employee_salary_details employee_salary_details)
        {
            db.employee_salary_details.Add(employee_salary_details);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult SaveData(employee_salary_details employee_salary_details)
        {
            db.employee_salary_details.Add(employee_salary_details);
            _ = db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult UpdateData(employee_salary_details employee_salary_details)
        {
            db.Entry(employee_salary_details).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        public ActionResult Edit(int id)
        {
            employee_salary_details data = db.employee_salary_details.Find(id);
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            employee_salary_details data = db.employee_salary_details.Find(id);   
            db.employee_salary_details.Remove(data);
            db.SaveChanges();
            return RedirectToAction("index1");
        }
    }
}