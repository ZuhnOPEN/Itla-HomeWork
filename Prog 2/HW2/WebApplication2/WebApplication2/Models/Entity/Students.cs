namespace WebApplication2.Models.Entity
{
    public class Students
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }
        public string phone { get; set; }
        public bool News { get; set; }
    }
}
