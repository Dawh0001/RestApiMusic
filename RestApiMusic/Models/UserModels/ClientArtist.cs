using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestApiMusic.Models
{
    public class ClientArtist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? YearOfBirth { get; set; }
        public List<ClientRecord> Records { get; set; }
        public ClientArtist() { }
        public static List<Artist> ToDbListWithFilledList(DbSet<ClientArtist> clientArtists)
        {
            List<Artist> dbGenres = new List<Artist>();
            if (clientArtists != null)
            {
                foreach (var artist in clientArtists)
                {
                    dbGenres.Add(ToDbWithFilledList(artist));
                }
            }
            return dbGenres;
        }
        public static Artist ToDbWithFilledList(ClientArtist clientArtist)
        {
            Artist dbArtist = ToDbWithEmptyList(clientArtist);

            dbArtist.Records = new HashSet<Record>();
            if (clientArtist.Records != null)
            {
                foreach (var record in clientArtist.Records)
                {
                    dbArtist.Records.Add(ClientRecord.ToDbWithFilledList(record));
                }
            }
            return dbArtist;
        }
        public static Artist ToDbWithEmptyList(ClientArtist clientArtist)
        {
            Artist artist = new Artist();
            artist.Id = clientArtist.Id;
            artist.Name = clientArtist.Name;
            artist.YearOfBirth = clientArtist.YearOfBirth;
            return artist;
        }
    }
}