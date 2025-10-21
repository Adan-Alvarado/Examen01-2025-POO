using examen01_POO.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraPrestamos.Controllers
{
    [ApiController]
    [Route("api/prestamo")]
    public class PrestamoController : ControllerBase
    {
        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] PrestamoEntity prest)
        {
            if (prest.monto <= 0 || prest.tasaInteresAnual < 0 || prest.plazoMeses <= 0)
            {
                return Ok("Los valores deben ser positivos.");
            }

            decimal tasaMensual = prest.tasaInteresAnual / 12 / 100;

            if (tasaMensual == 0)
            {
                decimal cuotaprest = prest.monto / prest.plazoMeses;
                return Ok(new PrestamoEntity { CuotaMensual = Math.Round(cuotaprest, 2) });
            }

            double r = (double)tasaMensual;
            double n = prest.plazoMeses;
            double monto = (double)prest.monto;

            double factor = Math.Pow(1 + r, n);
            double cuotaDouble = monto * (r * factor) / (factor - 1);


            decimal cuota = (decimal)cuotaDouble;
            cuota = Math.Round(cuota, 2);

            return Ok(new PrestamoEntity { CuotaMensual = cuota });
        }
    }
}