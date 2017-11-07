using LNK.Infrastructure.Queries;

namespace LNK.Queries.FlashCards
{
    public class GetFlashCardDetails: QueryBase
    { 
        public string Id { get; set; }

        public string FaceA { get; set; }

        public string FaceB { get; set; }

        public string FlashCardCategoryId { get; set; }

        public string FlashCardCategoryName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
