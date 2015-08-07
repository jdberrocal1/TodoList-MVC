using DTOS.DTOS;
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
using Repositories.Repositories;


namespace API.Controllers
{
    public class UserController : ApiController
    {

        UserRepository userRepo = new UserRepository();


        // GET: api/User
        public List<UserDTO> GetUsers()
        {
            return userRepo.GetAll();
        }

        // GET: api/User/5
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult GetUser(int id)
        {
            UserDTO user = userRepo.GetUserID(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userDTO.UserId)
            {
                return BadRequest();
            }

            try
            {
                userRepo.EditUser(userDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (userRepo.GetUserID(id) == null)
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

        // POST: api/User
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult PostUser(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userRepo.Create(userDTO);

            return CreatedAtRoute("DefaultApi", new { id = userDTO.UserId }, userDTO);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult DeleteUser(int id)
        {
            UserDTO user = userRepo.GetUserID(id);
            if (user == null)
            {
                return NotFound();
            }

            userRepo.DeleteUser(id);

            return Ok(user);
        }

    }
}