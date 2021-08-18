using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using RestApiMusic;
using RestApiMusic.Models;

namespace RestApiMusic.Controllers
{
    public class GenresController : ApiController
    {
        private MusicModel db = new MusicModel();

        // GET: api/Genres
        public IQueryable<ClientGenre> GetGenres()
        {
            List<ClientGenre> clientGenres = Genre.ToClientListWithFilledList(db.Genres);
            
            return clientGenres.AsQueryable();
        }


        // GET: api/Genres/5
        [ResponseType(typeof(ClientGenre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            ClientGenre clientGenre = Genre.ToClientWithFilledList(genre);
            return Ok(clientGenre);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, ClientGenre clientGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Genre dbGenre = ClientGenre.ToDbWithFilledList(clientGenre);

            if (id != dbGenre.Id)
            {
                return BadRequest();
            }

            db.Entry(dbGenre).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/Genres
        [ResponseType(typeof(ClientGenre))]
        public IHttpActionResult PostGenre(ClientGenre clientGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Genre dbGenre = ClientGenre.ToDbWithFilledList(clientGenre);
            db.Genres.Add(dbGenre);
            db.SaveChanges();
            clientGenre = Genre.ToClientWithFilledList(dbGenre);
            return CreatedAtRoute("DefaultApi", new { id = clientGenre.Id }, clientGenre);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(ClientGenre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            try
            {
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest("Can't remove genres with records in them");
            }

            return Ok(genre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GenreExists(int id)
        {
            return db.Genres.Count(e => e.Id == id) > 0;
        }
    }
}