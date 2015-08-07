using DTOS.DTOS;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace API.Controllers
{
    public class TaskController : ApiController
    {

        TaskRepository taskRepo = new TaskRepository();

        // GET: api/Task
        [HttpGet]
        public IEnumerable<TaskDTO> GetTasks()
        {

            return taskRepo.GetAll().AsEnumerable();
        }



        // GET: api/Task/5
        [HttpGet]
        [ResponseType(typeof(TaskDTO))]
        public TaskDTO GetTask(int id)
        {
            TaskDTO task = taskRepo.GetTaskID(id);
            if (task == null)
            {
                return null;
            }

            return task;
        }


        // DELETE: api/Task/5
        [ResponseType(typeof(TaskDTO))]
        public IHttpActionResult DeleteTask(int id)
        {
            TaskDTO task = taskRepo.GetTaskID(id);
            if (task == null)
            {
                return NotFound();
            }

            taskRepo.DeleteTask(id);

            return Ok(task);
        }



        // PUT: api/Task/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, TaskDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskDTO.TodoId)
            {
                return BadRequest();
            }

            try
            {
                taskRepo.EditTask(taskDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (taskRepo.GetTaskID(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/Task
        [ResponseType(typeof(TaskDTO))]
        public IHttpActionResult PostTask(TaskDTO taskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            taskRepo.Create(taskDTO);

            return CreatedAtRoute("DefaultApi", new { id = taskDTO.TodoId }, taskDTO);
        }

    }
}