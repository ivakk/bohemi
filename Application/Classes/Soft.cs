﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Soft : Beverage
    {
        public string Carbonated { get; private set; }

        public Soft(int id, byte[] picture, string name, int size, decimal price, string carbonated) : base(id, picture, name, size, price) 
        {
            Carbonated = carbonated;
        }

        public Soft()
        {

        }
    }
}
