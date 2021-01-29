using RestWithASPNETMesaRadionica.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETMesaRadionica.Model
{
    [Table("chacras")]
    public class Chacras : BaseEntity
    {
       
        [Column("consulenteID")]
        public int ConsulenteID { get; set; }

        [Column("atendenteID")]
        public int AtendenteId { get; set; }

        [Column("data_atendimento")]
        public DateTime DataAtendimento { get; set; }

        [Column("coronario")]
        public int Coronario { get; set; }

        [Column("laringeo")]
        public int Laringeo { get; set; }

        [Column("frontal")]
        public int Frontal { get; set; }

        [Column("basico")]
        public int Basico { get; set; }

        [Column("cardiaco")]
        public int Cardiaco { get; set; }

        [Column("umbilical")]
        public int Umbilical { get; set; }

        [Column("plexosolar")]
        public int PlexoSolar { get; set; }

        [Column("tipo_medicao")]
        public string TipoAtendimento { get; set; }


    }
}
