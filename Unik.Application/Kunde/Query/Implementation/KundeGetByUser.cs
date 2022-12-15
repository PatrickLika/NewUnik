using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Applicaiton.Kunde.Query;
using Unik.Applicaiton.Kunde.Repositories;

namespace Unik.Application.Kunde.Query.Implementation
{
    public class KundeGetByUser : IKundeGetByUser
    {
        private readonly IKundeRepository _kundeRepository;

        public KundeGetByUser(IKundeRepository kundeRepository)
        {
            _kundeRepository = kundeRepository;
        }

        KundeUserResultDto IKundeGetByUser.GetUser(string userId)
        {
           return _kundeRepository.GetUser(userId);
        }
    }
}
