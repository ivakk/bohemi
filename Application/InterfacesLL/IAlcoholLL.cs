using Classes;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLL
{
    public interface IAlcoholLL
    {
        bool CreateAlcohol(AlcoholDTO newAlcohol);
        Alcohol GetAlcoholById(int id);
        bool DeleteAlcohol(int id);
        List<Alcohol> GetAllAlcohols();
        bool UpdateAlcohol(AlcoholDTO newAlcohol);
    }
}
