namespace examen01_POO.Api.Entities
{
    public class InversionesEntity
    {
        //Entrad
        public decimal capitalInicial { get; set; }
        public decimal aporteMensual { get; set; }
        public double tasaAnual { get; set; }
        public int años { get; set; }

        // salida
        public decimal capitalFinal { get; set; }
        public decimal ganancias { get; set; }
        public decimal totalAportado { get; set; }
        public double rentPorcentaje { get; set; }
    }
}