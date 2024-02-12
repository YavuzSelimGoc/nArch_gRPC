using Application.Features.SubCategory.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubCategorys.Queries.GetList;

public class GetListSubCategoryQuery : IRequest<GetListResponse<GetListSubCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSubCategoryQueryHandler : IRequestHandler<GetListSubCategoryQuery, GetListResponse<GetListSubCategoryListItemDto>>
    {
        private readonly ISubCategoryRepository _SubCategoryRepository;
        private readonly IMapper _mapper;

        public GetListSubCategoryQueryHandler(ISubCategoryRepository SubCategoryRepository, IMapper mapper)
        {
            _SubCategoryRepository = SubCategoryRepository;
            _mapper = mapper;
        }
        public async Task<GetListResponse<GetListSubCategoryListItemDto>> Handle(GetListSubCategoryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Domain.Entities.SubCategory> SubCategorys = await _SubCategoryRepository.GetListAsync(
                 include: m => m.Include(m => m.Category),
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize
                 );

            var response = _mapper.Map<GetListResponse<GetListSubCategoryListItemDto>>(SubCategorys);

            return response;


        }
    }
}