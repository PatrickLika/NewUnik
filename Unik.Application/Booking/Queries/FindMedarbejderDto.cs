using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Medarbejder.Model;

namespace Unik.Applicaiton.Booking.Queries
{
    public class FindMedarbejderDto
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string type { get; set; }

        public List<int> Liste { get; set; }
    }
}
