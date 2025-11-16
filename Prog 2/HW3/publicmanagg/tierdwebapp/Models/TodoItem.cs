using System;

namespace tierdwebapp.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}