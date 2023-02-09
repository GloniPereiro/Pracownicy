using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.domain.Model
{
    public class ListaPracownikow
    {
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        
        public int NiezakonczoneZadania { get; set; }


    }
}
