namespace WebApi.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LasName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
