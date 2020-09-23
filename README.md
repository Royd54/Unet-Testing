# GainPlay
De proefopdracht hield in, dat er een multiplayer game gemaakt moest worden.
Deze game moest vooral draaien over de server-side, omdat er op deze manier geen/weinig desync ontstaat.
De spelers hebben hierdoor een betere experience, wat de game natuurlijk leuk maakt.

## Leerdoelen 
Wat wil ik bereiken met dit project:
- Mijzelf introduceren aan Networking
- Basic logica van Netwroking begrijpen
- Verschil tussen client en server herkennen

## Scripts 

### PlayerMovement
Dit script zorgt voor de mogelijkheid om te bewegen in het spel.
Zodra er gechecked is of de speler de locale speler is, kan de speler zich over het veld bewegen.
De spelers kunnen ook de bal inspawnen met de spatie toets. 
Het spawnen wordt geregeld via de server. De client stuurt simpelweg een command naar de server en de server stuurt weer een bericht terug.
Hierdoor zien alle spelers dezelfde bal.

### BallBehaviour
Dit script zorgt voor de beweging van de bal.
Je kan zeggen dat dit script eigenlijk de core van de bal is, het script handled de client-side onderdelen van de ball bijvoorbeeld.
Denk aan collisions, speed en angles.

### BallMover
Dit script zorgt voor de beweging van de bal over de server (positie calls).
Dus dit script zorgt ervoor dat alle spelers de bal op de zelfde positie zien.
Hierdoor is er geen desync en wordt de ball via de server geverifieerd.

### DestroyBall
Dit script zorgt voor het deleten van de bal en voor de scores van de spelers.
De scores worden geupdate wanneer de ball een van de muren achter de spelers raakt.
De score wordt daarna via de server gelijk gezet, zodat beide spelers dezelfde scores zien.
Ook wordt de bal gedelete wanneer de muur achter de speler geraakt wordt. 
Verder wordt de server communicatie geregeld via Commands naar de server en ClientRPC's terug naar de clients (spelers). 


## Bronnen
De bronnen die ik heb gebruikt zijn:

- [Unet documentation](https://docs.unity3d.com/2018.4/Documentation/Manual/UNetOverview.html)
- [Korte Unet intro](https://www.youtube.com/watch?v=0H_ikQp9aTI)
- [Logica van networking](https://docs.unity3d.com/Manual/UNetActions.html)
- [Logica van Commands en RPC's](https://www.youtube.com/watch?v=9VW7ctwvNok)
