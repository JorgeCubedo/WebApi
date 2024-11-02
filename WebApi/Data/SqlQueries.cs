namespace WebApi.Data
{
    public class SqlQueries
    {
        public static string GetAuthors => $@"
            SELECT * FROM Authors
        ";

        public static string CreateAuthor => $@"
            INSERT INTO Authors (FirstName, SecondName, LastName, SecondLastName, BirthDate) 
            VALUES (@firstName, @secondName, @lastName, @secondLastName, @birthDate)
        ";
    }
}
