﻿using EmprestimoLivros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<EmprestimoDTO> Incluir(EmprestimoPostDTO emprestimoPostDTO);
        Task<EmprestimoDTO> Alterar(EmprestimoDTO emprestimoDTO);
        Task<EmprestimoDTO> Excluir(int id);
        Task<EmprestimoDTO> SelecionarAsync(int id);
        Task<IEnumerable<EmprestimoDTO>> SelecionarTodosAsync();
        Task<bool> VerificaDisponibilidadeAsync(int idLivro);
    }
}
