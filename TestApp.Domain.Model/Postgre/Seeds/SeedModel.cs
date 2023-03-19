using TestApp.Domain.Model.Postgre.Entities;

namespace TestApp.Domain.Model.Postgre.Seeds
{
    public class SeedModel
    {
        public Author? Author { get; set; }

        public List<Book>? Books { get; set; }
    }
}
