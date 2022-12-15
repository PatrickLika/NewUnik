using System.ComponentModel.DataAnnotations;

namespace Unik.Crosscut.Dto

{
    public class MedarbejderEntityDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string UserId { get; set; }
        public List<KompetenceEntityDto>? KompetenceListe { get; set; }
        public List<OpgaveEntityDto>? OpgaverListe { get; set; }

    }
}
