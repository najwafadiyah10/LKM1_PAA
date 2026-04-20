using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using LKM1.Context;
using LKM1.Models;
using LKM1.Controllers;

namespace LKM1.Controllers 
{
    public class PembeliController : Controller
    {
        public string __constr;
        public PembeliController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/pembeli")]
        public ActionResult<Pembeli> ListPembeli()
        {
            try
            {
                PembeliContext context = new PembeliContext(this.__constr);
                List<Pembeli> listPembeli = context.ListPembeli();

                if (listPembeli == null || !listPembeli.Any())
                {
                    return NotFound(new { status = "error", message = "Data pembeli tidak ditemukan" });
                }

                return Ok(listPembeli);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Terjadi kesalahan: {ex.Message}" });
            }
        }

        [HttpGet("api/pembeli/{id}")]
        public ActionResult<Pembeli> GetPembeliById(int id)
        {
            try
            {
                PembeliContext context = new PembeliContext(this.__constr);
                var listPembeli = context.ListPembeli();
                var pembeli = listPembeli.FirstOrDefault(p => p.id == id);

                if (pembeli == null)
                {
                    return NotFound(new { status = "error", message = "Pembeli dengan ID tersebut tidak ditemukan" });
                }

                return Ok(pembeli);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Terjadi kesalahan: {ex.Message}" });
            }
        }

        [HttpPost("api/pembeli")]
        public ActionResult CreatePembeli(Pembeli pembeli)
        {
            try
            {
                PembeliContext context = new PembeliContext(this.__constr);
                context.AddPembeli(pembeli);
                return Ok(new { status = "success", message = "Pembeli berhasil ditambahkan" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal menambahkan pembeli: {ex.Message}" });
            }
        }

        [HttpPut("api/pembeli/{id}")]
        public ActionResult UpdatePembeli(int id, Pembeli pembeli)
        {
            try
            {
                PembeliContext context = new PembeliContext(this.__constr);
                context.UpdatePembeli(id, pembeli);
                return Ok(new { status = "success", message = "Pembeli berhasil diperbarui" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal memperbarui pembeli: {ex.Message}" });
            }
        }

        [HttpDelete("api/pembeli/{id}")]
        public ActionResult DeletePembeli(int id)
        {
            try
            {
                PembeliContext context = new PembeliContext(this.__constr);
                context.DeletePembeli(id);
                return Ok(new { status = "success", message = "Pembeli berhasil dihapus" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal menghapus pembeli: {ex.Message}" });
            }
        }
    }
}
