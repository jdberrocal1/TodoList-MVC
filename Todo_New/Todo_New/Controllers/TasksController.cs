using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data_Access.Data;
using Repositories.Repositories;
using Repositories.DTOS;

namespace Todo_New.Controllers
{
    public class TasksController : Controller
    {

        TaskRepository taskRepo = new TaskRepository();
        UserRepository userRepo = new UserRepository();

        // GET: Tasks
        public ActionResult Index()
        {
             
            return View(taskRepo.getAll());
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            var users = userRepo.getAll();
            ViewData["UserList"] = new SelectList(users, "UserId", "UserName");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TodoId,Description,Date,User")] TaskDTO task)
        {
            if (ModelState.IsValid)
            {
                taskRepo.Create(task);
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDTO task = taskRepo.getTaskID(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDTO task = taskRepo.getTaskID(id);
            var users = userRepo.getAll();
            ViewData["UserList"] = new SelectList(users, "UserId", "UserName");
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TodoId,Description,Date")] TaskDTO taskDTO)
        {
            if (ModelState.IsValid)
            {
                taskRepo.editTask(taskDTO);
                return RedirectToAction("Index");
            }
            return View(taskDTO);
        }


        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDTO task = taskRepo.getTaskID(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            taskRepo.deleteTask(id);
            return RedirectToAction("Index");
        }


    }
}
