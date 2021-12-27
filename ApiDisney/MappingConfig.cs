using ApiDisney.Models;
using ApiDisney.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney
{
    public class MappingConfig
    {
        //Esta clase realiza el mapeo entre los DTOs y los Modelos

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CharacterDto, Character>();
                config.CreateMap<Character, CharacterDto>();

            });

            return mappingConfig;
        }
    }
}
