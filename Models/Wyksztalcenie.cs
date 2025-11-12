using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SzpitalnaKadra.Models
{
    [Table("wyksztalcenie")]
    public class Wyksztalcenie
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("osoba_id")]
        public int OsobaId { get; set; }

        [Column("rodzaj_wyksztalcenia")]
        [StringLength(255)]
        public string RodzajWyksztalcenia { get; set; }

        [Column("kierunek")]
        [StringLength(255)]
        public string Kierunek { get; set; }

        [Column("uczelnia")]
        [StringLength(255)]
        public string Uczelnia { get; set; }

        [Column("data_ukonczenia")]
        public DateTime? DataUkonczenia { get; set; }

        [Column("dyplom")]
        [StringLength(255)]
        public string Dyplom { get; set; }
    }
}
