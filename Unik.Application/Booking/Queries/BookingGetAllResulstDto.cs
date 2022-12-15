﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unik.Application.Booking.Queries
{
    public class BookingGetAllResulstDto
    {
        public int Id { get; set; }
        public string MedarbejderNavn { get; set; }
        public DateTime StartDato { get; set; }
        public DateTime SlutDato { get; set; }
        public string MedarbejderTitel { get; set; }
    }
}
