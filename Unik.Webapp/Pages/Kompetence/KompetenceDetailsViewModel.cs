using System.ComponentModel.DataAnnotations;

namespace Unik.WebApp.Pages.Kompetence
{
    public class KompetenceDetailsViewModel
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Type { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
