using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RestApiMusic.Models;

public partial class Record
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Record()
    {
        Artists = new HashSet<Artist>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int? YearOfRelease { get; set; }

    public int? GenreId { get; set; }

    public virtual Genre Genre { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Artist> Artists { get; set; }
    public static List<ClientRecord> ToClientListWithFilledList(DbSet<Record> dbRecords)
    {
        List<ClientRecord> clientRecords = new List<ClientRecord>();
        if (dbRecords != null)
        {
            foreach (var record in dbRecords)
            {
                clientRecords.Add(ToClientWithFilledList(record));
            }
        }
        return clientRecords;
    }
    public static ClientRecord ToClientWithFilledList(Record dbRecord)
    {
        ClientRecord clientRecord = ToClientWithEmptyList(dbRecord);
        clientRecord.Genre = new ClientGenre();
        clientRecord.Artists = new List<ClientArtist>();
        if (dbRecord.Genre != null)
        {
            clientRecord.Genre = Genre.ToDbWithEmptyList(dbRecord.Genre);
        }
        if (dbRecord.Artists.Count != 0)
        {
            foreach (var artist in dbRecord.Artists)
            {
                clientRecord.Artists.Add(Artist.ToClientWithEmptyList(artist));
            }
        }
        return clientRecord;
    }
    public static ClientRecord ToClientWithEmptyList(Record dbRecord)
    {
        ClientRecord clientRecord = new ClientRecord();
        clientRecord.Id = dbRecord.Id;
        clientRecord.Name = dbRecord.Name;
        clientRecord.YearOfRelease = dbRecord.YearOfRelease;
        return clientRecord;
    }

}
