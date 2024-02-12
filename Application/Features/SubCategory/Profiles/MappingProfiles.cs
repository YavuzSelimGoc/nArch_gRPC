using System;
using Application.Features.SubCategory.Commands.Create;
using Application.Features.SubCategorys.Commands.Create;
using Domain.Entities;
using AutoMapper;
using Application.Features.Models.Queries.GetList;
using Application.Features.SubCategory.Queries.GetList;
using Core.Application.Responses;
using Core.Persistence.Paging;

namespace Application.Features.SubCategory.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.SubCategory, GetListSubCategoryListItemDto>()
            .ForMember(destinationMember: c => c.CategoryName, memberOptions: opt => opt.MapFrom(c => c.Category.CategoryName))
          .ReverseMap();
        CreateMap<Domain.Entities.SubCategory, CreateSubCategoryCommand>().ReverseMap();
        CreateMap<Paginate<Domain.Entities.SubCategory>, GetListResponse<GetListSubCategoryListItemDto>>().ReverseMap();
        CreateMap<Domain.Entities.SubCategory, CreatedSubCategoryResponse>().ReverseMap();
    }
}

