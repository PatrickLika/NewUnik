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
        public int MedarbejderId { get; set; }
        public DateTime startDato { get; set; }
        public DateTime SlutDato { get; set;}
    }
}
