namespace ClickerProject.Domain
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long CurrentScore { get; set; }
        public long RecordScore { get; set; }
        public ICollection<UserBoost> UserBoosts { get; set; }
    }
}
