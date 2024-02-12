using System;
using Application.Features.Category.Commands.Create;
using Application.Features.Categorys.Commands.Create;
using Domain.Entities;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Category.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
        CreateMap<Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Category, CreatedCategoryResponse>().ReverseMap();
    }
}

