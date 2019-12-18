using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gerAcademic.Data;
using gerAcademic.Models;
using gerAcademic.Models.ViewModels;
using gerAcademic.Services;
using gerAcademic.Services.Exceptions;
using System.Diagnostics;

namespace gerAcademic.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AlunoService _alunoService;
        private readonly TurmaService _turmaService;

        public AlunosController(AlunoService alunoService, TurmaService turmaService)
        {
            _alunoService = alunoService;
            _turmaService = turmaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _alunoService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var turmas = await _turmaService.FindAllAsync();
            var viewModel = new AlunoFormViewModel { Turmas = turmas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if(!ModelState.IsValid) // verificacao, validando dados
            {
                var turmas = await _turmaService.FindAllAsync();
                var viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
                return View(viewModel);
            }

            await _alunoService.InsertAsync(aluno);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var aluno = await _alunoService.FindByIdAsync(id.Value);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _alunoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var aluno = await _alunoService.FindByIdAsync(id.Value);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(aluno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var aluno = await _alunoService.FindByIdAsync(id.Value);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            List<Turma> turmas = await _turmaService.FindAllAsync();
            AlunoFormViewModel viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, Aluno aluno)
        {
            if (!ModelState.IsValid) // verificacao, validando dados
            {
                var turmas = await _turmaService.FindAllAsync();
                var viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
                return View(viewModel);
            }

            if (id != aluno.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id incompatível." });
            }
            try 
            { 
                await _alunoService.UpdateAsync(aluno);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
