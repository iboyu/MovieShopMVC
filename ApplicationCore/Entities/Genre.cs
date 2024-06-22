using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Genres")]
    public class Genre
    {
        public int id {  get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        //navigation property
        public ICollection<MovieGenre> Movies { get; set; }
    }
}
