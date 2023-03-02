using TestApp.Infrastructure.Entities;

namespace TestApp.Infrastructure.Seeds
{
    public class SeedModel
    {
        public Author? Author { get; set; }

        public List<Book>? Books { get; set; }
    }
}
