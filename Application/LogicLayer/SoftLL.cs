using Classes;
using DTOs;
using InterfacesLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;

namespace LogicLayer
{
    public class SoftLL : ISoftLL
    {
        private readonly ISoftDAL _softDAL;
        public SoftLL(ISoftDAL softLL)
        {
            this._softDAL = softLL;
        }
        public bool CreateSoft(SoftDTO newSoft)
        {
            if (newSoft == null)
            {
                return false;
            }
            else if (newSoft.Picture == null || string.IsNullOrEmpty(newSoft.Name) || string.IsNullOrEmpty(newSoft.Size.ToString()) || string.IsNullOrEmpty(newSoft.Price.ToString())
                 || string.IsNullOrEmpty(newSoft.Carbonated.ToString()))
            {
                return false;
            }
            else
            {
                return _softDAL.CreateSoftDAL(newSoft);
            }
        }

        public bool DeleteSoft(int id)
        {
            if (id < 0 || id == null)
            {
                return false;
            }
            else
            {
                return _softDAL.DeleteSoftDAL(id);
            }
        }

        public List<Soft> GetAllSoft()
        {
            return _softDAL.GetAllSoftDAL();
        }

        public Soft GetSoftById(int id)
        {
            if (id < 0 || id == null)
            {
                throw new ArgumentNullException("id");
            }
            else
            {
                return _softDAL.GetSoftByIdDAL(id);
            }
        }

        public bool UpdateSoft(SoftDTO updateSoft)
        {
            if (updateSoft == null)
            {
                return false;
            }
            else if (updateSoft.Picture == null || string.IsNullOrEmpty(updateSoft.Name) || string.IsNullOrEmpty(updateSoft.Size.ToString()) || string.IsNullOrEmpty(updateSoft.Price.ToString())
                 || string.IsNullOrEmpty(updateSoft.Carbonated.ToString()))
            {
                return false;
            }
            else
            {
                return _softDAL.UpdateSoftDAL(updateSoft);
            }
        }
    }
}
