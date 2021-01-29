using System;

namespace RestWithASPNETMesaRadionica.Data.VO
{
    public class ChacrasVO
    {
        public long id { get; set; }
       
        public int ConsulenteID { get; set; }

        
        public int AtendenteId { get; set; }

       
        public DateTime DataAtendimento { get; set; }

        
        public int Coronario { get; set; }

       
        public int Laringeo { get; set; }

       
        public int Frontal { get; set; }

        
        public int Basico { get; set; }

       
        public int Cardiaco { get; set; }

       
        public int Umbilical { get; set; }

       
        public int PlexoSolar { get; set; }

        public string TipoAtendimento { get; set; }
    }
}
