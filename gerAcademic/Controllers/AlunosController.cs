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

        public IActionResult Index()
        {
            var list = _alunoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var turmas = _turmaService.FindAll();
            var viewModel = new AlunoFormViewModel { Turmas = turmas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            if(!ModelState.IsValid) // verificacao, validando dados
            {
                var turmas = _turmaService.FindAll();
                var viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
                return View(viewModel);
            }

            _alunoService.Insert(aluno);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var aluno = _alunoService.FindById(id.Value);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _alunoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var aluno = _alunoService.FindById(id.Value);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            return View(aluno);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido." });
            }

            var aluno = _alunoService.FindById(id.Value);
            if (aluno == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            }

            List<Turma> turmas = _turmaService.FindAll();
            AlunoFormViewModel viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Aluno aluno)
        {
            if (!ModelState.IsValid) // verificacao, validando dados
            {
                var turmas = _turmaService.FindAll();
                var viewModel = new AlunoFormViewModel { Aluno = aluno, Turmas = turmas };
                return View(viewModel);
            }

            if (id != aluno.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id incompatível." });
            }
            try 
            { 
                _alunoService.Update(aluno);
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
