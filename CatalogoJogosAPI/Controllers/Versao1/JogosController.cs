using CatalogoJogosAPI.Exceptions;
using CatalogoJogosAPI.Services;
using CatalogoJogosAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogosAPI.Controllers.Versao1
{
    [Route("api/Versao1[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;
        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
           

            var jogos = await _jogoService.Obter(pagina, quantidade);
            if (jogos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);
            if (jogo == null)
            {
                return NoContent();
            }
            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.InserirJogo(jogoInputModel);
                return Ok(jogo);
            }
            catch (JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um cadastro com esse nome para esta produtora");
            }

        }
        //Put atualiza o objeto inteiro
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.AtualizarJogo(idJogo, jogoInputModel);
                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Cadastro não existe");
            }
        }

        //Patch atualiza atributo especifico do objeto
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarPrecoJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.AtualizarPrecoJogo(idJogo, preco);
                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Cadastro não existe");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Deletar(idJogo);
                return Ok();
            }
            catch (JogoNaoCadastradoException ex)
            {
                return NotFound("Cadastro não existe");
            }
        }


    }
}
