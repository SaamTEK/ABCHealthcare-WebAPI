using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using ABCHealthcare.Models;

namespace ABCHealthcare.Controllers
{
    public class MedicinesController : ApiController
    {
        private ABCHealthDBContext db = new ABCHealthDBContext();

        // GET: api/Medicines
        public IQueryable<Medicine> GetMedicines()
        {
            return db.Medicines;
        }

        // GET: api/Medicines/5
        [ResponseType(typeof(Medicine))]
        public async Task<IHttpActionResult> GetMedicine(int id)
        {
            Medicine medicine = await db.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        // PUT: api/Medicines/5
        [BasicAuthentication]
        [MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.Id)
            {
                return BadRequest();
            }

            db.Entry(medicine).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
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

        // POST: api/Medicines
        [BasicAuthentication]
        [MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(Medicine))]
        public async Task<IHttpActionResult> PostMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicines.Add(medicine);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medicine.Id }, medicine);
        }

        // DELETE: api/Medicines/5
        [BasicAuthentication]
        [MyAuthorize(Roles = "Admin")]
        [ResponseType(typeof(Medicine))]
        public async Task<IHttpActionResult> DeleteMedicine(int id)
        {
            Medicine medicine = await db.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            db.Medicines.Remove(medicine);
            await db.SaveChangesAsync();

            return Ok(medicine);
        }

        [HttpPost]
        [Route("api/Medicines/Upload")]
        public string UploadFile()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/Uploads"),
                    fileName
                );

                file.SaveAs(path);
            }

            return file != null ? "/Uploads/" + file.FileName : null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicineExists(int id)
        {
            return db.Medicines.Count(e => e.Id == id) > 0;
        }
    }
}