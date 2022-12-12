using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Applicaiton.Medarbejder.Repositories;

namespace Unik.Applicaiton.Medarbejder.Commands
{
    public class CreateMedarbejderKompetenceCommand : ICreateMedarbejderKompetenceCommand
    {
        private readonly IMedarbejderRepository _repository;

        public CreateMedarbejderKompetenceCommand(IMedarbejderRepository repository)
        {
            _repository = repository;
        }

        void ICreateMedarbejderKompetenceCommand.Create(MedarbejderKompetenceCreateDto requestDto)
        {
            _repository.CreateMedarbejderKompetence(requestDto);
        }
    }
}
