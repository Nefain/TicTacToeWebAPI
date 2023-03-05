using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_Tac_ToeWebAPI.Models;
using Tic_Tac_ToeWebAPI.Storage;

namespace Tic_Tac_ToeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicTacToesController : ControllerBase
    {
        private readonly AutoDataContext db;

        public TicTacToesController(AutoDataContext context)
        {
            db = context;
        }

        // GET: api/TicTacToes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicTacToe>>> GetTicTacToes()
        {
            return await db.TicTacToes.ToListAsync();
        }

        // GET: api/TicTacToes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicTacToe>> GetTicTacToe(int id)
        {
            var ticTacToe = await db.TicTacToes.FindAsync(id);

            if (ticTacToe == null)
            {
                return NotFound();
            }

            return ticTacToe;
        }

        // POST: api/TicTacToes
        [HttpPost]
        public async Task<ActionResult<TicTacToe>> PostTicTacToe(TicTacToe ticTacToe)
        {
            await db.TicTacToes.AddAsync(ticTacToe);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetTicTacToe", new { id = ticTacToe.Id }, ticTacToe);
        }

        // DELETE: api/TicTacToes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicTacToe(int id)
        {
            var ticTacToe = await db.TicTacToes.FindAsync(id);
            if (ticTacToe == null)
            {
                return NotFound();
            }

            db.TicTacToes.Remove(ticTacToe);
            await db.SaveChangesAsync();

            return NoContent();
        }

        private bool TicTacToeExists(int id)
        {
            return db.TicTacToes.Any(e => e.Id == id);
        }
    }
}
