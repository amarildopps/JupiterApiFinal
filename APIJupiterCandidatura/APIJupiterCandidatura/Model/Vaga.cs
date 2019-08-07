using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJupiterCandidatura.Model
{
    public class Vaga
    {
        public int ID { get; set; }
        public String Descricao { get; set; }
        public String Requisitos { get; set; }
        public List<Candidatura> Candidaturas { get; set; }
        public String Imagem { get; set; }
    }
}
