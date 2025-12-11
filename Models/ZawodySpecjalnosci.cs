using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SzpitalnaKadra.Models
{
    [Table("zawody_specjalnosci")]
    public class ZawodySpecjalnosci
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

        [Column("stopien_specjalizacji")]
        [StringLength(255)]
        [JsonPropertyName("stopienSpecjalizacji")]
        public string? StopienSpecjalizacji { get; set; }

        [Column("data_otwarcia_specjalizacji")]
        [JsonPropertyName("dataOtwarciaSpecjalizacji")]
        public DateTime? DataOtwarciaSpecjalizacji { get; set; }

        [Column("dyplom")]
        [StringLength(255)]
        [JsonPropertyName("dyplom")]
        public string? Dyplom { get; set; }
    }
}
