# Uppgift 3

Guess what?! Ni ska bygga ett spel där man ska utgå från ett tärningskast och sedan gissa om nästa kast blir högre eller lägre.

Om man gissar rätt får man 1 poäng och man får försöka igen och då ska man utgå från föregående tärningskast och gissa om nästa blir högre eller lägre.

Gissar man fel tar spelet slut. Detsamma gäller om tärningskastet blir samma som förut då det varken är högre eller lägre.

**BONUS**

Om man gissar rätt tre gånger i rad ska man få 3 poäng istället för 1 för den gissningen. Så tre rätta gissningar i rad gör att man totalt har 5 poäng: 1 + 1 + 3.

**BONUS 2**

För varje tredje rätta gissning i följd får man fortsatt 3 poäng. Så poängen skulle då sättas 1 + 1 + 3 + 1 + 1 + 3... etc

**TIPS**
Kör spelet i en konsolapp för att hantera input och output (dvs det som visas till spelaren). Försök kapsla in logiken för själva spelet i en egen klass och skriv mer än gärna enhetstester!
Ni får använda vilken storlek ni vill på tärningen. Logiken för en enkel tärning skulle kunna vara:
````
//Tärningskast på tärning med sex sidor.
var roll = new Random().Next(1, 6); 
```