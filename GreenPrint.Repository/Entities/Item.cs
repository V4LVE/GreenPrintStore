﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public List<WarehouseItem>? warehouseItems { get; set; }
        public List<ItemImage>? ItemImages { get; set; }
    }
}
