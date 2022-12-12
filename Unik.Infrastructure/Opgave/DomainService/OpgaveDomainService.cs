using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unik.Domain.Opgave.DomainService;
using Unik.SqlServerContext;

namespace Unik.Infrastructure.Opgave.DomainService
{
    public class OpgaveDomainService : IOpgaveDomainService
    {
        private readonly UnikContext _db;


        public OpgaveDomainService(UnikContext context)
        {
            _db = context;
        }

        int IOpgaveDomainService.BeregnOpgaveVarighed(int projektId)
        {
            return _db.ProjektEntities.AsNoTracking().Single(a => a.Id == projektId).AntalBoliger;
        }
    }
}
