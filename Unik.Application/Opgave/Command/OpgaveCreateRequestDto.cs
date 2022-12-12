using System.ComponentModel.DataAnnotations;
using Unik.Domain.Projekt.Model;

namespace Unik.Applicaiton.Opgave.Command
{
    public class OpgaveCreateRequestDto
    {
        public string Navn { get; set; }
        public int ProjektId { get; set; }
        public string Type { get; set; }
    }
}
