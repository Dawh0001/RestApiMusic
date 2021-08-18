using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestApiMusic.Models
{
    public class ClientRecord
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? YearOfRelease { get; set; }
        public ClientGenre Genre { get; set; }
        public List<ClientArtist> Artists { get; set; }
        public static List<Record> ToDbListWithFilledList(DbSet<ClientRecord> clientRecords)
        {
            List<Record> dbRecords = new List<Record>();
            if (clientRecords != null)
            {
                foreach (var record in clientRecords)
                {
                    dbRecords.Add(ToDbWithFilledList(record));
                }
            }
            return dbRecords;
        }
        public static Record ToDbWithFilledList(ClientRecord clientRecord)
        {
            Record dbRecord = ToDbWithEmptyList(clientRecord);
            dbRecord.Genre = new Genre();
            dbRecord.Artists = new HashSet<Artist>();
            if (clientRecord.Genre!= null)
                {
                    dbRecord.Genre = ClientGenre.ToDbWithEmptyList(clientRecord.Genre);
            }
            if (clientRecord.Artists!=null)
            {
                foreach (var artist in clientRecord.Artists)
                {
                    dbRecord.Artists.Add(ClientArtist.ToDbWithEmptyList(artist));
                } 
            }
            return dbRecord;
        }
        public static Record ToDbWithEmptyList(ClientRecord clientRecord)
        {
            Record dbRecord = new Record();
            dbRecord.Id = clientRecord.Id;
            dbRecord.Name = clientRecord.Name;
            dbRecord.GenreId = clientRecord.Genre.Id;
            dbRecord.YearOfRelease = clientRecord.YearOfRelease;
            return dbRecord;
        }
    }
}