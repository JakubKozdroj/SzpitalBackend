using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json;

namespace SzpitalnaKadra.Models
{
    [Table("dbuser")]
    public class DbUser
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("osoba_id")]
        public int OsobaId { get; set; }

        [Column("usesysid")]
        public int? Usesysid { get; set; }

        [Column("usename")]
        public string? Usename { get; set; }  // <- ZOSTAWIAMY TAK!

        [Column("first_time_login")]
        public bool FirstTimeLogin { get; set; }

        [Column("last_pass_change")]
        public DateTime LastPassChange { get; set; }

        [Column("last_activity")]
        public DateTime LastActivity { get; set; }

        [Column("last_activity_app")]
        public string? LastActivityApp { get; set; }

        [Column("params")]
        public JsonDocument? Params { get; set; }

        [Column("last_ip")]
        public IPAddress? LastIp { get; set; }

        [Column("password")]
        public string? Password { get; set; }
    }
}
