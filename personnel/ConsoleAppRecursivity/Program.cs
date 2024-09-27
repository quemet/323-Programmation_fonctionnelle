namespace ConsoleAppRecursivity
{
    internal class Program
    {
        static List<string> dirs = new List<string>();
        static List<string> fls = new List<string>();

        static void Main(string[] args)
        {
            Console.Write("Entrer le chemin voulu : ");
            string path = Console.ReadLine();

            if (path == "")
                path = ".";

            if(!Directory.Exists(path))
            {
                Console.WriteLine("Veuillez entrer un chemin correct");
                Main(args);
            }

            GetAllFilesFromDirectories(path);
            GetAllDirectories(path);

            Console.WriteLine("Il y a dans " + path + " " + dirs.Count + " dossiers et " + fls.Count + " Fichiers");
        }

        static void GetAllDirectories(string path)
        {
            foreach (var d in Directory.GetDirectories(path))
            {
                dirs.Add(d);
                GetAllFilesFromDirectories(d);
                GetAllDirectories(d);
            }
        }

        static void GetAllFilesFromDirectories(string path)
        {
            foreach (var file in Directory.GetFiles(path))
            {
                fls.Add(file);
            }
        }
    }
}
