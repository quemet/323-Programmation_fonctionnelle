using System;
using System.IO;

namespace ConsoleAppNCDU
{
    internal class Program
    {
        // Fonction pour obtenir les noms des sous-dossiers
        public static string[] getDirectoryName(string path)
        {
            string[] dirs = Directory.GetDirectories(path);

            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] = dirs[i].Substring(path.Length);
            }

            return dirs;
        }

        // Fonction pour obtenir les noms des fichiers
        public static string[] getFileName(string path)
        {
            string[] files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }

            return files;
        }

        // Fonction pour choisir l'unité de mesure pour les fichiers
        public static string ChooseUnity(long length)
        {
            if (length < 1000)
            {
                return $"{length,6} o ";
            }
            else if (length < 1000000)
            {
                return $"{length / 1000.0:F1,6} KiB";
            }
            else if (length < 1000000000)
            {
                return $"{length / 1000000.0:F1,6} MiB";
            }
            else
            {
                return $"{length / 1000000000.0:F1,6} GiB";
            }
        }

        // Fonction pour calculer la taille d'un répertoire
        public static long CalculateDirectorySize(DirectoryInfo d)
        {
            long size = 0;
            FileInfo[] f = d.GetFiles();
            foreach (FileInfo fi in f)
            {
                size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += CalculateDirectorySize(di);
            }
            return size;
        }

        // Fonction pour afficher les dossiers et les fichiers avec barres de progression
        public static void DisplayContent(string path, int sub_level, int max_level, long parentSize)
        {
            DirectoryInfo d = new DirectoryInfo(path);

            if (sub_level <= max_level)
            {
                FileInfo[] files = d.GetFiles();
                DirectoryInfo[] dirs = d.GetDirectories();

                foreach (FileInfo file in files)
                {
                    string sizeText = ChooseUnity(file.Length);
                    double percentage = (double)file.Length / parentSize * 100;
                    Console.WriteLine($"{new string(' ', sub_level * 2)}{sizeText} [{new string('#', (int)(percentage / 5))}] {file.Name}");
                }

                foreach (DirectoryInfo dir in dirs)
                {
                    long dirSize = CalculateDirectorySize(dir);
                    string sizeText = ChooseUnity(dirSize);
                    double percentage = (double)dirSize / parentSize * 100;
                    Console.WriteLine($"{new string(' ', sub_level * 2)}{sizeText} [{new string('#', (int)(percentage / 5))}] {dir.Name}");
                    DisplayContent(dir.FullName, sub_level + 1, max_level, parentSize);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Combien de niveaux voulez-vous (Pour les sous-dossiers) : ");
            int level = Convert.ToInt32(Console.ReadLine());

            const string PATH = "../../../";
            DirectoryInfo rootDir = new DirectoryInfo(PATH);
            long rootSize = CalculateDirectorySize(rootDir);

            Console.Clear();
            Console.WriteLine($"ncdu 1.14.1 ~ Use the arrow keys to navigate, press ? for help\n--- {PATH} ---");

            // Afficher le contenu du répertoire
            DisplayContent(PATH, 0, level, rootSize);
        }
    }
}
