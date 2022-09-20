using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEstudos.Domain.Models;
using ProjetoEstudos.Repositories.Interface;

namespace ProjetoEstudos.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursosRepository _cursosRepository;
        public CursosController(ICursosRepository cursosRepository)
        {
            _cursosRepository = cursosRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Post(Cursos cursos)
        {
            if (cursos == null)
            {
                return BadRequest(cursos + " não pode ser nulo");
            }
            await _cursosRepository.Insert(cursos);
            return Ok("Curso registrado com sucesso");
        }

        [HttpGet("OberTodosCursos")]
        public async Task<ActionResult> OberTodosCursos()
        {
            var resultado = await _cursosRepository.GetAll();
            return Ok(resultado);
        }

        [HttpGet("ObterCursoPorId/{id}")]
        public async Task<ActionResult> ObterCursoPorId(int id)
        {
            var resultado = await _cursosRepository.GetById(id);
            if(resultado == null)
            {
                return NotFound(id + " não encontrado");
            }
            return Ok(resultado);
        }

        [HttpDelete("Delete/{id^}")]
        public async Task <ActionResult> Delete(int id)
        {
            var resultado = await _cursosRepository.GetById(id);
            if(resultado == null)
            {
                return NotFound(id + " não encontrado");
            }
            await _cursosRepository.Delete(id);        
            return Ok("O id: " + id + " foi excluido com sucesso");
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Cursos curso)
        {
            if (id != curso.Id)
            {
                return BadRequest(id + " não encontrado");
            }
            try
            {
                await _cursosRepository.Update(id, curso);
            }
            catch (DbUpdateConcurrencyException ex)
            {       

                throw new Exception(ex.Message);
            }

            return Ok("Dados atualizado com sucesso");
        }
    }
}
