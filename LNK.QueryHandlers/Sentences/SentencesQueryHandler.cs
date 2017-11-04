using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using LNK.Domain.Sentences.Models;
using LNK.Infrastructure.MongoDb;
using LNK.Infrastructure.Queries;
using LNK.Queries.Sentences;

namespace LNK.QueryHandlers.Sentences
{
    public class SentencesQueryHandler :
        IQueryHandler<ListSentencesQuery, PagedQueryResult<SentenceOverview>>,
        IQueryHandler<GetAllSentencesQuery, IEnumerable<SentenceOverview>>,
        IQueryHandler<GetSentenceDetailsQuery, SentenceDetails>,
        IQueryHandler<GetListSentencesBasicQuery, IEnumerable<SentenceBasic>>,
        IQueryHandler<ListTagsQuery, IEnumerable<string>>,
       IQueryHandler<ListSentencesPronounceQuery, IEnumerable<SentencePronounceOverview>>
    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public SentencesQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<SentenceOverview> Handle(ListSentencesQuery query)
        {
            var builder = Builders<Sentence>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Title))
            {
                filter = filter & builder.Where(it => it.Title.Contains(query.Title));
            }

            if (!String.IsNullOrEmpty(query.ContentWord))
            {
                filter = filter & builder.Where(it => it.EnglishContent.Contains(query.ContentWord));
            }

            if (!String.IsNullOrEmpty(query.Category))
            {
                filter = filter & builder.Eq(it => it.CategoryId, query.Category);
            }

            if (!String.IsNullOrEmpty(query.MainWords))
            {
                filter = filter & builder.Where(it => it.MainWords.Any(m => m.English.Equals(query.MainWords)));
            }

            if (query.Status.HasValue)
            {
                filter = filter & builder.Where(it => it.Status == query.Status);
            }

            if (query.Type.HasValue)
            {
                filter = filter & builder.Where(it => it.Type == query.Type);
            }

            if (query.Tags.Count() > 0)
            {
                filter = filter & builder.Where(it => it.Tags.Contains(query.Tags[0]));
            }

            var packageSentences = _readRepository.Find(filter);
            var totalItemCount = packageSentences.Count();

            var SentenceOverviews = _mapper.Map<IEnumerable<SentenceOverview>>(packageSentences
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<SentenceOverview>(SentenceOverviews, totalItemCount, query.Page, query.PageSize);
            foreach (var item in pagedResult.Items)
            {
                item.StringTags = string.Join(";", item.Tags);
            }
            return pagedResult;
        }

        public SentenceDetails Handle(GetSentenceDetailsQuery query)
        {
            var builder = Builders<Sentence>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (filter == builder.Empty)
            {
                return null;
            }

            var Sentence = _readRepository.Find(filter).FirstOrDefault();
            var SentenceDetails = _mapper.Map<SentenceDetails>(Sentence);

            var tempWords = string.Empty;

            foreach (var item in SentenceDetails.MainWords)
            {
                tempWords += string.Format("|{0},{1}", item.English, item.Vietnam);
            }

            tempWords = tempWords.Length > 0 ? tempWords.Substring(1) : tempWords;

            SentenceDetails.MainWords.Clear();
            SentenceDetails.MainWordsTemp = tempWords;
            SentenceDetails.LinkAudioTemp = string.Join("|", SentenceDetails.LinkAudio);
            return SentenceDetails;
        }

        public IEnumerable<SentenceOverview> Handle(GetAllSentencesQuery query)
        {
            var builder = Builders<Sentence>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (!String.IsNullOrEmpty(query.IdCategory))
            {
                filter = filter & builder.Eq(it => it.CategoryId, query.IdCategory);
            }

            var packageSentences = _readRepository.Find(filter);
            var totalItemCount = packageSentences.Count();

            var SentenceOverviews = _mapper.Map<IEnumerable<SentenceOverview>>(packageSentences.ToList());
            return SentenceOverviews;
        }

        public IEnumerable<SentenceBasic> Handle(GetListSentencesBasicQuery query)
        {
            var builder = Builders<Sentence>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.CategoryId))
            {
                filter = filter & builder.Eq(it => it.CategoryId, query.CategoryId);
            }

            var packageSentences = _readRepository.Find(filter);

            return packageSentences.ToList().Select(n => new SentenceBasic { Id = n.Id, Title = n.Title, LinkAudio = n.LinkAudio.FirstOrDefault() });
        }

        public IEnumerable<string> Handle(ListTagsQuery query)
        {
            var builder = Builders<Sentence>.Filter;
            var filter = builder.Empty;

            if (query.Tags.Count() > 0)
            {
                filter = filter & builder.Where(it => it.Tags.Contains(query.Tags[0]));
            }

            var sentences = _readRepository.Find(filter).ToList();
            var tagArray = sentences.Select(n => string.Join(";", n.Tags)).ToList();
            var tagString = string.Join(";", tagArray);

            return tagString.Split(';').Distinct();
        }

        public IEnumerable<SentencePronounceOverview> Handle(ListSentencesPronounceQuery query)
        {
            var builder = Builders<Sentence>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(query.Word))
            {
                filter = filter & builder.Where(it => it.Tags.Contains("PronouncePage_" + query.Word));
            }

            var sentences = _readRepository.Find(filter).ToList();

            return sentences.Select(n =>
            new SentencePronounceOverview
            {
                Title = n.Title,
                EnglishContent = n.EnglishContent,
                VietnameseContent = n.VietnameseContent,
                IPAs = n.IPAs != null ? n.IPAs[0] : null,
                Tags = n.Tags,
                LinkListen = string.Format("https://forvo.com/word/{0}/#en", n.EnglishContent)
            });
        }

    }
}