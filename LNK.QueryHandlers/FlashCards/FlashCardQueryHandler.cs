using AutoMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using LNK.Domain.FlashCards.Models;
using LNK.Infrastructure.MongoDb;
using LNK.Infrastructure.Queries;
using LNK.Queries.FlashCards;
using LNK.Domain.Sentences.Models;
using LNK.Domain.Users.Models;

namespace LNK.QueryHandlers.FlashCards
{
    public class FlashCardQueryHandler :
        IQueryHandler<ListFlashCardsQuery, PagedQueryResult<FlashCardOverview>>,
        IQueryHandler<GetFlashCardDetailsQuery, FlashCardDetails>,
        IQueryHandler<GetAllFlashCardsQuery, IEnumerable<FlashCardOverview>>,
        IQueryHandler<GetAllSuggestionWordsQuery, IEnumerable<SuggestionWord>>

    {
        private readonly IMapper _mapper;
        private readonly IMongoDbReadRepository _readRepository;

        public FlashCardQueryHandler(
            IMapper mapper,
            IMongoDbReadRepository readRepository)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public PagedQueryResult<FlashCardOverview> Handle(ListFlashCardsQuery query)
        {
            var builder = Builders<FlashCard>.Filter;
            var filter = builder.Empty;
            if (!String.IsNullOrEmpty(query.CategoryId))
            {
                filter = filter & builder.Eq(it => it.FlashCardCategoryId, query.CategoryId);
            }

            if (!String.IsNullOrEmpty(query.UserId))
            {
                var user = _readRepository.Get<User>(query.UserId);
                filter = filter & builder.Eq(it => it.UserEmail, user.Email);
            }

            if (query.NotSupportYet.HasValue)
            {
                var sentence = _readRepository.Find<Sentence>(Builders<Sentence>.Filter.Eq(it => it.Type, Shared.Enums.SentenceType.Word)).ToList().Select(n => n.Title).ToList();
                filter = query.NotSupportYet.Value ? filter & builder.Where(it => !sentence.Contains(it.FaceA)) : filter & builder.Where(it => sentence.Contains(it.FaceA));
            }

            var packageFlashCards = _readRepository.Find(filter);
            var totalItemCount = packageFlashCards.Count();

            var FlashCardOverviews = _mapper.Map<IEnumerable<FlashCardOverview>>(packageFlashCards
                .SortByDescending(it => it.CreatedDate)
                .Skip((query.Page - 1) * query.PageSize)
                .Limit(query.PageSize)
                .ToList());
            var pagedResult = new PagedQueryResult<FlashCardOverview>(FlashCardOverviews, totalItemCount, query.Page, query.PageSize);
            return pagedResult;
        }

        public FlashCardDetails Handle(GetFlashCardDetailsQuery query)
        {
            var builder = Builders<FlashCard>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.Id))
            {
                filter = filter & builder.Eq(it => it.Id, query.Id);
            }

            if (filter == builder.Empty)
            {
                return null;
            }

            var FlashCard = _readRepository.Find(filter).FirstOrDefault();
            var FlashCardDetails = _mapper.Map<FlashCardDetails>(FlashCard);
            return FlashCardDetails;
        }

        public IEnumerable<FlashCardOverview> Handle(GetAllFlashCardsQuery query)
        {
            var builder = Builders<FlashCard>.Filter;
            var filter = builder.Empty;

            if (!String.IsNullOrEmpty(query.IdCategory))
            {
                filter = filter & builder.Eq(it => it.FlashCardCategoryId, query.IdCategory);
            }

            var packageFlashCards = _readRepository.Find(filter);

            var FlashCardOverviews = _mapper.Map<IEnumerable<FlashCardOverview>>(packageFlashCards.ToList());
            var allWords = string.Join(" ", FlashCardOverviews.Select(n => n.FaceA.ToLower()).ToList()).Trim();
            var listWords = allWords.Split(' ').Where(n => n.Length > 2).ToList();

            var builders = Builders<Sentence>.Filter;
            var filters = builders.Where(it => it.Type == Shared.Enums.SentenceType.Word && it.IPAs.Count() > 0);
            foreach (var item in listWords)
            {
                filters = filters | builders.Where(it => it.EnglishContent == item);
            }
            var sentences = _readRepository.Find(filters).ToList();

            foreach (var item in FlashCardOverviews)
            {
                if (!item.FaceA.Trim().Contains(" "))
                {
                    var sent = sentences.Where(n => n.EnglishContent.ToLower() == item.FaceA.ToLower()).FirstOrDefault();
                    if (sent != null && sent.IPAs.Count() > 0)
                    {
                        item.IpasFaceA = sent.IPAs[0];
                    }
                    else
                    {
                        item.IpasFaceA = "";
                    }


                }
            }
            return FlashCardOverviews;
        }

        public IEnumerable<SuggestionWord> Handle(GetAllSuggestionWordsQuery query)
        {
            var result = new List<SuggestionWord>();

            var builder = Builders<Sentence>.Filter;
            var filter = builder.Empty;
            if (!query.Word.Contains(" "))
            {
                filter = filter & builder.Eq(it => it.Type, Shared.Enums.SentenceType.Word);
                filter = filter & builder.Eq(it => it.Title, query.Word);
                var sentencesWord = _readRepository.Find(filter).ToList().Select(n => new SuggestionWord(n.Title, n.EnglishContent, n.VietnameseContent, n.LinkAudio, n.Id, n.Type.ToString(), n.IPAs));
                result.AddRange(sentencesWord);
            }

            filter = builder.Empty;
            if (!query.Word.Contains(" "))
            {
                filter = filter & builder.Eq(it => it.Type, Shared.Enums.SentenceType.Sentence);
                filter = filter & builder.Where(it => it.MainWords.Any(m => m.English.Equals(query.Word)));
                var sentencesWord = _readRepository.Find(filter).ToList().Select(n => new SuggestionWord(n.Title, n.EnglishContent, n.VietnameseContent, n.LinkAudio, n.Id, n.Type.ToString(), null));
                result.AddRange(sentencesWord);
            }

            filter = builder.Empty;
            if (!query.Word.Contains(" "))
            {
                filter = filter & builder.Eq(it => it.Type, Shared.Enums.SentenceType.Conversation);
                filter = filter & builder.Where(it => it.EnglishContent.Contains(query.Word));
                var sentencesWord = _readRepository.Find(filter).ToList().Select(n => new SuggestionWord(n.Title, n.EnglishContent, n.VietnameseContent, n.LinkAudio, n.Id, n.Type.ToString(), null, n.CategoryId, n.CategoryName));
                result.AddRange(sentencesWord);
            }

            for (int i = 0; i < result.Count; i++)
            {
                var stringReplaced = string.Format("<B>{0}</B>", query.Word);
                result[i].EnglishContent = result[i].EnglishContent.Replace(query.Word, stringReplaced);
            }

            return result.Take(15);
        }

    }
}