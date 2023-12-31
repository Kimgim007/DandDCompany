﻿using DandDCompany.Controllers;
using DTO.Entity;

namespace DandDCompany.Models
{
    public class GameClassViewModel
    {
        public GameClassViewModel() { }
        public Guid GameClassId { get; set; }
        public string GameClassName { get; set; }
        public string? DescriptionGameClass { get; set; }

        public List<GamingSystemDTO> GamingSystemsDTO { get; set; } = new List<GamingSystemDTO>();

    }
}
