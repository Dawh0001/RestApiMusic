using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestApiMusic.Models
{
    public class ClientGenre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<ClientRecord> Records { get; set; }
        public static List<Genre> ToDbListWithFilledList(DbSet<ClientGenre> clientGenres)
        {
            List<Genre> dbGenres = new List<Genre>();
            if (clientGenres != null)
            {
                foreach (var genre in clientGenres)
                {
                    dbGenres.Add(ToDbWithFilledList(genre));
                }
            }
            return dbGenres;
        }
        public static Genre ToDbWithFilledList(ClientGenre clientGenre)
        {
            Genre dbGenre = ToDbWithEmptyList(clientGenre);
            dbGenre.Records = new HashSet<Record>();
            if (clientGenre.Records!=null)
            {
                foreach (var record in clientGenre.Records)
                {
                    dbGenre.Records.Add(ClientRecord.ToDbWithEmptyList(record));
                }
            }
            return dbGenre;
        }
        public static Genre ToDbWithEmptyList(ClientGenre clientgenre)
        {
            Genre genre = new Genre();
            genre.Id = clientgenre.Id;
            genre.Name = clientgenre.Name;
            return genre;
        }
    }
}