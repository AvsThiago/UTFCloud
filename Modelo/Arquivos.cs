using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Arquivos
    {
        public long ArquivosID { get; set; }
        [DisplayName("RA:")]
        public long RA { get; set; }
        [DisplayName("Privado:")]
        public bool StPrivado { get; set; }
        [DisplayName("Senha:")]
        public string Senha { get; set; }
        [DisplayName("Remover em:")]
        public DateTime DtSerRemovido { get; set; }
        public byte[] Arquivo { get; set; }
        public string ArquivoMimeType { get; set; }
        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }
    }
}
