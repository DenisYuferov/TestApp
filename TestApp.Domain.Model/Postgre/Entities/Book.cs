using SharedCore.Model.Entities;

namespace TestApp.Domain.Model.Postgre.Entities
{
    public class Book : EntityBase<int>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double? Cost { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}