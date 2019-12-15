using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gerAcademic.Data;
using gerAcademic.Models;
using gerAcademic.Services;

namespace gerAcademic.Controllers
{
    public class TurmasController : Controller
    {
        private readonly TurmaService _turmaService;

        public TurmasController(TurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        public IActionResult Index()
        {
            var list = _turmaService.FindAll();
            return View(list);
        }

    }
}
