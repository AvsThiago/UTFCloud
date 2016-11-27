using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTFCloud.Models
{
    public class SegurancaViewModels
    {
        public class LoginViewModel
        {

            [Required]
            public string Nome { get; set; }
            [Required]
            public string Senha { get; set; }
        }

        public class MudaSenhaAdminModel
        {
            public string Id { get; set; }
            
            [DisplayName("Nome:")]
            public string Nome { get; set; }
            [DisplayName("Senha:")]
            public string Senha { get; set; }
            [Required]
            [DisplayName("Nova Senha:")]
            public string NovaSenha { get; set; }
            [Required]
            [DisplayName("Nova Senha Novamente:")]
            public string NovaSenhaNovamente { get; set; }
        }
    }
}