using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SzpitalnaKadra.Models
{
    [Table("doswiadczenie_zawodowe")]
    public class DoswiadczenieZawodowe
    {
        [Key]
        [Column("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Column("osoba_id")]
        [JsonPropertyName("osobaId")]
        public int OsobaId { get; set; }

        [Column("kod")]
        [StringLength(50)]
        [JsonPropertyName("kod")]
        public string? Kod { get; set; }

        [Column("nazwa")]
        [StringLength(255)]
        [JsonPropertyName("nazwa")]
        public string? Nazwa { get; set; }

        [Column("zaswiadczenie")]
        [StringLength(255)]
        [JsonPropertyName("zaswiadczenie")]
        public string? Zaswiadczenie { get; set; }
    }
}
