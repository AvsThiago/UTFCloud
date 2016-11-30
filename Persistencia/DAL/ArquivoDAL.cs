using Modelo;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ArquivoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterArquivosPorRA(long ra)
        {
            IQueryable<Arquivos> retorno = context.arquivos.Where(p => p.RA == ra).OrderBy(n => n.NomeArquivo);
            return retorno;
        }

        public Arquivos ObterArquivoId(long id, string senha)
        {
            return context.arquivos.Where(p => p.ArquivosID == id && p.Senha == senha).FirstOrDefault();
        }

        public void GravarArquivo(List<Arquivos> arquivo)
        {
            if (arquivo.Count > 0)
                foreach (var item in arquivo)
                    context.arquivos.Add(item);

            context.SaveChanges();
        }

        public Arquivos EliminarArquivoPorId(long id)
        {
            // TODO: implementar se necessário
            //Arquivos arquivo = ObterArquivoId(id);
            //context.arquivos.Remove(arquivo);
            //context.SaveChanges();
            //return arquivo;
            return null;
        }
    }
}
