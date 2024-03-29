﻿using SharedCore.Model.Entities;

namespace TestApp.Domain.Model.PostgreDb.Entities
{
    public class Author : EntityBase<int>
    {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public List<Book>? Books { get; set; }
    }
}