using Crud.domain.Model;
using Crud.domain.Services;
using Crud.EF.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Crud.EF
{
    public class ListaPracownikowCrudServices : ICrud
    {
        private readonly IDataService<ListaPracownikow> _crudServices;

        public ListaPracownikowCrudServices()
        {
            _crudServices = new GenericDataService<ListaPracownikow>(new ProductContextFactory());
        }

        public async Task<ListaPracownikow> AddBrand(string name)
        {
           
            
            try
            {
               
                if (name == string.Empty)
                {
                    throw new Exception("Employee Name Cannot be Empty");
                }
                else
                {
                    ListaPracownikow br = new ListaPracownikow
                    {
                        Imie = name,
                        
                };
                    return await _crudServices.Create(br);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                ListaPracownikow delete = await SearchBrandbyID(id);

                return await _crudServices.Delete(delete);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ICollection<ListaPracownikow>> ListBrands()
        {
            try
            {
                return (ICollection<ListaPracownikow>)await _crudServices.GetAll();


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Task<ListaPracownikow> SearchBrandbyID(int ID)
        {
            try
            {
                return _crudServices.Get(ID);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<ListaPracownikow>> SearchBrandByName(string name)
        {
            try
            {
                var listbrand = await ListBrands();
                return listbrand.Where(x => x.Imie.StartsWith(name)).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<ListaPracownikow> UpdateBrand(int id, string name)
        {
            try
            {
                ListaPracownikow br = await SearchBrandbyID(id);
                br.Imie = name;
                return await _crudServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public async Task<ListaPracownikow> UpdateNiezakonczone(int id)
        {
            try
            {
                ListaPracownikow br = await SearchBrandbyID(id);
                br.NiezakonczoneZadania +=1;
                return await _crudServices.Update(br);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}
