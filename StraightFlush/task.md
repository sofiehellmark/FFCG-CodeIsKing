# Uppgift 4
## Straight Flush!

Ni ska bygga något som analyserar hur många olika givar det tar innan man får en Straight Flush från en vanlig kortlek direkt på given.

Innan man delar ut en giv (eller en hand) så ska kortleken blandas.
En giv (eller hand) består av 5 kort. Korten delas ut (i det här fallet bara till en enda spelare) ett i taget från toppen av leken.

Analysera handen och kontrollera om det är en Straight Flush (alltså en färgstege) man har fått. En Straight Flush kan alltså vara: "4 5 6 7 8 Hjärter". Fick man ingen Straight Flush blandar man om leken och försöker igen.

Det kan krävas tusen och åter tusen försök innan man lyckas så bygg något som snabbt kan blanda om kortleken och dela en ny hand som analyseras på nytt.

## TIPS
Lägg gärna in en ```Stopwatch.StartNew();``` som håller koll på hur lång tid analysen tar och räkna gärna upp antalet försök för att göra applikationen lite mer levande medan den jobbar. Här är ett exempel på enkel "metrics" man kan lägga in i sin loop:

```
tries++;
var elapsedTotalSeconds = stopwatch.Elapsed.TotalSeconds;
var avg = tries / elapsedTotalSeconds;
Console.Write($"\r{tries:N0} - {stopwatch.Elapsed} - Tries per second: {avg:N0}");
```

## BONUS
Bygg analysen så att man kan konfigurera vad man vill leta efter. Tex kanske man vill se hur lång tid det tar att få en enkel stege eller kanske en ROYAL Straight Flush.s