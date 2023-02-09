using Crud.domain.Model;
using Crud.domain.Services;
using Crud.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.EF
{
    public class ListaZadanCrudServices : ICrud
    {
        private readonly IDataService<ListaZadan> _HistoryServices;

        public ListaZadanCrudServices()
        {
            _HistoryServices = new GenericDataService<ListaZadan>(new ProductContextFactory());
        }

        public async Task<ListaZadan> AddHistoryBrand(string name, string opis, string pracownik)
        {
            try
            {
                if (name == string.Empty)
                {
                    throw new Exception("Category Name Cannot be Empty");
                }
                else
                {
                    ListaZadan br = new ListaZadan
                    {
                        KategoriaZadania = name,
                        OpisZadania = opis,
                        Pracownik = pracownik,

                    };


                   
                    return await _HistoryServices.Create(br);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteHistoryBrand(int id)
        {
            try
            {
                ListaZadan delete = await SearchHistoryBrandbyID(id);

                return await _HistoryServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ICollection<ListaZadan>> ListHistoryBrands()
        {
            try
            {
                

                return (ICollection<ListaZadan>)await _HistoryServices.GetAll();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Task<ListaZadan> SearchHistoryBrandbyID(int ID)
        {
            try
            {

                return _HistoryServices.Get(ID);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<ListaZadan>> SearchHistoryBrandByName(string name)
        {
            try
            {
                var listhistorybrand = await ListHistoryBrands();
                return listhistorybrand.Where(x => x.Pracownik.StartsWith(name)).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<ListaZadan> UpdateHistoryBrand(int id, string name)
        {
            try
            {
                ListaZadan br = await SearchHistoryBrandbyID(id);
                return await _HistoryServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }


    }
}
