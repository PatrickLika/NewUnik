using System.ComponentModel.DataAnnotations;

namespace Unik.Crosscut.Dto
{
    public class KompetenceEntityDto
    {

        public int Id { get; set; }
        public string Navn { get; set; }
        public string Type { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public List<MedarbejderEntityDto>? MedarbejderListe { get; set; }

    }
}
