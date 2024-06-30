using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeblitAPI.Domain.Entities
{
    public class PeblitItem
    {
        public int Id { get; set; }
        public string? NomePlanta { get; set; }
        public string? Temperatura { get; set; }
        public string? Umidade { get; set; }
        public string? UmidadeSolo { get; set; }
        public string? Luminosidade { get; set; }
        public int Pontos { get; set; }
        public int IdFundoAtual { get; set; }
        public int IdRoupaAtual { get; set; }
    }
}
