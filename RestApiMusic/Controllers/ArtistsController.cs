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
    public class ArtistsController : ApiController
    {
        private MusicModel db = new MusicModel();

        // GET: api/Artists
        public IQueryable<ClientArtist> GetArtists()
        {
            List<ClientArtist> clientArtists = Artist.ToClientListWithFilledList(db.Artists);
            return clientArtists.AsQueryable();
        }

        // GET: api/Artists/5
        [ResponseType(typeof(ClientArtist))]
        public IHttpActionResult GetArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }
            ClientArtist clientArtist = Artist.ToClientWithFilledList(artist);
            return Ok(clientArtist);
        }

        // PUT: api/Artists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
            {
                return BadRequest();
            }

            db.Entry(artist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        [ResponseType(typeof(ClientArtist))]
        public IHttpActionResult PostArtist(ClientArtist clientArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Artist dbArtist = ClientArtist.ToDbWithFilledList(clientArtist);
            db.Artists.Add(dbArtist);
            db.SaveChanges();
            clientArtist = Artist.ToClientWithFilledList(dbArtist);
            return CreatedAtRoute("DefaultApi", new { id = clientArtist.Id }, clientArtist);
        }

        // DELETE: api/Artists/5
        [ResponseType(typeof(ClientArtist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            db.Artists.Remove(artist);
            db.SaveChanges();
            ClientArtist clientArtist = Artist.ToClientWithFilledList(artist);
            return Ok(clientArtist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArtistExists(int id)
        {
            return db.Artists.Count(e => e.Id == id) > 0;
        }
    }
}