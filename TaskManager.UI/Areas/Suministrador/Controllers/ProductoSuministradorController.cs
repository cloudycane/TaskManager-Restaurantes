﻿using Microsoft.AspNetCore.Mvc;
using TaskManager.Aplicacion.Interfaces;
using TaskManager.Aplicacion.Servicios;
using TaskManager.Dominio.Entidades;
using TaskManager.Dominio.Enum;
using TaskManager.Infraestructura.Data;
using TaskManager.Infraestructura.Repositorios;
using TaskManager.UI.ViewModels;

namespace TaskManager.UI.Areas.Suministrador.Controllers
{
    [Area("Suministrador")]
    public class ProductoSuministradorController : Controller
    {
        private readonly ProductoSuministradorService _productoSuministradorService;
        private readonly IProductoSuministradorRepositorio _productoSuministradorRepositorio;
        private readonly ISuministradorRepositorio _suministradorRepositorio;
        private readonly IOrdenarProductoSuministradorRepositorio _ordenarProductoSuministradorRepositorio;
        private readonly IUnitofWork _unitOfWork; 
       
        public ProductoSuministradorController(ProductoSuministradorService productoSuministradorService, IProductoSuministradorRepositorio productoSuministradorRepositorio, ISuministradorRepositorio suministradorRepositorio, ApplicationDbContext context, IOrdenarProductoSuministradorRepositorio ordenarProductoSuministradorRepositorio, IUnitofWork unitOfWork)
        {
            _productoSuministradorService = productoSuministradorService;
            _productoSuministradorRepositorio = productoSuministradorRepositorio;
            _suministradorRepositorio = suministradorRepositorio;
            _ordenarProductoSuministradorRepositorio = ordenarProductoSuministradorRepositorio;
            _unitOfWork = unitOfWork;

        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 4)
        {
            var productoSuministrador = await _productoSuministradorRepositorio.ObtenerListadoProductoSuministradorAsync();

            var paginatedList = productoSuministrador.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var viewModel = new ListadoProductosSuministradorViewModel
            {
                Productos = paginatedList,
                PaginaActual = pageNumber,
                PaginasTotal = (int)Math.Ceiling(productoSuministrador.Count() / (double)pageSize)
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var model = new ProductoSuministradorModel
            {
                SuministradorList = await _suministradorRepositorio.ObtenerListadoSuministradorAsync()
            };
            return View(model); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Crear(ProductoSuministradorModel productoSuministrador)
        {
            if(!ModelState.IsValid)
            {
                return View(productoSuministrador);
            }

            await _productoSuministradorRepositorio.CrearProductoSuministradorAsync(productoSuministrador);
            TempData["SuccessMessage"] = "Producto creado exitosamente";
            return RedirectToAction("Index");

        }

        [HttpGet]

        public async Task<IActionResult> Eliminar(int id)
        {

            var productoSuministrador = await _productoSuministradorRepositorio.ObtenerProductoSuministradorPorIdAsync(id);
            if (productoSuministrador == null)
            {
                return NotFound();
            }

            var productoSuministradorDTO = _productoSuministradorService.ConvertToDTO(productoSuministrador);
            return View(productoSuministradorDTO);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmacion(int id)
        {

            var productoSuministrador = await _productoSuministradorRepositorio.ObtenerProductoSuministradorPorIdAsync(id);
            if (productoSuministrador == null)
            {
                return NotFound();
            }

            await _productoSuministradorRepositorio.EliminarProductoSuministradorAsync(id);
            TempData["SuccessMessage"] = "Enhorabuena, ha sido eliminada exitosamente";
            return RedirectToAction("Index");

        }

        [HttpGet]

        public async Task<IActionResult> Editar(int id)
        {
            var producto = await _productoSuministradorRepositorio.ObtenerProductoSuministradorPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            var suministradores = await _suministradorRepositorio.ObtenerListadoSuministradorAsync();
            var productoDTO = _productoSuministradorService.ConvertToDTO(producto);
            productoDTO.SuministradorList = suministradores;
            return View(productoDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Editar(ProductoSuministradorModel producto)
        {
            if (!ModelState.IsValid)
            {
                var dto = _productoSuministradorService.ConvertToDTO(producto);
                return View(dto);
            }

            await _productoSuministradorRepositorio.ActualizarProductoSuministradorAsync(producto);
            TempData["SuccessMessage"] = "Enhorabuena, ha sido editada exitosamente";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Ordenes(int pageNumber = 1, int pageSize = 4)
        {
            var ordenes = await _ordenarProductoSuministradorRepositorio.ObtenerListadoOrdenarProductoSuministradorAsync();

            var paginatedList = ordenes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new ListadoOrdenesAdquisicionViewModel
            {
                OrdenesAdquisicion = paginatedList,
                PaginaActual = pageNumber,
                PaginasTotal = (int)Math.Ceiling(ordenes.Count() / (double)pageSize)
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ordenar(int productoId, int productoCantidad, OrdenAdquisicionModel ordenAdquisicion)
        {
            await _productoSuministradorRepositorio.OrdenarProducto(productoId, productoCantidad, ordenAdquisicion);

            return RedirectToAction("Ordenes");
        }

        public async Task<IActionResult> AprobarOrden(int id)
        {
            
            var carritoItem = await _ordenarProductoSuministradorRepositorio.ObtenerOrdenProductoPorIdAsync(id);

            if (carritoItem != null)
            {
                carritoItem.Estado = EstadoOrdenProductoSuministradorEnum.Aprobado;
                await _unitOfWork.GuardarAsync();
            }

            TempData["SuccessMessage"] = "Orden aprobada exitosamente";
            return RedirectToAction("Ordenes");

        }

        public async Task<IActionResult> RechazarOrden(int id)
        {

            var carritoItem = await _ordenarProductoSuministradorRepositorio.ObtenerOrdenProductoPorIdAsync(id);

            if (carritoItem != null)
            {
                carritoItem.Estado = EstadoOrdenProductoSuministradorEnum.Rechazado;
                await _unitOfWork.GuardarAsync();
            }

            TempData["SuccessMessage"] = "Orden rechazada exitosamente";
            return RedirectToAction("Ordenes");
        }

        public async Task<IActionResult> ObtenerProductosSuministradoresCSV()
        {
            MemoryStream memoryStream = await _productoSuministradorRepositorio.ObtenerProductoSuministradorCsv();
            return File(memoryStream, "application/octet-stream", "ListadoProductosSuministradores.csv");
        }

        public async Task<IActionResult> ObtenerListadoProductosSuministradoresExcel()
        {
            MemoryStream memoryStream = await _productoSuministradorRepositorio.ObtenerListadoProductoSuministradorExcel();
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheet", "LibroListadoProductosSuministradores.xlsx");
        }

        public async Task<IActionResult> ObtenerOrdenesProductosSuministradoresCSV()
        {
            MemoryStream memoryStream = await _ordenarProductoSuministradorRepositorio.ObtenerListadoOrdenesProductosSuministradoresCsv();
            return File(memoryStream, "application/octet-stream", "ListadoOrdenesProductosSuministradores.csv");
        }

        public async Task<IActionResult> ObtenerOrdenesProductosSuministradoresExcel()
        {
            MemoryStream memoryStream = await _ordenarProductoSuministradorRepositorio.ObtenerListadoOrdenesProductosSuministradoresExcel();
            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheet", "LibroListadoOrdenesProductosSuministradores.xlsx");

        }
    }
}