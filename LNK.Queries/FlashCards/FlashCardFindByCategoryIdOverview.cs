using System;
using System.Collections.Generic;
using System.Text;

namespace LNK.Queries.FlashCards
{
    public class FlashCardFindByCategoryIdOverview
    {
        public bool isRandom { get; set; }
        public bool isFaceAFirst { get; set; }
        public List<FlashCardBrief> Items { get; set; }
    }
}
