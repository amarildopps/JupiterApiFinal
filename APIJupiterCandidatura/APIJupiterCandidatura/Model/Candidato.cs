using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJupiterCandidatura.Model
{
    public class Candidato
    {
        public int ID { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String NumIdentificacao { get; set; }
        public List<Candidatura> Candidaturas { get; set; }
        public String FicheiroCurriculo { get; set; }
    }
}
