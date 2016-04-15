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
using NA.ParkingAdvice.MVP.WebApi.Models;

namespace NA.ParkingAdvice.MVP.WebApi.Controllers
{
    public class ZonaEstablecimientoController : ApiController
    {
        private EstacionamientoDFEntities db = new EstacionamientoDFEntities();

        // GET: api/ZonaEstablecimiento
        public IQueryable<ZonaEstablecimiento> GetZonaEstablecimiento()
        {
            return db.ZonaEstablecimiento;
        }

        // GET: api/ZonaEstablecimiento/5
        [ResponseType(typeof(ZonaEstablecimiento))]
        public IHttpActionResult GetZonaEstablecimiento(int id)
        {
            ZonaEstablecimiento zonaEstablecimiento = db.ZonaEstablecimiento.Find(id);
            if (zonaEstablecimiento == null)
            {
                return NotFound();
            }

            return Ok(zonaEstablecimiento);
        }

        // PUT: api/ZonaEstablecimiento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZonaEstablecimiento(int id, ZonaEstablecimiento zonaEstablecimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zonaEstablecimiento.Id)
            {
                return BadRequest();
            }

            db.Entry(zonaEstablecimiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaEstablecimientoExists(id))
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

        // POST: api/ZonaEstablecimiento
        [ResponseType(typeof(ZonaEstablecimiento))]
        public IHttpActionResult PostZonaEstablecimiento(ZonaEstablecimiento zonaEstablecimiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZonaEstablecimiento.Add(zonaEstablecimiento);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ZonaEstablecimientoExists(zonaEstablecimiento.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = zonaEstablecimiento.Id }, zonaEstablecimiento);
        }

        // DELETE: api/ZonaEstablecimiento/5
        [ResponseType(typeof(ZonaEstablecimiento))]
        public IHttpActionResult DeleteZonaEstablecimiento(int id)
        {
            ZonaEstablecimiento zonaEstablecimiento = db.ZonaEstablecimiento.Find(id);
            if (zonaEstablecimiento == null)
            {
                return NotFound();
            }

            db.ZonaEstablecimiento.Remove(zonaEstablecimiento);
            db.SaveChanges();

            return Ok(zonaEstablecimiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZonaEstablecimientoExists(int id)
        {
            return db.ZonaEstablecimiento.Count(e => e.Id == id) > 0;
        }
    }
}