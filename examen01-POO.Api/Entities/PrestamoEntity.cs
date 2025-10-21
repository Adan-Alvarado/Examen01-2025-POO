// examen01_POO.Api.Entities/PrestamoEntity.cs
namespace examen01_POO.Api.Entities
{
    public class PrestamoEntity
    {
        public decimal monto { get; set; }
        public decimal tasaInteresAnual { get; set; } 
        public int plazoMeses { get; set; }
        public decimal CuotaMensual { get; set; }
    }
}