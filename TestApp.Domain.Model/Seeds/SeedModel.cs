using TestApp.Domain.Model.Entities;

namespace TestApp.Domain.Model.Seeds
{
    public class SeedModel
    {
        public Author? Author { get; set; }

        public List<Book>? Books { get; set; }
    }
}
