using AutoMapper;
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
                cfg.CreateMap<ToDoItem, ToDoItemDTO>();
                cfg.CreateMap<ToDoItemDTO, ToDoItem>();
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
