using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using LNK.Commands.Sentences;
using LNK.Domain.Sentences.Models;
using LNK.Infrastructure.Commands;
using LNK.Infrastructure.MongoDb;

namespace LNK.CommandHandlers.Sentences
{
    public class SentencesCommandHandler :
        ICommandHandler<CreateSentenceCommand>,
        ICommandHandler<UpdateSentenceCommand>,
        ICommandHandler<DeleteSentenceCommand>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbWriteRepository _writeRepository;

        public SentencesCommandHandler(
            IMapper mapper,
            IMongoDbWriteRepository writeRepository)
        {
            _mapper = mapper;
            _writeRepository = writeRepository;
        }

        public void Handle(CreateSentenceCommand command)
        {
            if (!string.IsNullOrWhiteSpace(command.MainWordsTemp))
            {
                var mainWordsTemp = command.MainWordsTemp.Split('|');
                var listDictionaries = new List<DictionaryCommand>();
                foreach (var item in mainWordsTemp)
                {
                    listDictionaries.Add(new DictionaryCommand() { English = item.Split(',')[0], Vietnam = item.Split(',')[1] });
                }
                if (command.MainWords == null)
                {
                    command.MainWords = new List<DictionaryCommand>();
                }
                else
                {
                    command.MainWords.Clear();
                }
                command.MainWords.AddRange(listDictionaries);
            }

            var Sentence = _mapper.Map<Sentence>(command);

            if (!string.IsNullOrWhiteSpace(command.LinkAudioTemp))
            {
                Sentence.LinkAudio.AddRange(command.LinkAudioTemp.Split('|'));
            }

            if (String.IsNullOrEmpty(Sentence.Id))
            {
                Sentence.Id = Guid.NewGuid().ToString("N");
            }

            if (!string.IsNullOrEmpty(Sentence.SameWord) && Sentence.SameWord.Equals("create"))
            {
                Sentence.SameWord = Guid.NewGuid().ToString("N");
            }

            if (!string.IsNullOrEmpty(Sentence.RelatedWords) && Sentence.RelatedWords.Equals("create"))
            {
                Sentence.RelatedWords = Guid.NewGuid().ToString("N");
            }

            var category = _writeRepository.Get<LNK.Domain.Categories.Models.Category>(command.CategoryId);
            Sentence.Tags = new List<string>();
            if (command.Tags != null)
            {
                Sentence.Tags.AddRange(command.Tags);
            }
            Sentence.CategoryName = category.NameEn;
            Sentence.EnglishContent = Sentence.EnglishContent.Trim();
            _writeRepository.Create(Sentence);
            //_auditLogService.LogCreate<Sentence>(Sentence.Id, Sentence.CreatedBy, Sentence.ToJson());
        }

        public void Handle(UpdateSentenceCommand command)
        {
            var listDictionaries = new List<Dictionary>();
            if (!string.IsNullOrWhiteSpace(command.MainWordsTemp))
            {
                var mainWordsTemp = command.MainWordsTemp.Split('|');
                foreach (var item in mainWordsTemp)
                {
                    listDictionaries.Add(new Dictionary() { English = item.Split(',')[0], Vietnam = item.Split(',')[1] });
                }
            }

            var Sentence = _writeRepository.Get<Sentence>(command.Id);
            if (Sentence.MainWords != null)
            {
                Sentence.MainWords.Clear();
            }
            else
            {
                Sentence.MainWords = new List<Dictionary>();
            }
            Sentence.MainWords.AddRange(listDictionaries);
            if (!string.IsNullOrWhiteSpace(command.LinkAudioTemp))
            {
                Sentence.LinkAudio = new List<string>();
                Sentence.LinkAudio.AddRange(command.LinkAudioTemp.Split('|'));
            }
            else
            {
                try
                {
                    Sentence.LinkAudio.Clear();
                }
                catch (Exception)
                {
                    Sentence.LinkAudio = new List<string>();
                }

            }

            Contract.Assert(Sentence != null);

            var originalJson = Sentence.ToJson();
            _mapper.Map(command, Sentence);

            var category = _writeRepository.Get<LNK.Domain.Categories.Models.Category>(command.CategoryId);

            Sentence.CategoryName = category.NameEn;
            Sentence.EnglishContent = Sentence.EnglishContent.Trim();

            if (Sentence.IPAs.Count > 1 && command.IPAs.Count > 0)
            {
                Sentence.IPAs.Clear();
                Sentence.IPAs.Add(command.IPAs[0]);
            }

            if (!string.IsNullOrEmpty(Sentence.SameWord) && command.SameWord.Equals("clear"))
            {
                Sentence.SameWord = null;
            }

            if (!string.IsNullOrEmpty(Sentence.RelatedWords) && command.RelatedWords.Equals("clear"))
            {
                Sentence.RelatedWords = null;
            }

            if (!string.IsNullOrEmpty(Sentence.SameWord) && Sentence.SameWord.Equals("create"))
            {
                Sentence.SameWord = Guid.NewGuid().ToString("N");
            }

            if (!string.IsNullOrEmpty(Sentence.RelatedWords) && Sentence.RelatedWords.Equals("create"))
            {
                Sentence.RelatedWords = Guid.NewGuid().ToString("N");
            }

            Sentence.Tags.Clear();
            Sentence.Tags.AddRange(command.Tags);
            _writeRepository.Replace(Sentence);
            //_auditLogService.LogUpdate<Sentence>(command.Id, command.ModifiedBy, originalJson, Sentence.ToJson());
        }

        public void Handle(DeleteSentenceCommand command)
        {
            var Sentence = _writeRepository.Get<Sentence>(command.Id);
            Contract.Assert(Sentence != null);

            _writeRepository.Delete(Sentence);
            //_auditLogService.LogDelete<Sentence>(command.Id, command.DeletedBy, Sentence.ToJson());
        }
    }
}
