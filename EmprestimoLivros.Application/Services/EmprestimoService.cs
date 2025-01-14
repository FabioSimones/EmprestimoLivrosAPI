﻿using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IMapper _mapper;

        public EmprestimoService(IEmprestimoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmprestimoDTO> Alterar(EmprestimoDTO emprestimoDTO)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoDTO);
            var emprestimoAlterado = await _repository.Alterar(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoAlterado);
        }

        public async Task<EmprestimoDTO> Excluir(int id)
        {
            var emprestimoExcluido = await _repository.Excluir(id);
            return _mapper.Map<EmprestimoDTO>(emprestimoExcluido);
        }

        public async Task<EmprestimoDTO> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoPostDTO);
            var emprestimoIncluido = await _repository.Incluir(emprestimo);
            return _mapper.Map<EmprestimoDTO>(emprestimoIncluido);
        }

        public async Task<EmprestimoDTO> SelecionarAsync(int id)
        {
            var emprestimo = await _repository.SelecionarAsync(id);
            return _mapper.Map<EmprestimoDTO>(emprestimo);
        }

        public async Task<IEnumerable<EmprestimoDTO>> SelecionarTodosAsync()
        {
            var emprestimos = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<EmprestimoDTO>>(emprestimos);
        }

        public async Task<bool> VerificaDisponibilidadeAsync(int idLivro)
        {
            return await _repository.VerificaDisponibilidadeAsync(idLivro);
        }
    }
}
