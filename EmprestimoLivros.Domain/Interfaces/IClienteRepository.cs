﻿using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Incluir (Cliente cliente);
        Task<Cliente> Alterar(Cliente cliente);
        Task<Cliente> Excluir(int id);
        Task<Cliente> SelecionarAsync(int id);
        Task<PagedList<Cliente>> SelecionarTodosAsync(int pageNumber, int pageSize);
    }
}
