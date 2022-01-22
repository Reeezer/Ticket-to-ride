# .NET - Ticket to Ride 

# Introduction 

"Ticket to Ride" en anglais ou "Les aventuriers du rail" en français, est un jeu de plateau dans lequel le but est de posséder des lignes de train permettant de relier des villes entre elles. 

Au début du jeu chaque joueur possède des objectifs représentant deux villes à lier, ainsi que quelques trains permettant par la suite d'acquérir des lignes de chemin de fer. Durant chaque tour, les joueurs vont devoir tenter de relier des villes, piocher des cartes trains, ou ajouter à leur collection un nouvel objectif. 

Le jeu a été développé en WPF utilisant C#.

# Manuel d'utilisation

## Démarrage de l'application

Afin de démarrer l'application, il suffit de lancer l'exécutable. Aucune configuration spécifique n'est nécessaire. 
Une fois l'application démarrée, l'utilisateur se trouve sur le menu de démarrage où il a la possibilité de:
- Démarrer la configuration d'une nouvelle partie
- Lire les règles du jeu
- Quitter l'application

![](https://i.imgur.com/V0xiRok.png)

## Règles du jeu

L'intégralité des règles du jeu de base se trouve dans le README.md du projet (en anglais).

Les règles du jeu peuvent aussi être consultées directement dans l'application, que ce soit au lancement ou durant une partie en cours.

![](https://i.imgur.com/YNL5AzA.png)

## Configuration d'une partie

L'utilisateur peut, à ce stade, définir le nombre de joueurs ainsi que leurs noms respectifs. Une partie peut se lancer avec au minimum 2 joueurs et au maximum avec 6 joueurs. Une fois la configuration terminée, la partie peut se lancer.

![](https://i.imgur.com/3MxWQoX.png)

> Chaque joueur possèdera une couleur qui lui est attribuée et qu'il ne pourra modifier, lui permettant de reconnaitre les lignes de chemin de fer qu'il possède.

## Déroulement d'une partie

Une partie se déroule au tour par tour, chaque joueur peut donc effectuer une action durant son tour:
- Piocher 1 ou 2 cartes trains
- Piocher 1 carte objectif
- Acquérir une ligne de chemin de fer

Si le joueur choisit une des actions disponibles, il ne peut effectuer que celle-ci durant ce tour. En effet, si le joueur pioche une carte train, il ne lui sera possible que d'en piocher une seconde durant le tour actuel.

De plus, durant son tour, le joueur peut visualiser certaines informations sur ce qu'il possède, ainsi que quelques informations générales sur ses adversaires.

> À tout moment, le joueur peut quitter la partie en cliquant sur le bouton 'Exit' en bas à droite. Il peut aussi visualiser les règles du jeu en cliquant sur le bouton 'Rules' situé au même endroit. Le score sera calculé en fonction des objectifs atteints et les valeurs des objectifs restants pénaliseront les joueurs en déduisant leur score.

### Visualisation d'informations

Durant la partie, le joueur en cours peut visualiser certaines informations sur ce qu'il possède, en effet à gauche de l'écran se trouve une liste d'information le concernant: *nom, couleur, score, nombre de trains restants, cartes objectifs*. 

![](https://i.imgur.com/3KPwDxb.png)

De plus, le joueur peut visualiser les cartes trains qu'il possède en bas de l'écran.

![](https://i.imgur.com/xNxksn6.png)

Le joueur peut aussi visualiser certaines informations à propos de ses adversaires à droite de l'écran: *nom, score, nombres de trains restants, nombre de cartes trains, nombre de cartes objectifs*. 
Ces informations seraient des informations que le joueur peut voir en un coup d'oeil dans une partie avec le plateau de jeu réel.

![](https://i.imgur.com/pya6YjT.png)

### Carte CFF

Au centre de l'écran se trouve la carte représentant les différentes villes, ainsi que les lignes de chemin de fer les reliant. 

![](https://i.imgur.com/eyyqkUJ.png)

Chaque ville est représentée sur cette carte par un point rouge entouré en noir, ainsi que le nom de celle-ci juste en dessous.

Chaque ligne de chemin de fer sur cette carte est représentée par un rectangle de couleur (indiquant la couleur des trains à utiliser pour l'acquérir) liant deux villes, ainsi qu'un numéro correspondant au nombre de trains nécessaires pour acquérir cette ligne de chemin de fer.

Si l'utilisateur ne reconnait pas bien la couleur et le numéro précisé sur la ligne de chemin de fer, il peut sélectionner la ligne de chemin de fer en cliquant dessus pour faire apparaitre un récapitulatif sur celle-ci à droite de l'écran.

![](https://i.imgur.com/b5Vv8gU.png)

### Piocher des cartes trains

Durant son tour, le joueur a la possibilité de piocher des cartes trains lui permettant par la suite d'acquérir de nouvelles lignes de chemin de fer. Pour ce faire, 5 cartes face visible sont affichées en haut de l'écran, ainsi que la pile restante face cachée. 

![](https://i.imgur.com/bTP07OE.png)

En cliquant sur une carte, le joueur peut la récupérer et l'ajouter à sa main affichée en bas de l'écran (le joueur peut cliquer sur les cartes faces visibles, ainsi que sur la pile face cachée). 

![](https://i.imgur.com/12Z9L9v.png)

Le joueur peut a chaque tour piocher deux cartes trains depuis les cartes visibles ou la pile. Cependant une carte locomotive (multicolore) dans les cartes visibles compte double, il ne sera plus possible pour l'utilisateur d'en piocher une seconde s'il la prend depuis les cartes face visibles. S'il a de la chance et qu'il tire une carte locomotive depuis la pile face cachée, la carte ne comptera pas double, et le joueur pourra en tirer une nouvelle. 

### Acquérir une ligne de chemin de fer

Durant son tour, le joueur peut acquérir une ligne de chemin de fer en utilisant des cartes trains qu'il a piochées au préalable. Pour ce faire le joueur doit sélectionner la ligne de chemin de fer souhaitée en cliquant dessus, puis sélectionner les différentes cartes qu'il va utiliser pour l'acquérir en cliquant sur les cartes de sa main. Les cartes sélectionnées seront transparentes pour pouvoir plus facilement les visualiser.

![](https://i.imgur.com/SHGXqPY.png)

Une fois que le joueur a sélectionné la ligne de chemin de fer et possède assez de cartes pour l'acquérir, il devra appuyer sur le bouton "**Claim connection**" à droite de l'écran. 

![](https://i.imgur.com/y89G6uq.png)

Une fois la ligne de chemin de fer acquise, elle sera entourée par la couleur du joueur qui la possède. Elle ne sera donc plus sélectionnable et achetable.

![](https://i.imgur.com/laoCDbB.png)

> Pour acquérir une ligne de chemin de fer grise, le joueur peut utiliser n'importe quelle carte train, la couleur n'a aucune importance. De plus, les cartes locomotives sont équivalentes à des jokers et peuvent donc être de n'importe quelle couleur.

### Piocher une carte objectif

Durant son tour, le joueur a la possibilité de piocher une nouvelle carte objectif en appuyant sur le bouton "**Take Goal card**"" à droite de l'écran.

![](https://i.imgur.com/y89G6uq.png)

Les cartes objectifs permettent de gagner des points en reliant deux villes, les points gagnés sont affichés directement sur la carte et dépendent de la difficulté de la liaison. Cependant, si le joueur ne termine pas un objectif, les points qu'il aurait dû gagner sont soustraits à son score à la fin de la partie.

Lorsqu'un joueur termine un objectif, la carte de l'objectif correspondant devient transparente et est mise à la fin des cartes objectifs, permettant au joueur de mieux visualiser les objectifs qu'il lui reste à remplir. De plus, les points de la carte sont ajoutés à son score total.

![](https://i.imgur.com/6AG4q8F.png)

### Fin de la partie

Une fois qu'un joueur n'a plus que 2 trains restants ou moins, la partie se termine. Il reste alors un tour à chaque joueur avant le calcul et l'affichage final des scores. 

## Menu des scores

Une fois la partie terminée, le menu des scores apparait. 

![](https://i.imgur.com/bsA8HBA.png)

Sur ce menu s'affichent les différents participants, ainsi que leurs scores, il est aussi possible de retourner au menu principal.

# Contraintes utilisateur

- La résolution minimale pour afficher le jeu est de 1920x1080px. Avec une résolution plus petite, il n'y a aucune garantie que l'intégralité du jeu puisse être visible. 

# Améliorations possibles 

- Cacher les cartes (la main, et les objectifs) pour éviter qu'un adversaire ne regarde.
- Adapter l'interface du jeu à des résolutions plus petites que 1920x1080px.
- Interface plus intuitive

# Sources

Pour ce projet, nous nous sommes basés sur une partie d'un projet existant à cette adresse: https://exceptionnotfound.net/ticket-to-ride-csharp-modeling-practice-part-1-intro-and-game-rules/.

Ce projet met en place l'application ticket to ride en console, nous l'avons donc repris et adapté afin d'en faire une application WPF. Nous n'avons utilisé, dans ce code, que certains models, ainsi qu'une partie de la logique du jeu nous ayant permis de mettre plus rapidement en place les règles de celui-ci.