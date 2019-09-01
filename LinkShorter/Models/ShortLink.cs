using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinkShorter.Models {
    [Table("links")]
    public class ShortLink {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public DateTime Date { get; set; }
        public int Counter { get; set; }
    }
}
