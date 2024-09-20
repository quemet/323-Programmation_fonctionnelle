namespace ConsoleAppMarket
{
    public class Seller
    {
        public int _emplacement { get; set; }
        public string _producteur { get; set; }
        public string _produit { get; set; }
        public int _quantity { get; set; }
        public string _unity { get; set; }
        public double _price_by_unity { get; set; }

        public Seller(int emplacement, string producteur, string produit, int quantity, string unity, double price_by_unity)
        {
            _emplacement = emplacement;
            _producteur = producteur;
            _produit = produit;
            _quantity = quantity;
            _unity = unity;
            _price_by_unity = price_by_unity;
        }
    }
    internal class Program
    {
        public static List<Seller> readPath(string path)
        {
            List<Seller> seller = new List<Seller>();
            using(StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split(';');
                    seller.Add(new Seller(Convert.ToInt32(words[0]), words[1], words[2], Convert.ToInt32(words[3]), words[4], Convert.ToDouble(words[5])));
                }
            }
            return seller;
        }
        static void Main(string[] args)
        {
            List<Seller> sellers = readPath("../../../Place du marché.csv");
            long countFishSeller = (from sel in sellers where sel._produit == "Pêches" select sel).LongCount();
            Seller seller = (from sel in sellers where sel._produit == "Pastèques" select sel).OrderByDescending(seller => seller._quantity).First();
            Console.WriteLine($"Il y a {countFishSeller} vendeur de pêches");
            Console.WriteLine($"C'est {seller._producteur} qui a le plus de pastèques (stand {seller._emplacement}, {seller._quantity} pièces)");
        }
    }
}
