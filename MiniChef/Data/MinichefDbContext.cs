using MiniChef.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChef.Data
{
    public class MinichefDbContext : DataContext
    {
        public static string ConnectionString = "Data Source=isostore:/minichefDB.sdf";

        public static void CreateDataBase()
        {
            using (MinichefDbContext db = new MinichefDbContext(MinichefDbContext.ConnectionString))
            {
                if (!db.DatabaseExists())
                {
                    db.CreateDatabase();
                }
            }
        }


        private Table<ReceitaModel> _tabelaReceitas;
        public Table<ReceitaModel> TabelaReceitas
        {
            get
            {
                if (this._tabelaReceitas == null)
                    this._tabelaReceitas = this.GetTable<ReceitaModel>();

                return this._tabelaReceitas;
            }
        }


        private Table<ReceitaCategoriaModel> _tabelaReceitaCategoria;
        public Table<ReceitaCategoriaModel> TabelaReceitaCategoria
        {
            get
            {
                if (this._tabelaReceitaCategoria == null)
                    this._tabelaReceitaCategoria = this.GetTable<ReceitaCategoriaModel>();

                return this._tabelaReceitaCategoria;
            }
        }


        private Table<ItemIngredienteModel> _tabelaItemIngrediente;
        public Table<ItemIngredienteModel> TabelaItemIngrediente
        {
            get
            {
                if (this._tabelaItemIngrediente == null)
                    this._tabelaItemIngrediente = this.GetTable<ItemIngredienteModel>();

                return this._tabelaItemIngrediente;
            }
        }


        private Table<IngredienteModel> _tabelaIngredientes;
        public Table<IngredienteModel> TabelaIngredientes
        {
            get
            {
                if (this._tabelaIngredientes == null)
                    this._tabelaIngredientes = this.GetTable<IngredienteModel>();

                return this._tabelaIngredientes;
            }
        }


        private Table<CategoriaModel> _tabelaCategorias;
        public Table<CategoriaModel> TabelaCategorias
        {
            get
            {
                if (this._tabelaCategorias == null)
                    this._tabelaCategorias = this.GetTable<CategoriaModel>();

                return this._tabelaCategorias;
            }
        }

        public MinichefDbContext(string connectionString)
            :base(connectionString)
        {

        }
    }
}
