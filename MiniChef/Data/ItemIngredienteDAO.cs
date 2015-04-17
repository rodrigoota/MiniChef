using MiniChef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Data
{
    public class ItemIngredienteDAO
    {
        public static IEnumerable<ItemIngredienteModel> GetItemIngrediente()
        {
            List<ItemIngredienteModel> lista = null;

            lista = new List<ItemIngredienteModel>();

            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaItemIngrediente.OrderBy(d => d.id);

                foreach (ItemIngredienteModel itemIngrediente in query)
                {
                    lista.Add(itemIngrediente);
                }
            }

            return lista;
        }

        internal static int Save(ItemIngredienteModel novoItemIngrediente)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                db.TabelaItemIngrediente.InsertOnSubmit(novoItemIngrediente);

                db.SubmitChanges();

                return novoItemIngrediente.id;
            }
        }

        internal static void Remove(ItemIngredienteModel itemIngrediente)
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                var query = db.TabelaItemIngrediente.Where(d => d.id == itemIngrediente.id);

                if (query.Count() > 0)
                {
                    db.TabelaItemIngrediente.DeleteOnSubmit(query.First());

                    db.SubmitChanges();
                }
            }
        }
    }
}
