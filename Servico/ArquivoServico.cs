using Modelo;
using Persistencia.Contexts;
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
        private EFContext context = new EFContext();

        public IQueryable ObterArquivosPorRA(long ra)
        {
            return context.arquivos.Where(p => p.RA == ra).OrderBy(n => n.);
        }

        public Arquivos ObterArquivoId(long id)
        {
            return context.arquivos.Where(p => p.ArquivosID == id).FirstOrDefault();
        }

        public void GravarArquivo(Arquivos arquivo)
        {
            if (arquivo.ArquivosID == 0)
            {
                context.arquivos.Add(arquivo);
            }
            else
            {
                context.Entry(arquivo).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Arquivos EliminarArquivoPorId(long id)
        {
            Arquivos arquivo = ObterArquivoId(id);
            context.arquivos.Remove(arquivo);
            context.SaveChanges();
            return arquivo;
        }
    }
}
