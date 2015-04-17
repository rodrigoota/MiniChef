using MiniChef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Data
{
    public class IngredienteDAO
    {
        public static IEnumerable<IngredienteModel> GetIngredientes()
        {
            List<IngredienteModel> lista = null;

            lista = new List<IngredienteModel>();

            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaIngredientes.OrderBy(d => d.id);

                foreach (IngredienteModel ingrediente in query)
                {
                    lista.Add(ingrediente);
                }
            }

            return lista;
        }

        internal static int Save(IngredienteModel novoIngrediente)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                db.TabelaIngredientes.InsertOnSubmit(novoIngrediente);

                db.SubmitChanges();

                return novoIngrediente.id;
            }
        }

        internal static void Remove(IngredienteModel ingrediente)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaIngredientes.Where(d => d.id == ingrediente.id);

                if (query.Count() > 0)
                {
                    db.TabelaIngredientes.DeleteOnSubmit(query.First());

                    db.SubmitChanges();
                }
            }
        }
    }
}
