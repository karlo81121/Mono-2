﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeess.Common
{
    public class Paging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Paging(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
    }
}
