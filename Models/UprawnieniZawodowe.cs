using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SzpitalnaKadra.Models
{
    [Table("uprawnienia_zawodowe")]
    public class UprawnieniZawodowe
    {
        [Key]
        [Column("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Column("osoba_id")]
        [JsonPropertyName("osobaId")]
        public int OsobaId { get; set; }

        [Column("rodzaj")]
        [StringLength(255)]
        [JsonPropertyName("rodzaj")]
        public string? Rodzaj { get; set; }

        [Column("npwz_id_rizh")]
        [StringLength(255)]
        [JsonPropertyName("npwzIdRizh")]
        public string? NpwzIdRizh { get; set; }

        [Column("organ_rejestrujacy")]
        [StringLength(255)]
        [JsonPropertyName("organRejestrujacy")]
        public string? OrganRejestrujacy { get; set; }

        [Column("data_uzycia_uprawnienia")]
        [JsonPropertyName("dataUzyciaUprawnienia")]
        public DateTime? DataUzyciaUprawnienia { get; set; }
    }
}
