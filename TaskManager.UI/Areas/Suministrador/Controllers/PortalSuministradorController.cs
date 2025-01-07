﻿using Microsoft.AspNetCore.Mvc;
using TaskManager.Aplicacion.Interfaces;
using TaskManager.Aplicacion.Servicios;
using TaskManager.Dominio.Entidades;
using TaskManager.Infraestructura.Repositorios;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI.Areas.Suministrador.Controllers
{
    [Area("Suministrador")]
    public class PortalSuministradorController : Controller
    {
        private readonly SuministradorService _suministradorService;
        private readonly ISuministradorRepositorio _suministradorRepositorio;

        public PortalSuministradorController(SuministradorService suministradorService, ISuministradorRepositorio suministradorRepositorio)
        {
            _suministradorService = suministradorService;
            _suministradorRepositorio = suministradorRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var suministradores = await _suministradorRepositorio.ObtenerListadoSuministradorAsync();

            var viewModel = new ListadoSuministradoresViewModel
            {
                ListadoSuministradores = suministradores
            };

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Crear(SuministradorModel suministrador)
        {
            if (ModelState.IsValid)
            {
                await _suministradorRepositorio.CrearSuministradorAsync(suministrador);
                TempData["SuccessMessage"] = "Enhorabuena, ha sido creada exitosamente";
                return RedirectToAction("Index");
            }
            return View(suministrador);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var suministrador = await _suministradorRepositorio.ObtenerSuministradorPorIdAsync(id);
            if (suministrador == null)
            {
                return NotFound();
            }
            var suministradorDTO = _suministradorService.ConvertToDTO(suministrador);
            return View(suministradorDTO);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmacion(int id)
        {

            var reservacion = await _suministradorRepositorio.ObtenerSuministradorPorIdAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }
            await _suministradorRepositorio.EliminarSuministrador(id);
            TempData["SuccessMessage"] = "Enhorabuena, ha sido eliminada exitosamente";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var suministrador = await _suministradorRepositorio.ObtenerSuministradorPorIdAsync(id);
            if (suministrador == null)
            {
                return NotFound();
            }
            var suministradorDTO = _suministradorService.ConvertToDTO(suministrador);
            return View(suministradorDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(SuministradorModel suministrador)
        {
            if (!ModelState.IsValid)
            {
                var dto = _suministradorService.ConvertToDTO(suministrador);
                return View(dto);
            }
            await _suministradorRepositorio.ActualizarSuministrador(suministrador);
            TempData["SuccessMessage"] = "Enhorabuena, ha sido editada exitosamente";
            return RedirectToAction("Index");
        }
    }
}