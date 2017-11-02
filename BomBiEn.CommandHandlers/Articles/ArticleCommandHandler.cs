using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Commands.Articles;
using BomBiEn.Domain.Articles.Models;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.MongoDb;

namespace BomBiEn.CommandHandlers.Articles
{
    public class ArticleCommandHandler :
        ICommandHandler<CreateArticleCommand>,
        ICommandHandler<UpdateArticleCommand>,
        ICommandHandler<DeleteArticleCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public ArticleCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public void Handle(CreateArticleCommand command)
        {
            var Article = _mapper.Map<Article>(command);
            if (String.IsNullOrEmpty(Article.Id))
            {
                Article.Id = Guid.NewGuid().ToString("N");
            }

            _writeRepository.Create(Article);
            //_auditLogService.LogCreate<Article>(Article.Id, Article.CreatedBy, Article.ToJson());
        }

        public void Handle(UpdateArticleCommand command)
        {
            var Article = _writeRepository.Get<Article>(command.Id);
            Contract.Assert(Article != null);

            var originalJson = Article.ToJson();
            _mapper.Map(command, Article);

            _writeRepository.Replace(Article);
            //_auditLogService.LogUpdate<Article>(command.Id, command.ModifiedBy, originalJson, Article.ToJson());
        }

        public void Handle(DeleteArticleCommand command)
        {
            var Article = _writeRepository.Get<Article>(command.Id);
            Contract.Assert(Article != null);

            _writeRepository.Delete(Article);
            //_auditLogService.LogDelete<Article>(command.Id, command.DeletedBy, Article.ToJson());
        }
    }
}
