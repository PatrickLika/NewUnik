using System.ComponentModel.DataAnnotations;
using Unik.Domain.Medarbejder.Model;

namespace Unik.Domain.Kompetence.Model
{
    public class KompetenceEntity
    {
        internal KompetenceEntity()
        {

        }
        public int Id { get; private set; }
        public string Navn { get; private set; }
        public string Type { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
        public List<MedarbejderEntity>? MedarbejderListe { get; private set; }
        public KompetenceEntity(string navn, string type)
        {
            Navn = navn;
            Type = type;
        }

        public void Edit( string navn, string type, byte[] rowVersion, List<MedarbejderEntity> medarbejderListe)
        {
            Navn = navn;
            Type = type;
            RowVersion = rowVersion;
            MedarbejderListe = medarbejderListe;
        }
    }
}
