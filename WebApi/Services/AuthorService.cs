using Microsoft.Data.SqlClient;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.Response;

namespace WebApi.Services
{
    public class AuthorService(DatabaseConnection connection, AppDbContext context)
    {
        private readonly DatabaseConnection _connection = connection;
        private readonly AppDbContext _context = context;

        public List<Author> GetAuthors()
        {
            List<Author> authors = [];

            try
            {
                using (SqlConnection conn = _connection.GetConnection()) 
                { 
                    conn.Open();

                    using (SqlCommand cmd = new(SqlQueries.GetAuthors, conn))
                    {
                        using (SqlDataReader req = cmd.ExecuteReader()) 
                        {
                            while (req.Read())
                            {
                                Author author = new()
                                {
                                    AuthorId = Convert.ToInt32(req["AuthorId"]),
                                    FirstName = req["FirstName"].ToString() ?? string.Empty,
                                    SecondName = req["SecondName"].ToString() ?? string.Empty,
                                    LasName = req["LastName"].ToString() ?? string.Empty,
                                    SecondLastName = req["SecondLastName"].ToString() ?? string.Empty,
                                    BirthDate = Convert.ToDateTime(req["BirthDate"])
                                };

                                if (author.AuthorId > 0 && !string.IsNullOrEmpty(author.FirstName))
                                {
                                    authors.Add(author);
                                }
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return authors;
        }

        public CreateAuthorResponse CreateAuthor(Author author)
        {
            CreateAuthorResponse response = new CreateAuthorResponse();

            try
            {
                if (author == null)
                {
                    response.IsSuccess = false;
                    response.Message = string.Empty;
                    return response;
                }

                _context.Author.Add(author);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return response;
        }
    }
}
