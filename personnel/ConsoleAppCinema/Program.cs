namespace ConsoleAppCinema
{
    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public int Year { get; set; }
        public string[] LanguageOptions { get; set; }
        public string[] StreamingPlatforms { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Movie> frenchMovies = new List<Movie>() {
                new Movie() { Title = "Le fabuleux destin d'Amélie Poulain", Genre = "Comédie", Rating = 8.3, Year = 2001, LanguageOptions = new string[] {"Français", "English"}, StreamingPlatforms = new string[] {"Netflix", "Hulu"} },
                new Movie() { Title = "Intouchables", Genre = "Comédie", Rating = 8.5, Year = 2011, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix", "Amazon"} },
                new Movie() { Title = "The Matrix", Genre = "Science-Fiction", Rating = 8.7, Year = 1999, LanguageOptions = new string[] {"English", "Español"}, StreamingPlatforms = new string[] {"Hulu", "Amazon"} },
                new Movie() { Title = "La Vie est belle", Genre = "Drame", Rating = 8.6, Year = 1946, LanguageOptions = new string[] {"Français", "Italiano"}, StreamingPlatforms = new string[] {"Netflix"} },
                new Movie() { Title = "Gran Torino", Genre = "Drame", Rating = 8.2, Year = 2008, LanguageOptions = new string[] {"English"}, StreamingPlatforms = new string[] {"Hulu"} },
                new Movie() { Title = "La Haine", Genre = "Drame", Rating = 8.1, Year = 1995, LanguageOptions = new string[] {"Français"}, StreamingPlatforms = new string[] {"Netflix"} },
                new Movie() { Title = "Oldboy", Genre = "Thriller", Rating = 8.4, Year = 2003, LanguageOptions = new string[] {"Coréen", "English"}, StreamingPlatforms = new string[] {"Amazon"} }
            };

            List<Movie> m_1 = frenchMovies.Where(m => m.Genre != "Comédie").Where(m => m.Genre != "Drame").ToList();
            List<Movie> m_2 = frenchMovies.Where(m => m.Rating < 7).ToList();
            List<Movie> m_3 = frenchMovies.Where(m => m.Year < 2000).ToList();
            List<Movie> m_4 = frenchMovies.Where(m => !m.LanguageOptions.Contains("French")).ToList();
            List<Movie> m_5 = frenchMovies.Where(m => !m.StreamingPlatforms.Contains("Netflix")).ToList();

            Func<Movie, bool> funcm1 = m => m.Genre != "Comédie";
            Func<Movie, bool> funcm2 = m => m.Genre != "Drama";
            Func<Movie, bool> funcm3 = m => m.Rating < 7;
            Func<Movie, bool> funcm4 = m => m.Year < 2000;
            Func<Movie, bool> funcm5 = m => !m.LanguageOptions.Contains("French");
            Func<Movie, bool> funcm6 = m => !m.StreamingPlatforms.Contains("Netflix");

            List<Movie> m_all = frenchMovies
                .Where(funcm1)
                .Where(funcm2)
                .Where(funcm3)
                .Where(funcm4)
                .Where(funcm5)
                .Where(funcm6)
                .ToList();

            Dictionary<int, string> m = new Dictionary<int, string>() { { 1, "Comédie" }, { 2, "Science-Fiction" }, { 3, "Drame" }, { 4, "Thriller" } };

            Console.WriteLine($"Veuillez choisir un style : \n 1 - {m[1]} \n 2 - {m[2]} \n 3 - {m[3]} \n 4 - {m[4]}");
            string type = m[Convert.ToInt32(Console.ReadLine())];

            Func<Movie, string, bool> funcm_1 = (m, type) => m.Genre == type;
        }
    }
}