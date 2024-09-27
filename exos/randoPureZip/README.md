# Vous avez aimé Rando ?
![Alt text](rando.png)

En voilà encore un peu, rien que pour vos yeux ;-)

## Rappel

[exo original](../rando/)

1. Un fichier GPX
2. Une distance à calculer
3. Quelques étapes intermédiaires

### Pseudo-Code
```text
Lire le fichier et le mapper dans un IEnumerable
Aggréger son contenu en additionnant la distance
```

### Idée de code avec un accumulateur et une classe anonyme
```csharp
var distanceInKm = points

    //Saute le premier élément donné manuellement à l’accumulateur
    .Skip(1)

    //Upgrade des Trackpoints en une classe anonyme pour ajouter une composante
    //"Dist" pour accumuler la distance
    .Select(point => new { 
        Lat = point.Latitude, 
        Long = point.Longitude, 
        Ele = point.Elevation, 
        Dist = 0.0 }
    )

    //Accumulation de la distance
    .Aggregate( 
            new {   //Injection du premier élément
                   Lat = points.First().Latitude, 
                   Long = points.First().Longitude,
                   Ele = points.First().Elevation,
                   Dist = 0.0
            }, 
            (a, b) =>
                 new 
                 {
                     Lat = a.Lat,
                     Long = a.Long,
                     Ele = a.Ele,
                     Dist = a.Dist + CalculDistanceA(a.Lat, b.Lat, a.Long, b.Long)
                 }

            , 
            result => result.Dist);

```

> Le dénivelé n’est pas pris en compte dans cet exemple...

## ZIP
C’est pour compresser ?

![Alt text](zip.png)

### Regardons encore une fois l’image

![aie](zip2.png)

ZIP fait référence à la fermeture éclair et `ZIP` est une sorte de fonction *MultiMap* qui permet de transformer 2 listes en une seule (et non pas l’aplatir comme le ferait un aggrégateur même s’il y a une forme de réduction (on passe de 2 à 1)) :

![Alt text](linqZip.png)

Ainsi avec `ZIP` on pourrait refaire le calcul de la distance ainsi:

```csharp

var distanceInKm = points

    .Zip(points.Skip(1)/*Décalage*/,
            (a, b) =>
                new
                {
                    //Stocke la distance relative entre a et b
                    Dist = CalculDistanceA(a.Latitude, b.Latitude, a.Longitude, b.Longitude)
                }
         )
    .Sum(a=>a.Dist);

```

Et économiser encore quelques lignes de code ;-)


Pouvez-vous toutefois vérifier par la pratique que cela fonctionne avec cette version et ainsi entraîner le `ZIP` et faire un commit/push ?

## Version récursive ?
À vous de jouer une fois la théorie vue sur ce point