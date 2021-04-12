# Uppgift 5
*Vilket väder vi har va?*
Ni ska bygga något som analyserar temperaturavläsningar från en källa, i uppgiftens fall en fil med datum, klockslag och temperatur (den är från vår sensor som är placerad i köksfönstret som mäter utomshustemperatur och sträcker sig någon vecka bakåt i tiden).

Er applikation skall kunna:
- Visa datum och tidpunkt samt temperatur för den kallaste ⛄ dagen
- Visa datum och tidpunkt samt temperatur för den varmaste 🔥 dagen
- Visa snitttemperatur för hela förekomsten

## BONUS
- Visa snittemperatur för dagtid (tex klockslag mellan 08 - 17)
- Visa snittemperatur nattetid (tex klockslag mellan 00 - 05)

## TIPS

Bifogad fil (temperatures.csv) är en "csv" fil (egentligen en vanlig text-fil) med fält som är semikolon-separerade. En bra sak kan vara att abstrahera bort det som läser in filen och se till att den saken returnerar objekt som är lätta att jobba med när man väl gör sina analyser...

Vi har ännu inte gått igenom hur man läser in data från filer, men ett snabbt tips är:
```File.ReadAllLines(...)```
som ett exempel.
Filen innehåller lite olika fält, en tidstämpel i unix epoch-format, en temperatur och en tidstämpel i mera läsbart format. Ni väljer själva hur ni tolkar innehållet i filen.

Lycka till!