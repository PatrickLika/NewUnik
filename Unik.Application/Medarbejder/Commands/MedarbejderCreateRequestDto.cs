using Unik.Domain.Kompetence.Model;

namespace Unik.Applicaiton.Medarbejder.Commands

{
    public class MedarbejderCreateRequestDto
    {
        public string Navn { get; set; }
        public string Email { get; set; }
        public string Tlf { get; set; }
        public string Titel { get; set; }
        public string UserId { get; set; }
    }
}
