namespace Models
{
    public class Commitment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
