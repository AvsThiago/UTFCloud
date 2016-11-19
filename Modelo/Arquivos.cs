using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Arquivos
    {
        public long ArquivosID { get; set; }
        [DisplayName("RA:")]
        [Required(ErrorMessage = "Informe seu Registro acadêmico.")]
        public long RA { get; set; }
        [DisplayName("Senha:")]
        public string Senha { get; set; }
        [DisplayName("Remover em:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime DtSerRemovido { get; set; }
        public byte[] Arquivo { get; set; }
        public string ArquivoMimeType { get; set; }
        public string NomeArquivo { get; set; }
        public long TamanhoArquivo { get; set; }
    }
}
