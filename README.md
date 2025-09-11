Gameplay
Snake.cs

Snake
Représente le joueur. Le corps est géré avec une Queue<(int x, int y)>.

Dir() : récupère les touches directionnelles.

Update() : fait avancer le serpent (ajoute une tête, enlève la queue).

AddSegment() / DelSegment() : ajoute ou enlève un segment.

Draw() : dessine chaque segment, la tête est en vert clair.

Food.cs

Food
Objet que le serpent peut manger. Deux types possibles :

NORMAL (rouge)

VENIMOUS (magenta)

RandomFood() : choisit un type aléatoire.

resPawnFood() : génère une nouvelle position et un nouveau type.

Draw() : dessine la nourriture en fonction de son type.

Collider.cs

Collider
Gère toutes les collisions.

WallCollider : si le serpent sort de la grille → GameOver.

ItSelfCollider : si le serpent se mord lui-même → GameOver.

FoodCollider : si le serpent mange → ajoute des points, un segment, replace la nourriture et déclenche Animator.

Score.cs

Score (singleton)
Stocke et affiche le score.

+10 points si la nourriture est normale.

+20 points si elle est venimeuse.

UI et Scènes
SceneMenu.cs

SceneMenu
Scène de menu avec des boutons.

Boutons disponibles : Play, Quitter (Options non activé).

Update() : gère les clics et change de scène.

SceneOption.cs

SceneOption
Scène d’options encore vide.
Affiche uniquement un texte “Bonjour je suis Option”.

SceneGameOver.cs

SceneGameOver
Scène affichée quand la partie est perdue.

Affiche “Game Over”.

Boutons : Restart, Menu, Quitter.

Les clics redémarrent le jeu, reviennent au menu ou quittent.

Button.cs

Button
Représente un bouton cliquable. Contient sa position (Rectangle), son texte, sa couleur et son état.

ButtonList
Gère une liste de boutons.

Update() : détecte clics et survols.

Draw() : dessine les boutons avec effet hover.

Rendu et Effets
Animator.cs

Animator (singleton)
Gère la caméra (Camera2D).

Effet actuel : Shake (tremblement via ShakeTimer()).

Extension prévue : mode Drunk (rotation 180°, commandes inversées, shake renforcé).

Grille et Constantes
Grid.cs

Grid (singleton)
Définit et dessine la grille de jeu (12x8 cases de 90px, espacées de 5px).

CellToScreen() : convertit une cellule en coordonnées écran.

Draw() : dessine la grille.

EnumType.cs

EnumType
Contient les énumérations du jeu.

Scene : Menu, GamePlay, Option, GameOver.

GridValue : Empty, Snake, Food, Outside.

FoodType : Normal, Venimous.

GameConst.cs

GameConst
Constantes utilisées pour l’UI.

WIDTH_BUTTON = 300

HEIGHT_BUTTON = 100

SPACEBETWEEN = 75

Twist du gameplay : ajouter des variantes ou mécaniques originales.

Affinage : améliorer la jouabilité (vitesse, collisions, transitions).

Affichage : peaufiner l’UI et les effets visuels.

Menu pause : permettre de mettre le jeu en pause, avec un petit “Game Feel” (fondu, freeze, overlay).

Fluidité : remettre les FPS à 60 pour un rendu plus smooth.

