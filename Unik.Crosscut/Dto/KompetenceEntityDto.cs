using System.ComponentModel.DataAnnotations;

namespace Unik.Crosscut.Dto
{
    public class KompetenceEntityDto
    {

        public int Id { get; private set; }
        public string Navn { get; private set; }
        public string Type { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
        public List<MedarbejderEntityDto>? MedarbejderListe { get; private set; }

    }
}
