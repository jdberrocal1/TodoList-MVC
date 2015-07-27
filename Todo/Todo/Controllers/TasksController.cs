﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Todo.Models;

namespace Todo.Controllers
{
    public class TasksController : Controller
    {
        private TodoList db = new TodoList();

        // GET: Tasks
        public ActionResult Index()
        {
            
            List<TaskDTO> Tasks = new List<TaskDTO>();
            var tasks = db.Tasks.Include(t => t.User);

            foreach (Task task in tasks.ToList())
            {
                TaskDTO taskDTO = new TaskDTO();
                taskDTO.TodoId = task.TodoId;
                taskDTO.Date = task.Date;
                taskDTO.Description = task.Description;
                taskDTO.UserId = task.UserId;
                taskDTO.User = task.User;

                Tasks.Add(taskDTO);
            }
            return View(Tasks);
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            TaskDTO taskDTO = new TaskDTO();
            taskDTO.TodoId = task.TodoId;
            taskDTO.Date = task.Date;
            taskDTO.Description = task.Description;
            taskDTO.UserId = task.UserId;
            taskDTO.User = task.User;

            return View(taskDTO);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TodoId,Description,Date,UserId")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", task.UserId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", task.UserId);

            TaskDTO taskDTO = new TaskDTO();
            taskDTO.TodoId = task.TodoId;
            taskDTO.Date = task.Date;
            taskDTO.Description = task.Description;
            taskDTO.UserId = task.UserId;
            taskDTO.User = task.User;

            return View(taskDTO);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TodoId,Description,Date,UserId")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", task.UserId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            TaskDTO taskDTO = new TaskDTO();
            taskDTO.TodoId = task.TodoId;
            taskDTO.Date = task.Date;
            taskDTO.Description = task.Description;
            taskDTO.UserId = task.UserId;
            taskDTO.User = task.User;

            return View(taskDTO);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
