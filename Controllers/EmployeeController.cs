using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperMVC.Models;
using Dapper;

namespace DapperMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<EmployeeModel>("employeeviewall"));
        }
        [HttpGet]
        public ActionResult addoredit(int id=0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Employeeid", id);
                return View(DapperORM.ReturnList<EmployeeModel>("employeeviewbyid", param).FirstOrDefault<EmployeeModel>());
            }
        }
        [HttpPost]
        public ActionResult addoredit(EmployeeModel emp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@employeeid", emp.employeeid);
            param.Add("@Name", emp.name);
            param.Add("@position", emp.position);
            param.Add("@age", emp.age);
            param.Add("@salary", emp.salary);
            DapperORM.ExecuteWithoutReturn("employeeaddoredit", param);
            return RedirectToAction("Index");
        }
        public ActionResult delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@employeeid", id);
            DapperORM.ExecuteWithoutReturn("employeedelbyid", param);
            return RedirectToAction("Index");
        }
    }
}