using Application.Features.Category.Commands.Create;
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

namespace Application.Features.Categorys.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
    public bool CategoryStatus { get; set; }

    public string CacheKey => "";

    public bool BypassCache => false;

    public string? CacheGroupKey => "GetCategorys";

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository CategoryRepository, IMapper mapper)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse>? Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            
            Domain.Entities.Category Category = _mapper.Map<Domain.Entities.Category>(request);
            Category.Id = Guid.NewGuid();
            Category.CategoryStatus = true;

            //Category Category2 = _mapper.Map<Category>(request);
            //Category2.Id = Guid.NewGuid();

            await _CategoryRepository.AddAsync(Category);
            //await _CategoryRepository.AddAsync(Category2);

            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(Category);
            return createdCategoryResponse;
        }
    }
}