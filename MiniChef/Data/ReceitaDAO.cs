using MiniChef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Data
{
    public class ReceitaDAO
    {
        public static IEnumerable<ReceitaModel> GetReceitas()
        {
            List<ReceitaModel> lista = null;

            lista = new List<ReceitaModel>();

            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaReceitas.OrderBy(d => d.nome);

                foreach (ReceitaModel receita in query)
                {
                    lista.Add(receita);
                }
            }

            return lista;
        }

        internal static int Save(ReceitaModel novaReceita)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                db.TabelaReceitas.InsertOnSubmit(novaReceita);

                db.SubmitChanges();

                return novaReceita.id;
            }
        }

        internal static void Remove(ReceitaModel receita)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaReceitas.Where(d => d.id == receita.id);

                if (query.Count() > 0)
                {
                    db.TabelaReceitas.DeleteOnSubmit(query.First());

                    db.SubmitChanges();
                }
            }
        }

    }
}
