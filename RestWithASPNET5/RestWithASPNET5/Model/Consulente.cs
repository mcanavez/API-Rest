using RestWithASPNETMesaRadionica.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETMesaRadionica.Model
{

    [Table("consulente")]
    public class Consulente: BaseEntity
    {
       
        [Column("nome")]
        public string Nome { get; set; }

        [Column("sobrenome")]
        public string Sobrenome  { get; set; }

        [Column("endereco")]
        public string Endereco  { get; set; }

        [Column("telefone")]
        public string telefone { get; set; }

        [Column("celular")]
        public string celular { get; set; }

        [Column("data_aniversario")]
        public DateTime DataNascimento { get; set; }

        [Column("idade")]
        public string Sexo { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; }
        
        

        

    }
}
