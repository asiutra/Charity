﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charity.Models.Db
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
