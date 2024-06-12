namespace Movie.Exceptions
{
    public class MovieNotFoundException : Exception
    {

        public MovieNotFoundException(string message) : base(String.Format("Movie {0} not found", message)) { }

    }
}
