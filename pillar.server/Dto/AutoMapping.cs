using AutoMapper;
using Pillar.Server.Models;
using Pillar.Server.Dto;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<PlayerCreateDto, Player>(); 
        CreateMap<PlayerUpdateDto, Player>();
    }
}