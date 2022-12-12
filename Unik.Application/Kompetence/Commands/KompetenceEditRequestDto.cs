using Unik.Domain.Medarbejder.Model;

namespace Unik.Applicaiton.Kompetence.Commands
{
    public class KompetenceEditRequestDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Type { get; set; }
        public byte[] RowVersion { get; set; }
        public List<MedarbejderEntity>? MedarbejderListe { get; set; }
    }
}
