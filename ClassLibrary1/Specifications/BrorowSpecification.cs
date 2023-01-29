﻿using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Specifications
{
    public class BrorowSpecification : BaseSpecification<Brorows>
    {
        public BrorowSpecification() : base()
        {

        }
        public BrorowSpecification(int id) : base(x => x.Id == id)
        {

        }
    }
}
