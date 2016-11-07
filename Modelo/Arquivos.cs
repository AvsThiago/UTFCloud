using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Arquivos
    {
        public long ArquivosID { get; set; }
        public long RA { get; set; }
        public bool StPrivado { get; set; }
        public string Senha { get; set; }
        public DateTime DtSerRemovido { get; set; }
        public byte[] Arquivo { get; set; }
    }
}
