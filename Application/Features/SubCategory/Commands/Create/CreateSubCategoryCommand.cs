using Application.Features.SubCategory.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SubCategorys.Commands.Create;

public class CreateSubCategoryCommand : IRequest<CreatedSubCategoryResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid CategoryId { get; set; }
    public string SubCategoryName { get; set; }
    public string SubCategoryDescription { get; set; }
    public bool SubCategoryStatus { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetSubCategorys";

    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommand, CreatedSubCategoryResponse>
    {
        private readonly ISubCategoryRepository _SubCategoryRepository;
        private readonly IMapper _mapper;

        public CreateSubCategoryCommandHandler(ISubCategoryRepository SubCategoryRepository, IMapper mapper)
        {
            _SubCategoryRepository = SubCategoryRepository;
            _mapper = mapper;
        }

        public async Task<CreatedSubCategoryResponse>? Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {


            Domain.Entities.SubCategory SubCategory = _mapper.Map<Domain.Entities.SubCategory>(request);
            SubCategory.Id = Guid.NewGuid();
            SubCategory.SubCategoryStatus = true;

            //SubCategory SubCategory2 = _mapper.Map<SubCategory>(request);
            //SubCategory2.Id = Guid.NewGuid();

            await _SubCategoryRepository.AddAsync(SubCategory);
            //await _SubCategoryRepository.AddAsync(SubCategory2);

            CreatedSubCategoryResponse createdSubCategoryResponse = _mapper.Map<CreatedSubCategoryResponse>(SubCategory);
            return createdSubCategoryResponse;
        }
    }
}