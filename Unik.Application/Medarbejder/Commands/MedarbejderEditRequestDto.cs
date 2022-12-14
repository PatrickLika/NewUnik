using Unik.Crosscut.Dto;

namespace Unik.Applicaiton.Medarbejder.Commands

{
    public class MedarbejderEditRequestDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public byte[] RowVersion { get; set; }
        public string UserId { get; set; }
        public List<KompetenceEntityDto>? KompetenceListe { get; set; }
    }
}
