using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETMesaRadionica.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
