using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrcamentoEletrico.Models.Requests;
using OrcamentoEletrico.Models.Responses;
using OrcamentoEletricoDomain.Entities;
using OrcamentoEletricoDomain.Interfaces;

namespace OrcamentoEletrico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : BaseController
    {
        private readonly ICadastrarPessoaService _cadastrarPessoaService;
        private readonly IMapper _mapper;

        public PessoaController(ICadastrarPessoaService cadastrarPessoaService, IMapper mapper)
        {
            _cadastrarPessoaService = cadastrarPessoaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        /// <param name="request">O usuário a ser cadastrado.</param>
        /// <returns>O status de cadastramento e a id do usuário.</returns>
        /// <response code="200">Cadastro realizado com sucesso.</response>
        /// <response code="400">Erro ao cadastrar.</response>
        [HttpPost("cadastrar-pessoa")]
        public async Task<IActionResult> CadastrarPessoa([FromBody] PessoaRequest request)
        {
            try
            {
                // 1. Criação da entidade Pessoa
                var pessoa = _mapper.Map<Pessoa>(request);

                // 2. Cadastra a pessoa e retorna o Id do cadastro
                var pessoaId = await _cadastrarPessoaService.cadastrarPessoa(pessoa);

                // 3. Constrói a response
                var response = new PessoaResponse
                {
                    PessoaId = pessoaId
                };

                // 4. Retorna o resultado e o status da operação
                return HandleActionResult(response);
            }
            catch (InvalidOperationException ex)
            {
                return HandleBadRequestResult(ex.Message);
            }
        }
    }
}
