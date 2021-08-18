using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RestApiMusic.Models;

public partial class Genre
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Genre()
    {
        Records = new HashSet<Record>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Record> Records { get; set; }
    public static List<ClientGenre> ToClientListWithFilledList(DbSet<Genre> dbGenres)
    {
        List<ClientGenre> clientGenres = new List<ClientGenre>();
        if (dbGenres!= null)
        {
            foreach (var genre in dbGenres)
            {
                clientGenres.Add(ToClientWithFilledList(genre));
            }
        }
        return clientGenres;
    }
    public static ClientGenre ToClientWithFilledList(Genre dbGenre)
    {
        ClientGenre clientGenre = ToDbWithEmptyList(dbGenre);
        clientGenre.Records = new List<ClientRecord>();
        if (dbGenre.Records != null)
        {
            foreach (var record in dbGenre.Records)
            {
                clientGenre.Records.Add(Record.ToClientWithEmptyList(record));
            }
        }
        return clientGenre;
    }
    public static ClientGenre ToDbWithEmptyList(Genre dbGenre)
    {
        ClientGenre clientGenre = new ClientGenre();
        clientGenre.Id = dbGenre.Id;
        clientGenre.Name = dbGenre.Name;
        return clientGenre;
    }

}
