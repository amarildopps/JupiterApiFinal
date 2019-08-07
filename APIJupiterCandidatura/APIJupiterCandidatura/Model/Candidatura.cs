using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJupiterCandidatura.Model
{
    public class Candidatura
    {
        public int ID { get; set; }
        public int IDCandidato { get; set; }
        public Candidato Candidato { get; set; }
        public int IDVaga { get; set; }
        public Vaga Vaga { get; set; }
    }
}
