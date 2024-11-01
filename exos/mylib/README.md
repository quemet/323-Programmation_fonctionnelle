# Utilitaires pour le quotidien
Quand on doit écrire du code technique pour réaliser une opération qui paraît "simple" et de manière répétée, on 
utilise parfois le terme `boilerplate code`.

Vous avez sûrement écrit beaucoup de ce code et il est temps de rendre l'écriture de ce code moins rébarbative
avec quelques extensions.

## Programme de base 🏠

Voici un programme qu'il s'agit de faire compiler et fonctionner sans le modifier et donc en ajoutant une classe
d'extension...

Pour rappel, la [théorie est là](../../supports/source/05-Extension.md).

```csharp
//Entrées
int year = "Année de naissance: ".ReadInt();
$"Vous avez {DateTime.Now.Year-year} ans".Write(ConsoleColor.Green);

// Conversions
string input = "123";
int number = input.ToIntSafe();
Console.WriteLine($"Nombre converti : {number}");
Console.WriteLine($"Pas un nombre, valeur par défaut : {"notANumber".ToIntSafe()}");
Console.WriteLine($"Pas un nombre, valeur par défaut spécifique : {"notANumber".ToIntSafe(-1)}");

//Random
var random = new Random();
string randomStr = random.RandomString(8);
Console.WriteLine($"Chaîne aléatoire : {randomStr}");
bool randomBool = random.RandomBool();
Console.WriteLine($"Booléen aléatoire: {randomBool}");
```

<details>
<summary>Aide pour commencer</summary>

```csharp
public static class Ext
{
    /// Corps de la fonction à compléter
    public static int ReadInt(this string prompt)
    {
        int result;
        do
        {
            Console.Write(prompt);
        } while (false);
        return result;
    }
}
```
</details>

## Améliorations 🧙
Maintenant que ce code fonctionne, on peut aller un peu plus loin.
Pour chacun des cas suivants, ajouter **l'extension** ainsi qu'un **exemple d'utilisation** :

- Ajouter la saisie de
  - nombre à virgule
  - date (en prenant soin de gérer le format d'une manière ou d'une autre)

- Ajouter la conversion pour 
  - les nombres à virgule
  - les dates

- Offrir la possibilité de spécifier la couleur de fond aussi
- Offrir la possibilité de faire du WriteLine aussi
- Ajouter une fonction `Print` qui permet d'afficher du texte selon les éléments suivants :
  - couleur fond/lettre
  - aligner le texte à gauche, au milieu, à droite (selon une longueur spécifique)
- Ajouter une fonction `Ellipse` qui transforme un texte de N caractères en N-X caractères suivis de `...`

## À vous de jouer ▶
- Créer un projet Librairie pour des extensions
- Identifier dans les programmes existants le code répétitif nécessaire et ajouter des extensions pour le simplifier.
- Publier le DLL et le stocker à un endroit pratique OU 
[faire un package nuget](https://learn.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-visual-studio?tabs=netcore-cli).
