using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Domain.Pagination;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Infra.Data.Repositories
{
    
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Alterar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Excluir(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {                
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            return null;
        }

        public async Task<Cliente> Incluir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> SelecionarAsync(int id)
        {
            return await _context.Clientes.Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Cliente>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.Clientes.AsQueryable();
            return await PaginationHelpers.CreateAsync(query, pageNumber, pageSize);
        }
    }
}
