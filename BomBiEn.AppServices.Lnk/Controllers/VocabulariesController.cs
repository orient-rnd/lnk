using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Infrastructure.Commands;
using AutoMapper;
using BomBiEn.Queries.FlashCards;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BomBiEn.AppServices.Lnk.Controllers
{
    public class VocabulariesController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        public VocabulariesController(
            IQueryBus queryBus,
            ICommandBus commandBus,
            IMapper mapper)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search([FromQuery]string oq)
        {
            var request = new GetAllSuggestionWordsQuery() { Word = string.Format("{0}", oq.Trim()) };
            var suggestionWords = _queryBus.Send<GetAllSuggestionWordsQuery, IEnumerable<SuggestionWord>>(request).ToList().Distinct().OrderBy(n => n.EnglishContent.Length);

            return View(suggestionWords);
        }
    }
}
