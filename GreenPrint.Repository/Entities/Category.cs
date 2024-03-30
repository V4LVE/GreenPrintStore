﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation Properties
        public List<Item> Items { get; set; }

    }
}
