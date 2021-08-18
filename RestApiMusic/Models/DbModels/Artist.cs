using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using RestApiMusic.Models;

public partial class Artist
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Artist()
    {
        Records = new HashSet<Record>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int? YearOfBirth { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Record> Records { get; set; }
    public static List<ClientArtist> ToClientListWithFilledList(DbSet<Artist> dbArtists)
    {
        List<ClientArtist> clientArtists = new List<ClientArtist>();
        if (dbArtists != null)
        {
            foreach (var artist in dbArtists)
            {
                clientArtists.Add(ToClientWithFilledList(artist));
            }
        }
        return clientArtists;
    }
    public static ClientArtist ToClientWithFilledList(Artist dbArtist)
    {
        ClientArtist clientArtist = ToClientWithEmptyList(dbArtist);
        clientArtist.Records = new List<ClientRecord>();
        if (dbArtist.Records != null)
        {
            foreach (var record in dbArtist.Records)
            {
                clientArtist.Records.Add(Record.ToClientWithEmptyList(record));
            }
        }
        return clientArtist;
    }
    public static ClientArtist ToClientWithEmptyList(Artist dbArtist)
    {
        ClientArtist clientArtist = new ClientArtist();
        clientArtist.Id = dbArtist.Id;
        clientArtist.Name = dbArtist.Name;
        clientArtist.YearOfBirth = dbArtist.YearOfBirth;
        return clientArtist;
    }
}

