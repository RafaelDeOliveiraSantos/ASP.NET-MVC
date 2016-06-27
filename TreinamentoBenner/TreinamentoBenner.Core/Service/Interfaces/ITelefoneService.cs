﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Common;

namespace TreinamentoBenner.Core.Service.Interfaces
{
    public interface ITelefoneService : IService<Telefone>
    {
        IQueryable<Telefone> ListarPorPessoa(int id);
    }
}
