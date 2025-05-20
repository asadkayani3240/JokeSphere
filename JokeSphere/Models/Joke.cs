namespace JokeSphere.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string Setup { get; set; } = string.Empty;
        public string Punchline { get; set; } = string.Empty;
    }
}