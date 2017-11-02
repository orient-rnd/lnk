using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Commands.Categories;
using BomBiEn.Domain.Categories.Models;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.MongoDb;

namespace BomBiEn.CommandHandlers.Categories
{
    public class CategoryCommandHandler :
        ICommandHandler<CreateCategoryCommand>,
        ICommandHandler<UpdateCategoryCommand>,
        ICommandHandler<DeleteCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public CategoryCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public void Handle(CreateCategoryCommand command)
        {
            var category = _mapper.Map<Category>(command);
            if (String.IsNullOrEmpty(category.Id))
            {
                category.Id = Guid.NewGuid().ToString("N");
            }

            if (!string.IsNullOrEmpty(category.IdCategoryParent))
            {
                var parentCategory = _writeRepository.Get<Category>(command.IdCategoryParent);
                category.Level = parentCategory.Level ?? null;
            }

            _writeRepository.Create(category);
            //_auditLogService.LogCreate<Category>(category.Id, category.CreatedBy, category.ToJson());
        }

        public void Handle(UpdateCategoryCommand command)
        {
            var category = _writeRepository.Get<Category>(command.Id);
            Contract.Assert(category != null);

            var originalJson = category.ToJson();
            _mapper.Map(command, category);

            if (!string.IsNullOrEmpty(category.IdCategoryParent))
            {
                var parentCategory = _writeRepository.Get<Category>(command.IdCategoryParent);
                category.Level = parentCategory.Level ?? null;
            }

            _writeRepository.Replace(category);
            //_auditLogService.LogUpdate<Category>(command.Id, command.ModifiedBy, originalJson, category.ToJson());
        }

        public void Handle(DeleteCategoryCommand command)
        {
            var category = _writeRepository.Get<Category>(command.Id);
            Contract.Assert(category != null);

            _writeRepository.Delete(category);
            //_auditLogService.LogDelete<Category>(command.Id, command.DeletedBy, category.ToJson());
        }
    }
}
