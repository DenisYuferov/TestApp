using TestApp.Domain.Model.PostgreDb.Entities;

namespace TestApp.Domain.Model.PostgreDb.Seeds
{
    public class SeedModel
    {
        public Author? Author { get; set; }

        public List<Book>? Books { get; set; }
    }
}
