using NA.ParkingAdvice.MVP.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace NA.ParkingAdvice.MVP.WebApi.Controllers
{
    public class DFParkingController : ApiController
    {
        private EstacionamientoDFEntities db = new EstacionamientoDFEntities();

        [ResponseType(typeof(ZonaEstablecimiento))]
        public IHttpActionResult Get()
        {
            try
            {
                //var zonaEstablecimiento1 = db.ZonaEstablecimiento.ToList().Select(r => new
                //{
                //    Nombre = r.Nombre,
                //    Latitud = r.Latitud,
                //    Logitud = r.Logitud,
                //    CantidadEstacionamientos = r.CantidadEstacionamientos,
                //    CantidadEstacionamientosUsados = r.CantidadEstacionamientosUsados
                //});

                var zonaEstablecimiento = db.ZonaEstablecimiento.Select(r => new
                {
                    Nombre = r.Nombre,
                    Latitud = r.Latitud,
                    Logitud = r.Logitud,
                    CantidadEstacionamientos = r.CantidadEstacionamientos,
                    CantidadEstacionamientosUsados = r.CantidadEstacionamientosUsados
                }).ToList();

                //200 Http Status Code
                return Ok(zonaEstablecimiento);
            }
            catch (Exception)
            {
                //500 Http Status Code
                return InternalServerError();
            }
        }

        [ResponseType(typeof(ZonaEstablecimiento))]
        public IHttpActionResult GetZonaEstablecimiento(int id)
        {
            ZonaEstablecimiento zonaEstablecimiento = db.ZonaEstablecimiento.Find(id);
            if (zonaEstablecimiento == null)
            {
                return NotFound();
            }

            var zonaEstablecimiento1 = new
            {
                Nombre = zonaEstablecimiento.Nombre,
                Latitud = zonaEstablecimiento.Latitud,
                Logitud = zonaEstablecimiento.Logitud,
                CantidadEstacionamientos = zonaEstablecimiento.CantidadEstacionamientos,
                CantidadEstacionamientosUsados = zonaEstablecimiento.CantidadEstacionamientosUsados
            };

            return Ok(zonaEstablecimiento1);
        }

        public IHttpActionResult Put(int id, ZonaEstablecimiento nuevoZonaEstablecimiento)
        {        
            try
            {
                if (nuevoZonaEstablecimiento == null)
                    return BadRequest();

                var zonaEstablecimientoActual = db.ZonaEstablecimiento.SingleOrDefault(b => b.Id == id);
                if (zonaEstablecimientoActual == null)
                {
                    //404 Http Status Code
                    return NotFound();
                }

                zonaEstablecimientoActual.Nombre = nuevoZonaEstablecimiento.Nombre;
                zonaEstablecimientoActual.Latitud = nuevoZonaEstablecimiento.Latitud;
                zonaEstablecimientoActual.Logitud = nuevoZonaEstablecimiento.Logitud;
                zonaEstablecimientoActual.CantidadEstacionamientosUsados = nuevoZonaEstablecimiento.CantidadEstacionamientosUsados;
                zonaEstablecimientoActual.CantidadEstacionamientos = nuevoZonaEstablecimiento.CantidadEstacionamientos;
                
                db.Entry(zonaEstablecimientoActual).State = EntityState.Modified;

                db.SaveChanges();

                var zonaEstablecimiento = new
                {
                    Nombre = nuevoZonaEstablecimiento.Nombre,
                    Latitud = nuevoZonaEstablecimiento.Latitud,
                    Logitud = nuevoZonaEstablecimiento.Logitud,
                    CantidadEstacionamientos = nuevoZonaEstablecimiento.CantidadEstacionamientos,
                    CantidadEstacionamientosUsados = nuevoZonaEstablecimiento.CantidadEstacionamientosUsados
                };

                //200 Http Status Code
                return Ok(zonaEstablecimiento);

                //return BadRequest();
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
            catch (Exception ex)
            {
                string es = ex.ToString();
                //500 Http Status Code 
                return InternalServerError();
            }
        }

        private bool ZonaEstablecimientoExists(int id)
        {
            return db.ZonaEstablecimiento.Count(e => e.Id == id) > 0;
        }
    }
}
