using Microsoft.AspNetCore.Mvc;
using AluguelDeItens.Models; // Substitua pelo namespace real do seu projeto
using AluguelDeItens.Context; // Substitua pelo namespace real do seu projeto
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;
using System.Models;
using System.Context;

public class ItensAluguelController : Controller
{
    private readonly AluguelDbContext _context;

    public ItensAluguelController(AluguelDbContext context)
    {
        _context = context;
    }

    // GET: ItensAluguel
    public async Task<IActionResult> Index()
    {
        var itensAluguel = await _context.ItensAluguel.ToListAsync();
        return View(itensAluguel);
    }

    // GET: ItensAluguel/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ItensAluguel/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] ItemAluguel itemAluguel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(itemAluguel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(itemAluguel);
    }

    // GET: ItensAluguel/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var itemAluguel = await _context.ItensAluguel.FindAsync(id);
        if (itemAluguel == null)
        {
            return NotFound();
        }
        return View(itemAluguel);
    }

    // POST: ItensAluguel/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco")] ItemAluguel itemAluguel)
    {
        if (id != itemAluguel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(itemAluguel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemAluguelExists(itemAluguel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(itemAluguel);
    }

    // GET: ItensAluguel/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var itemAluguel = await _context.ItensAluguel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (itemAluguel == null)
        {
            return NotFound();
        }

        return View(itemAluguel);
    }

    // POST: ItensAluguel/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var itemAluguel = await _context.ItensAluguel.FindAsync(id);
        _context.ItensAluguel.Remove(itemAluguel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ItemAluguelExists(int id)
    {
        return _context.ItensAluguel.Any(e => e.Id == id);
    }
}
