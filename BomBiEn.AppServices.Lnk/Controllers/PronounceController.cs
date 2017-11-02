using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BomBiEn.Queries.Sentences;
using BomBiEn.Infrastructure.Queries;
using BomBiEn.Infrastructure.Commands;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BomBiEn.AppServices.Lnk.Controllers
{
    public class PronounceController : Controller
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        public PronounceController(
            IQueryBus queryBus,
            ICommandBus commandBus,
            IMapper mapper)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _mapper = mapper;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var query = new ListTagsQuery() { };
            query.Tags.Add("PronouncePage");
            var tags = _queryBus.Send<ListTagsQuery, IEnumerable<string>>(query)
                .Select(n => n.Replace("PronouncePage_", ""))
                .ToList()
                .Where(n => !n.Contains("_"))
                .ToList();
            tags.Remove("PronouncePage");
            ViewBag.tags = tags;
            return View();
        }

        [HttpGet("Pronounce/{id}")]
        public IActionResult PractisePronounce(string id)
        {
            var query = new ListSentencesPronounceQuery() { Word = UppercaseFirst(id) };
            var pronounce = _queryBus.Send<ListSentencesPronounceQuery, IEnumerable<SentencePronounceOverview>>(query).ToList();
            ViewBag.word = query.Word;

            var pr = string.Join(";", pronounce.Select(n => string.Join(";", n.Tags.ToList())).ToList());
            var uniqueListWord = pr.Split(';').Where(n => n.Contains(string.Format("_{0}_", query.Word))).Distinct().ToList();
            var listCate = uniqueListWord.Select(n => n.Replace("PronouncePage_" + query.Word + "_", "")).ToList();
            listCate.Remove("Beginning");
            listCate.Remove("Middle");
            listCate.Remove("Ending");
            listCate.Add("Ending");
            listCate.Add("Middle");
            listCate.Add("Beginning");
            listCate.Reverse();
            ViewBag.listCate = listCate;
            return View(pronounce);
        }

        public IActionResult Sh()
        {
            return View();
        }

        private string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
