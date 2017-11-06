using LNK.Infrastructure.Queries;

namespace LNK.Queries.FlashCards
{
    public class ListFlashCardCategoriesQuery : ListQueryBase
    {
        public string UserId { get; set; }

        public string UserEmail { get; set; }
    }
}