﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDisney.Models.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Peso { get; set; }
        public string Historia { get; set; }
    }
}
