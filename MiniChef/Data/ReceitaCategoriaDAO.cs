using MiniChef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Data
{
    public class ReceitaCategoriaDAO
    {
        public static IEnumerable<ReceitaCategoriaModel> GetReceitaCategoria()
        {
            List<ReceitaCategoriaModel> lista = null;

            lista = new List<ReceitaCategoriaModel>();

            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaReceitaCategoria.OrderBy(d => d.id);

                foreach (ReceitaCategoriaModel receitaCategoria in query)
                {
                    lista.Add(receitaCategoria);
                }
            }

            return lista;
        }

        internal static int Save(ReceitaCategoriaModel novaReceitaCategoria)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                db.TabelaReceitaCategoria.InsertOnSubmit(novaReceitaCategoria);

                db.SubmitChanges();

                return novaReceitaCategoria.id;
            }
        }

        internal static void Remove(ReceitaCategoriaModel receitaCategoria)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaReceitaCategoria.Where(d => d.id == receitaCategoria.id);

                if (query.Count() > 0)
                {
                    db.TabelaReceitaCategoria.DeleteOnSubmit(query.First());

                    db.SubmitChanges();
                }
            }
        }
    }
}
