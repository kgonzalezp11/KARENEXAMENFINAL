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
using FINAL;

namespace KARENEXAMENFINAL.Controllers
{
    public class CURSOSController : ApiController
    {
        private KFINALEntities db = new KFINALEntities();

        // GET: api/CURSOS
        public IQueryable<CURSOS> GetCURSOS()
        {
            return db.CURSOS;
        }

        // GET: api/CURSOS/5
        [ResponseType(typeof(CURSOS))]
        public IHttpActionResult GetCURSOS(string id)
        {
            CURSOS cURSOS = db.CURSOS.Find(id);
            if (cURSOS == null)
            {
                return NotFound();
            }

            return Ok(cURSOS);
        }

        // PUT: api/CURSOS/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage Put([FromBody] CURSOS Clien)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (KFINALEntities entities = new KFINALEntities())
                {
                    entities.Entry(Clien).State = System.Data.Entity.EntityState.Modified;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

        // POST: api/CURSOS
        [ResponseType(typeof(CURSOS))]
        public IHttpActionResult PostCURSOS(CURSOS cURSOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CURSOS.Add(cURSOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                
            }

            return CreatedAtRoute("DefaultApi", new { id = cURSOS.ID_Cursos }, cURSOS);
        }

        // DELETE: api/CURSOS/5
        [ResponseType(typeof(CURSOS))]
        public HttpResponseMessage Delete([FromBody] CURSOS Clien)
        {
            int resp = 0;
            HttpResponseMessage msg = null;
            try
            {
                using (KFINALEntities entities = new KFINALEntities())
                {
                    entities.Entry(Clien).State = System.Data.Entity.EntityState.Deleted;
                    resp = entities.SaveChanges();
                    msg = Request.CreateResponse(HttpStatusCode.OK, resp);
                }
            }
            catch (Exception ex)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return msg;
        }

    }
}