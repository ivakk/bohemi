﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDAL
{
    public interface IBeverageDAL
    {
        int GetNextId();
        bool CreateBeverageDAL(BeverageDTO newBeverage);
        bool DeleteBeverageDAL(int id);
        bool UpdateBeverageDAL(BeverageDTO updateBeverage);
    }
}
