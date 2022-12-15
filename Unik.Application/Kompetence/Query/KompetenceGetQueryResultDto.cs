using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Crosscut.Dto;

namespace Unik.Application.Kompetence.Query.Implementation
{
    public class KompetenceGetQueryResultDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Type { get; set; }
        public List<MedarbejderEntityDto>? MedarbejderListe { get; set; }
    }
}
