using AutoMapper;
using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GreenPrint.Services.Services
{
    public class MappingService
    {
        public readonly AutoMapper.IMapper _mapper;

        public MappingService()
        {
            AutoMapper.MapperConfiguration config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDTO>();
                cfg.CreateMap<AddressDTO, Address>();

                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();

                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();

                cfg.CreateMap<Item, ItemDTO>();
                cfg.CreateMap<ItemDTO, Item>();

                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();

                cfg.CreateMap<Role, RoleDTO>();
                cfg.CreateMap<RoleDTO, Role>();

                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();

                cfg.CreateMap<Warehouse, WarehouseDTO>();
                cfg.CreateMap<WarehouseDTO, Warehouse>();

                cfg.CreateMap<WarehouseItem, WarehouseItemDTO>();
                cfg.CreateMap<WarehouseItemDTO, WarehouseItem>();
            });

            try
            {
                _mapper = config.CreateMapper();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create map: " + ex.Message);
            }
        }

    }
}
