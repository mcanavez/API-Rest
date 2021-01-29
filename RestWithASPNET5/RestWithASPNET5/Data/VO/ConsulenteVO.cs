using RestWithASPNETMesaRadionica.HyperMedia;
using RestWithASPNETMesaRadionica.HyperMedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithASPNETMesaRadionica.Data.VO
{
    public class ConsulenteVO :ISupportHyperMedia
    {

        public long id { get; set; }
       
        public string Nome { get; set; }
        
        public string Sobrenome { get; set; }
       
        public string Endereco { get; set; }
       
        public string telefone { get; set; }
        
        public string celular { get; set; }
        
        public DateTime DataNascimento { get; set; }
       
        public string Sexo { get; set; }
       
        public string Emmail { get; set; }
        public bool Enabled { get; set; }
        public List<HyperMediaLink> Link { get; set; } = new List<HyperMediaLink>();
    }
}
