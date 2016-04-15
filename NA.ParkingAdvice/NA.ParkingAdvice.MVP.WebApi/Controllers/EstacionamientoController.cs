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
    public class EstacionamientoController : ApiController
    {
        private EstacionamientoDFEntities db = new EstacionamientoDFEntities();

        // GET: api/Estacionamiento
        public IQueryable<Estacionamiento> GetEstacionamiento()
        {
            return db.Estacionamiento;
        }

        // GET: api/Estacionamiento/5
        [ResponseType(typeof(Estacionamiento))]
        public IHttpActionResult GetEstacionamiento(byte id)
        {
            Estacionamiento estacionamiento = db.Estacionamiento.Find(id);
            if (estacionamiento == null)
            {
                return NotFound();
            }

            return Ok(estacionamiento);
        }

        // PUT: api/Estacionamiento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstacionamiento(byte id, Estacionamiento estacionamiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estacionamiento.Id)
            {
                return BadRequest();
            }

            db.Entry(estacionamiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstacionamientoExists(id))
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

        // POST: api/Estacionamiento
        [ResponseType(typeof(Estacionamiento))]
        public IHttpActionResult PostEstacionamiento(Estacionamiento estacionamiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estacionamiento.Add(estacionamiento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estacionamiento.Id }, estacionamiento);
        }

        // DELETE: api/Estacionamiento/5
        [ResponseType(typeof(Estacionamiento))]
        public IHttpActionResult DeleteEstacionamiento(byte id)
        {
            Estacionamiento estacionamiento = db.Estacionamiento.Find(id);
            if (estacionamiento == null)
            {
                return NotFound();
            }

            db.Estacionamiento.Remove(estacionamiento);
            db.SaveChanges();

            return Ok(estacionamiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstacionamientoExists(byte id)
        {
            return db.Estacionamiento.Count(e => e.Id == id) > 0;
        }
    }
}