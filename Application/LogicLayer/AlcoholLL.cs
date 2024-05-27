using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using DTOs;
using InterfacesLL;
using InterfacesDAL;

namespace LogicLayer
{
    public class AlcoholLL : IAlcoholLL
    {
        private readonly IAlcoholDAL _alcoholDAL;

        public AlcoholLL(IAlcoholDAL alcoholDAL)
        {
            this._alcoholDAL = alcoholDAL;
        }
        public bool CreateAlcohol(AlcoholDTO newAlcohol)
        {
            if (newAlcohol == null)
            {
                return false;
            }
            else if (newAlcohol.Picture == null || string.IsNullOrEmpty(newAlcohol.Name) || string.IsNullOrEmpty(newAlcohol.Size.ToString()) || string.IsNullOrEmpty(newAlcohol.Price.ToString())
                 || string.IsNullOrEmpty(newAlcohol.Percentage.ToString()) || string.IsNullOrEmpty(newAlcohol.Age.ToString()))
            {
                return false;
            }
            else
            {
                return _alcoholDAL.CreateAlcoholDAL(newAlcohol);
            }
        }

        public bool DeleteAlcohol(int id)
        {
            if (id < 0 || id == null)
            {
                return false;
            }
            else
            {
                return _alcoholDAL.DeleteAlcoholDAL(id);
            }
        }

        public Alcohol GetAlcoholById(int id)
        {
            if (id < 0 || id == null)
            {
                throw new ArgumentNullException("id");
            }
            else
            {
                return _alcoholDAL.GetAlcoholByIdDAL(id);
            }
        }

        public List<Alcohol> GetAllAlcohols()
        {
            return _alcoholDAL.GetAllAlcoholsDAL();
        }

        public bool UpdateAlcohol(AlcoholDTO newAlcohol)
        {
            if (newAlcohol == null)
            {
                return false;
            }
            else if (newAlcohol.Picture == null || string.IsNullOrEmpty(newAlcohol.Name) || string.IsNullOrEmpty(newAlcohol.Size.ToString()) || string.IsNullOrEmpty(newAlcohol.Price.ToString())
                 || string.IsNullOrEmpty(newAlcohol.Percentage.ToString()) || string.IsNullOrEmpty(newAlcohol.Age.ToString()))
            {
                return false;
            }
            else
            {
                return _alcoholDAL.UpdateAlcoholDAL(newAlcohol);
            }
        }
    }
}
