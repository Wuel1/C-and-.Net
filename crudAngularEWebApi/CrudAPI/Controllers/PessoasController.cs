using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly ContextDB _context;

        public PessoasController(ContextDB context)
        {
            _context = context;
        }

        // Pegar todas as pessoas

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas(){
            return await _context.Pessoas.ToListAsync();
        }

        // Pegar pessoa por ID 

        [HttpGet("{UserID}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int UserID){
            Pessoa pessoa = await _context.Pessoas.FindAsync(UserID);

            if(pessoa == null){
                return NotFound();
            }

            return pessoa;
        }

        // Adicionar uma pessoa

        [HttpPost]
        public async Task<ActionResult> PostPessoa(Pessoa pessoa){
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Atualizar uma pessoa

        [HttpPut]
        public async Task<ActionResult> PutPessoa(Pessoa pessoa){
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Deletar uma pessoa

        [HttpDelete("{UserID}")]
        public async Task<ActionResult> DeletePessoa(int UserID){
            Pessoa pessoa = await _context.Pessoas.FindAsync(UserID);
            if(pessoa == null){
                return NotFound();
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}