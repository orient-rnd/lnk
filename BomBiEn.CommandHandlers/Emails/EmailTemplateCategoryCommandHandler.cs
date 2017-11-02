using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using BomBiEn.Commands.Emails;
using BomBiEn.Domain.Emails.Models;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.Infrastructure.MongoDb;

namespace BomBiEn.CommandHandlers.Emails
{
    public class EmailTemplateCategoryCommandHandler :
        ICommandHandler<CreateEmailTemplateCategoryCommand>,
        ICommandHandler<UpdateEmailTemplateCategoryCommand>,
        ICommandHandler<DeleteEmailTemplateCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public EmailTemplateCategoryCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public void Handle(CreateEmailTemplateCategoryCommand command)
        {
            var emailTemplateCategory = _mapper.Map<EmailTemplateCategory>(command);
            if (String.IsNullOrEmpty(emailTemplateCategory.Id))
            {
                emailTemplateCategory.Id = Guid.NewGuid().ToString("N");
            }

            _writeRepository.Create(emailTemplateCategory);
        }

        public void Handle(UpdateEmailTemplateCategoryCommand command)
        {
            var emailTemplateCategory = _writeRepository.Get<EmailTemplateCategory>(command.Id);
            Contract.Assert(emailTemplateCategory != null);

            var originalJson = emailTemplateCategory.ToJson();
            _mapper.Map(command, emailTemplateCategory);

            _writeRepository.Replace(emailTemplateCategory);
        }

        public void Handle(DeleteEmailTemplateCategoryCommand command)
        {
            var emailTemplateCategory = _writeRepository.Get<EmailTemplateCategory>(command.Id);
            Contract.Assert(emailTemplateCategory != null);

            _writeRepository.Delete(emailTemplateCategory);
        }
    }
}