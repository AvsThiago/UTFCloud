using Modelo;
using Persistencia.Contexts;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class ArquivoServico
    {
        private ArquivoDAL arquivosDAL = new ArquivoDAL();

        public IQueryable ObterArquivosPorRA(long ra)
        {
            return arquivosDAL.ObterArquivosPorRA(ra);
        }

        public Arquivos ObterArquivoId(long id)
        {
            return arquivosDAL.ObterArquivoId(id);
        }

        public void GravarArquivo(Arquivos arquivos)
        {
            arquivosDAL.GravarArquivo(arquivos);
        }

        public Arquivos EliminarArquivosPorId(long id)
        {
            return arquivosDAL.EliminarArquivoPorId(id);
        }
    }
}
