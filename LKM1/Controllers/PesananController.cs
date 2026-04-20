using LKM1.Context;
using LKM1.Models;
using Microsoft.AspNetCore.Mvc;

namespace LKM1.Controllers
{
    public class PesananController : Controller
    {
        public string __constr;
        public PesananController(IConfiguration configuration)
        {
            __constr = configuration.GetConnectionString("WebApiDatabase");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/pesanan")]
        public ActionResult<Pesanan> ListPesanan()
        {
            PesananContext context = new PesananContext(this.__constr);
            List<Pesanan> ListPesanan = context.ListPesanan();
            return Ok(ListPesanan);
        }


        [HttpGet("api/pesanan/{id}")]
        public ActionResult<Pesanan> GetPesananById(int id)
        {
            PesananContext context = new PesananContext(this.__constr);
            var listPesanan = context.ListPesanan();
            var pesanan = listPesanan.FirstOrDefault(p => p.id == id);

            if (pesanan == null)
            {
                return NotFound();
            }

            return Ok(pesanan);
        }

        [HttpPost("api/pesanan")]
        public ActionResult CreatePesanan(Pesanan pesanan)
        {
            PesananContext context = new PesananContext(this.__constr);
            context.AddPesanan(pesanan);
            return Ok();
        }

        [HttpPut("api/pesanan/{id}")]
        public ActionResult UpdatePesanan(int id, Pesanan pesanan)
        {
            PesananContext context = new PesananContext(this.__constr);
            context.UpdatePesanan(id, pesanan);
            return Ok();
        }

        [HttpDelete("api/pesanan/{id}")]
        public ActionResult DeletePesanan(int id)
        {
            PesananContext context = new PesananContext(this.__constr);
            context.DeletePesanan(id);
            return Ok();
        }
    }
}
