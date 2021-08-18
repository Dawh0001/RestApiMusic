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
using RestApiMusic;
using RestApiMusic.Models;

namespace RestApiMusic.Controllers
{
    public class RecordsController : ApiController
    {
        private MusicModel db = new MusicModel();

        // GET: api/Records
        public IQueryable<ClientRecord> GetRecords()
        {
            List<ClientRecord> clientRecords = Record.ToClientListWithFilledList(db.Records);

            return clientRecords.AsQueryable();
        }

        // GET: api/Records/5
        [ResponseType(typeof(ClientRecord))]
        public IHttpActionResult GetRecord(int id)
        {
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return NotFound();
            }
            ClientRecord clientRecord = Record.ToClientWithFilledList(record);
            return Ok(clientRecord);
        }

        // PUT: api/Records/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecord(int id, ClientRecord clientRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientRecord.Id)
            {
                return BadRequest();
            }

            Record dbRecord = new Record();
            dbRecord = db.Records.Find(clientRecord.Id);
            dbRecord.Name = clientRecord.Name;
            dbRecord.YearOfRelease = clientRecord.YearOfRelease;
            dbRecord.GenreId = clientRecord.Genre.Id;
            if (dbRecord.Genre!=null)
            {
                dbRecord.Genre = db.Genres.Find(clientRecord.Genre.Id);
            }
            List<Artist> artistList = new List<Artist>();

            if (clientRecord.Artists.Count!=0)
            {
                foreach (var artist in clientRecord.Artists)
                {
                    Artist temp = db.Artists.Find(artist.Id);
                    artistList.Add(temp);
                }
            }
            dbRecord.Artists = artistList;
            db.Entry(dbRecord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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

        // POST: api/Records
        [ResponseType(typeof(ClientRecord))]
        public IHttpActionResult PostRecord(ClientRecord clientRecord)
        {
            Record dbRecord = ClientRecord.ToDbWithFilledList(clientRecord);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Artist> recordArtists = new List<Artist>();
            foreach (var artist in clientRecord.Artists)
            {
                if (artist.Id != 0)
                {
                    //Artist artist1 = db.Artists.Find(artist.Id);
                    dbRecord.Artists.Add(db.Artists.Find(artist.Id));
                }
            }
            //dbRecord.Artists = recordArtists;
            dbRecord.Genre = db.Genres.Find(clientRecord.Genre.Id);
            db.Records.Add(dbRecord);
            db.SaveChanges();

            clientRecord = Record.ToClientWithFilledList(dbRecord);

            return CreatedAtRoute("DefaultApi", new { id = clientRecord.Id }, clientRecord);
        }

        // DELETE: api/Records/5
        [ResponseType(typeof(ClientRecord))]
        public IHttpActionResult DeleteRecord(int id)
        {
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return NotFound();
            }

            db.Records.Remove(record);
            db.SaveChanges();
            ClientRecord clientRecord = Record.ToClientWithFilledList(record);
            return Ok(clientRecord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecordExists(int id)
        {
            return db.Records.Count(e => e.Id == id) > 0;
        }
    }
}