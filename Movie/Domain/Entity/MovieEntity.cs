using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.Entity
{
    [Table("movie")]
    public class MovieEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }

    }
}
