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
using WebAppService;

namespace WebAppService.Controllers
{
    public class MonitorTasksController : ApiController
    {
        private ContextServices db = new ContextServices();

        // GET: api/MonitorTasks
        public IQueryable<MonitorTask> GetMonitorTasks()
        {
            return db.MonitorTasks;
        }

        // GET: api/MonitorTasks/5
        [ResponseType(typeof(MonitorTask))]
        public IHttpActionResult GetMonitorTask(int id)
        {
            MonitorTask monitorTask = db.MonitorTasks.Find(id);
            if (monitorTask == null)
            {
                return NotFound();
            }

            return Ok(monitorTask);
        }

        // PUT: api/MonitorTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitorTask(int id, MonitorTask monitorTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitorTask.MonitorTask_ID)
            {
                return BadRequest();
            }

            db.Entry(monitorTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorTaskExists(id))
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

        // POST: api/MonitorTasks
        [ResponseType(typeof(MonitorTask))]
        public IHttpActionResult PostMonitorTask(MonitorTask monitorTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MonitorTasks.Add(monitorTask);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MonitorTaskExists(monitorTask.MonitorTask_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = monitorTask.MonitorTask_ID }, monitorTask);
        }

        // DELETE: api/MonitorTasks/5
        [ResponseType(typeof(MonitorTask))]
        public IHttpActionResult DeleteMonitorTask(int id)
        {
            MonitorTask monitorTask = db.MonitorTasks.Find(id);
            if (monitorTask == null)
            {
                return NotFound();
            }

            db.MonitorTasks.Remove(monitorTask);
            db.SaveChanges();

            return Ok(monitorTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonitorTaskExists(int id)
        {
            return db.MonitorTasks.Count(e => e.MonitorTask_ID == id) > 0;
        }
    }
}