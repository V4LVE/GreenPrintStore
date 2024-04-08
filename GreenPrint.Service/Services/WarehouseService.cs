﻿using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Repositories;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Services
{
    public class WarehouseService(MappingService mappingService, IWarehouseRepository warehouseRepository) : GenericService<WarehouseDTO, IWarehouseRepository, Warehouse>(mappingService, warehouseRepository), IWarehouseService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IWarehouseRepository _WarehouseRepository = warehouseRepository;

        #endregion
    }
}
