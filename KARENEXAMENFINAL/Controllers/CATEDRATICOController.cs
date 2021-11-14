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
    public class CATEDRATICOController : ApiController
    {
        private KFINALEntities db = new KFINALEntities();

        // GET: api/CATEDRATICO
        public IQueryable<CATEDRATICO> GetCATEDRATICO()
        {
            return db.CATEDRATICO;
        }

        // GET: api/CATEDRATICO/5
        [ResponseType(typeof(CATEDRATICO))]
        public IHttpActionResult GetCATEDRATICO(string id)
        {
            CATEDRATICO cATEDRATICO = db.CATEDRATICO.Find(id);
            if (cATEDRATICO == null)
            {
                return NotFound();
            }

            return Ok(cATEDRATICO);
        }

        // PUT: api/CATEDRATICO/5
        [ResponseType(typeof(void))]
        public HttpResponseMessage Put([FromBody] CATEDRATICO Clien)
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

        // POST: api/CATEDRATICO
        [ResponseType(typeof(CATEDRATICO))]
        public IHttpActionResult PostCATEDRATICO(CATEDRATICO cATEDRATICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CATEDRATICO.Add(cATEDRATICO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                
            }

            return CreatedAtRoute("DefaultApi", new { id = cATEDRATICO.ID_Catedratico }, cATEDRATICO);
        }

        // DELETE: api/CATEDRATICO/5
        [ResponseType(typeof(CATEDRATICO))]
        public HttpResponseMessage Delete([FromBody] CATEDRATICO Clien)
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