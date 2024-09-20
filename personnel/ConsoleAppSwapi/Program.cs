using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ConsoleAppSwapi
{
    public class Starships
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Starship> results { get; set; }

        public Starships(int count, string next, object previous, List<Starship> results)
        {
            this.count = count;
            this.next = next;
            this.previous = previous;
            this.results = results;
        }

        public void HowMuchStarFigherICanBuy()
        {
            int costStarDestroyer = results.Aggregate(new Starship(), (s, next) => s.name == "Star Destroyer" ? s : next, s => Convert.ToInt32(s.cost_in_credits));
            int costXWing = results.Aggregate(new Starship(), (s, next) => s.name == "X-Wing" ? s : next, s => Convert.ToInt32(s.cost_in_credits));
            double howMuch = costXWing / costXWing;
            Console.WriteLine(Math.Round(howMuch));
        }

        public void FastestStarship()
        {
            double doubles = results.Select(s => Convert.ToDouble(s.max_atmosphering_speed) * Convert.ToDouble(s.hyperdrive_rating)).ToList().Max();
            Starship starship = results.Aggregate((s, next) => Convert.ToDouble(s.max_atmosphering_speed) * Convert.ToDouble(s.hyperdrive_rating) == doubles ? s : next);
        }

        public void FastestThanTheAverage()
        {
            double average = results.Average(s => Convert.ToDouble(s.max_atmosphering_speed));
            int count = results.Where(s => Convert.ToDouble(s.max_atmosphering_speed) > average).Count();
        }

        public void PriceOfAllTheShip()
        {
            double sum = results.Sum(s => Convert.ToDouble(s.cost_in_credits));
            double chf = sum * 0.778;
        }

        public void CsvWriter()
        {
            List<string> films = new List<string>();
            List<string> planets = new List<string>();

            results.ForEach(s =>
            {
                s.films.ForEach(async f =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(f);
                        HttpResponseMessage res = await client.GetAsync(client.BaseAddress);
                        HttpContent cont = res.Content;
                        using (Stream sr = await cont.ReadAsStreamAsync())
                        {
                            Movie m = JsonSerializer.Deserialize<Movie>(sr);
                            films.Add(m.title);
                        }
                    }
                });

                s.films.ForEach(async f =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(f);
                        HttpResponseMessage res = await client.GetAsync(client.BaseAddress);
                        HttpContent cont = res.Content;
                        using (Stream sr = await cont.ReadAsStreamAsync())
                        {
                            Movie m = JsonSerializer.Deserialize<Movie>(sr);
                            m.planets.ForEach(async p =>
                            {
                                using (HttpClient client = new HttpClient())
                                {
                                    client.BaseAddress = new Uri(p);
                                    HttpResponseMessage res = await client.GetAsync(client.BaseAddress);
                                    HttpContent cont = res.Content;
                                    using (Stream sr = await cont.ReadAsStreamAsync())
                                    {
                                        Planet planet = JsonSerializer.Deserialize<Planet>(sr);
                                        planets.Add(planet.name);
                                    }
                                }
                            });
                        }
                    }
                });
            });

            List<(string, string, string, List<string>, List<string>)> tuple = results.Select(s => (name: s.name, price: s.cost_in_credits, length: s.length, films: films, planets: planets)).ToList();

            using (StreamWriter sw = new StreamWriter("vaisseau.txt"))
            {
                sw.WriteLine("Nom du Vaisseau,Prix,Longueur,Films,Planetes");
                tuple.ForEach(d =>
                {
                    Console.WriteLine($"{d.Item1},{d.Item2},{d.Item3},{d.Item4.ForEach(f => "".Join(f))}");
                });
            }
        }
    }

    public class Starship
    {
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string length { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
        public string starship_class { get; set; }
        public List<object> pilots { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        public Starship(string name, string model, string manufacturer, string cost_in_credits, string length, string max_atmosphering_speed, string crew, string passengers, string cargo_capacity, string consumables, string hyperdrive_rating, string mGLT, string starship_class, List<object> pilots, List<string> films, DateTime created, DateTime edited, string url)
        {
            this.name = name;
            this.model = model;
            this.manufacturer = manufacturer;
            this.cost_in_credits = cost_in_credits;
            this.length = length;
            this.max_atmosphering_speed = max_atmosphering_speed;
            this.crew = crew;
            this.passengers = passengers;
            this.cargo_capacity = cargo_capacity;
            this.consumables = consumables;
            this.hyperdrive_rating = hyperdrive_rating;
            MGLT = mGLT;
            this.starship_class = starship_class;
            this.pilots = pilots;
            this.films = films;
            this.created = created;
            this.edited = edited;
            this.url = url;
        }

        public Starship()
        {

        }
    }

    public class Peoples
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<People> results { get; set; }

        public Peoples(int count, string next, object previous, List<People> results)
        {
            this.count = count;
            this.next = next;
            this.previous = previous;
            this.results = results;
        }

        public void MostApparence()
        {
            People p = results.Aggregate((p, next) => p.films.Count > next.films.Count ? p : next);
        }

        public void ObiWanKenobiDrivingMillenium()
        {
            List<string> starships = results.Aggregate(new People(), (p, next) => p.name == "Obi-Wan Kenobi" ? p : next, p => p.starships);
            starships.ForEach(async starship =>
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(starship);
                    HttpResponseMessage res = await client.GetAsync(client.BaseAddress);
                    HttpContent cont = res.Content;
                    using (Stream s = await cont.ReadAsStreamAsync())
                    {
                        var sr = new StreamReader(s);
                        Starship star = JsonSerializer.Deserialize<Starship>(s);
                        if(star.name == "Millennium Falcon")
                        {
                            Console.WriteLine(true);
                        }
                    }
                }
            });
        }
    }

    public class People
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public List<string> films { get; set; }
        public List<object> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }

        public People(string name, string height, string mass, string hair_color, string skin_color, string eye_color, string birth_year, string gender, string homeworld, List<string> films, List<object> species, List<string> vehicles, List<string> starships, DateTime created, DateTime edited, string url)
        {
            this.name = name;
            this.height = height;
            this.mass = mass;
            this.hair_color = hair_color;
            this.skin_color = skin_color;
            this.eye_color = eye_color;
            this.birth_year = birth_year;
            this.gender = gender;
            this.homeworld = homeworld;
            this.films = films;
            this.species = species;
            this.vehicles = vehicles;
            this.starships = starships;
            this.created = created;
            this.edited = edited;
            this.url = url;
        }

        public People()
        {
            this.name = "A";
        }
    }

    public class Movies
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Movie> results { get; set; }

        public void mostLongTitle()
        {
            Movie movie = results.Aggregate((m, next) => m.title.Length > next.title.Length ? m : next);
        }
    }

    public class Movie
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public List<string> characters { get; set; }
        public List<string> planets { get; set; }
        public List<string> starships { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> species { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public Uri url { get; set; }

        public Movie(string title, int episode_id, string opening_crawl, string director, string producer, string release_date, List<string> characters, List<string> planets, List<string> starships, List<string> vehicles, List<string> species, DateTime created, DateTime edited, Uri url)
        {
            this.title = title;
            this.episode_id = episode_id;
            this.opening_crawl = opening_crawl;
            this.director = director;
            this.producer = producer;
            this.release_date = release_date;
            this.characters = characters;
            this.planets = planets;
            this.starships = starships;
            this.vehicles = vehicles;
            this.species = species;
            this.created = created;
            this.edited = edited;
            this.url = url;
        }
    }

    public class Planets
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Planet> results { get; set; }

        public Planets(int count, string next, object previous, List<Planet> results)
        {
            this.count = count;
            this.next = next;
            this.previous = previous;
            this.results = results;
        }

        public void mostHabitedPlanet()
        {
            Planet p = results.Aggregate((p, next) => Convert.ToInt64(p.population) > Convert.ToInt64(next.population) ? p : next);
        }
    }

    public class Planet
    {
        public string name { get; set; }
        public string roation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public List<string> residents { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public Uri url { get; set; }

        public Planet(string name, string roation_period, string orbital_period, string diameter, string climate, string terrain, string surface_water, string population, List<string> residents, List<string> films, DateTime created, DateTime edited, Uri url)
        {
            this.name = name;
            this.roation_period = roation_period;
            this.orbital_period = orbital_period;
            this.diameter = diameter;
            this.climate = climate;
            this.terrain = terrain;
            this.surface_water = surface_water;
            this.population = population;
            this.residents = residents;
            this.films = films;
            this.created = created;
            this.edited = edited;
            this.url = url;
        }
    }
    internal class Program
    {

        static async Task fetchPlanet(int id = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://swapi.dev/api/planets/");
                HttpResponseMessage res = await client.GetAsync(client.BaseAddress);
                HttpContent cont = res.Content;
                using (Stream s = await cont.ReadAsStreamAsync())
                {
                    var sr = new StreamReader(s);
                    Planets planets = JsonSerializer.Deserialize<Planets>(s);
                }
            }
        }

        static async Task Main(string[] args)
        {
            await fetchPlanet();
        }
    }
}
