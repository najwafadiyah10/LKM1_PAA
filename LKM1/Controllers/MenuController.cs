using LKM1.Context;
using LKM1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LKM1.Controllers
{
    public class MenuController : Controller
        {
            public string __constr;
            public MenuController(IConfiguration configuration)
            {
                __constr = configuration.GetConnectionString("WebApiDatabase");
            }

            public IActionResult Index()
            {
                return View();
            }

            [HttpGet("api/menu")]
            public ActionResult<Menu> ListMenu()
            {
            try
            {
                MenuContext context = new MenuContext(this.__constr);
                List<Menu> listMenu = context.ListMenu();

                if (listMenu == null || !listMenu.Any())
                {
                    return NotFound(new { status = "error", message = "Data menu tidak ditemukan" });
                }

                return Ok(listMenu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Terjadi kesalahan: {ex.Message}" });
            }
        }

            [HttpGet("api/menu/{id}")]
            public ActionResult<Menu> GetMenuById(int id)
            {
            try
            {
                MenuContext context = new MenuContext(this.__constr);
                var listMenu = context.ListMenu();
                var menu = listMenu.FirstOrDefault(p => p.id == id);

                if (menu == null)
                {
                    return NotFound(new { status = "error", message = "Menu dengan ID tersebut tidak ditemukan" });
                }

                return Ok(menu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Terjadi kesalahan: {ex.Message}" });
            }
        }

            [HttpPost("api/menu")]
            public ActionResult CreateMenu(Menu menu)
            {
            try
            {
                MenuContext context = new MenuContext(this.__constr);
                context.AddMenu(menu);
                return Ok(new { status = "success", message = "Menu berhasil ditambahkan" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal menambahkan menu: {ex.Message}" });
            }
        }

            [HttpPut("api/menu/{id}")]
            public ActionResult UpdateMenu(int id, Menu menu)
            {
            try
            {
                MenuContext context = new MenuContext(this.__constr);
                context.UpdateMenu(id, menu);
                return Ok(new { status = "success", message = "Menu berhasil diperbarui" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal memperbarui menu: {ex.Message}" });
            }
        }

            [HttpDelete("api/menu/{id}")]
            public ActionResult DeleteMenu(int id)
            {
            try
            {
                MenuContext context = new MenuContext(this.__constr);
                context.DeleteMenu(id);
                return Ok(new { status = "success", message = "Menu berhasil dihapus" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "error", message = $"Gagal menghapus menu: {ex.Message}" });
            }
        }
    }
}
