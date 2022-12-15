using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Crosscut.Dto;
using Unik.Domain.Projekt.Model;

namespace Unik.Application.Kunde.Query
{
    public class KundeUserResultDto
    {
        public string VirksomhedNavn { get; set; }
        public ProjektEntityDto Projekt { get; set; }
        public List<OpgaveEntityDto> OpgaveListe { get; set; }
        public List<BookingEntityDto> BookingListe { get; set; }
    }
}
