namespace JobSearch.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Size Size { get; set; }
        public string Culture { get; set; }
    }

    public enum Size
    {
        Small,
        Medium,
        Large
    }
}