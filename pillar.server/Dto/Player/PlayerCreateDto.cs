using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Pillar.Server.Dto
{
    public class PlayerCreateDto
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string KnownAs { get; set; }
        public string Mobile { get; set; }
        public string Email {get; set; }
    }
}