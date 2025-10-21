using Microsoft.AspNetCore.Mvc;
using examen01_POO.Api.Entities;

namespace examen01_POO.Api.Controllers
{
    [ApiController] 
    [Route("api/inversiones")] 
    public class InversionesController : ControllerBase
    {
        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] InversionesEntity inver)
        {
            if (inver.años < 0 || inver.tasaAnual < 0)
                return Ok("Los años con la tasa anual deben ser mayores a 0.");

            double r = inver.tasaAnual / 100.0;
            int n = inver.años;
            double P = (double)inver.capitalInicial;
            double A = (double)inver.aporteMensual;

            double VF_inicial = P * Math.Pow(1 + r, n);
            double VF_aporte = 0;

            if (A > 0)
            {
                if (r > 0)
                {
                    double rMensual = r / 12.0;
                    int totalMeses = n * 12;
                    VF_aporte = A * ((Math.Pow(1 + rMensual, totalMeses) - 1) / rMensual);
                }
                else
                {
                    VF_aporte = A * n * 12;
                }
            }

            double capitalFinal = VF_inicial + VF_aporte;
            double totalAportado = P + A * n * 12;
            double ganancias = capitalFinal - totalAportado;

            return Ok(new InversionesEntity{
                capitalInicial = inver.capitalInicial,
                aporteMensual = inver.aporteMensual,
                tasaAnual = inver.tasaAnual,
                años = inver.años,

                capitalFinal = Math.Round((decimal)capitalFinal, 2),
                ganancias = Math.Round((decimal)ganancias, 2),
                totalAportado = Math.Round((decimal)totalAportado, 2),
            });
        }
    }
}