using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Applicaiton.Medarbejder.Repositories;

namespace Unik.Applicaiton.Medarbejder.Query.Implementation
{
    public class MedarbejderGetByUserId : IMedarbejderGetByUserId
    {
        private readonly IMedarbejderRepository _repository;

        public MedarbejderGetByUserId(IMedarbejderRepository repository)
        {
            _repository = repository;
        }

        MedarbejderGetByUserIdDto IMedarbejderGetByUserId.GetByUserId(string userId)
        {
            return _repository.GetByUserId(userId);
        }
    }
}
