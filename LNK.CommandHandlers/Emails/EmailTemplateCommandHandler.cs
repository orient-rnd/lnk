using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Bson;
using LNK.Commands.Emails;
using LNK.Domain.Emails.Models;
using LNK.Infrastructure.Commands;
using LNK.Infrastructure.MongoDb;

namespace LNK.CommandHandlers.Emails
{
    public class EmailTemplateCommandHandler :
        ICommandHandler<CreateEmailTemplateCommand>,
        ICommandHandler<UpdateEmailTemplateCommand>,
        ICommandHandler<DeleteEmailTemplateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public EmailTemplateCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public void Handle(CreateEmailTemplateCommand command)
        {
            var emailTemplate = _mapper.Map<EmailTemplate>(command);
            if (String.IsNullOrEmpty(emailTemplate.Id))
            {
                emailTemplate.Id = Guid.NewGuid().ToString("N");
            }

            var translation = _mapper.Map<EmailTemplateTranslation>(command);
            emailTemplate.Translations[translation.LanguageCode] = translation;

            _writeRepository.Create(emailTemplate);
        }

        public void Handle(UpdateEmailTemplateCommand command)
        {
            var emailTemplate = _writeRepository.Get<EmailTemplate>(command.Id);
            Contract.Assert(emailTemplate != null);

            var originalJson = emailTemplate.ToJson();
            _mapper.Map(command, emailTemplate);
            emailTemplate.Translations[command.LanguageCode] = _mapper.Map<EmailTemplateTranslation>(command);

            _writeRepository.Replace(emailTemplate);
        }

        public void Handle(DeleteEmailTemplateCommand command)
        {
            var emailTemplate = _writeRepository.Get<EmailTemplate>(command.Id);
            Contract.Assert(emailTemplate != null);

            _writeRepository.Delete(emailTemplate);
        }
    }
}