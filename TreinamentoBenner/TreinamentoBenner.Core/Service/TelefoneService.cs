﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Repository.Common;
using TreinamentoBenner.Core.Repository.Interfaces;
using TreinamentoBenner.Core.Service.Common;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.Service
{
    public class TelefoneService : ServiceBase<Telefone>, ITelefoneService
    {
        public TelefoneService(ITelefoneRepository repository) : base(repository)
        {
        }

        public IQueryable<Telefone> ListarPorPessoa(int id)
        {
            return Query(q => q.IdPessoa == id);
        }
    }
}
