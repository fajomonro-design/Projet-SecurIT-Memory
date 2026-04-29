# Projet-SecurIT-Memory

# SecurIT Memory 🛡️🧠
**Le mini-jeu interactif de cybersécurité**

## 📄 À propos
SecurIT Memory est un mini-jeu interactif développé pour le prochain stand de la start-up SecurIT au Salon de l'Innovation Tech. 
L'objectif de ce projet WinForms était de réaliser un jeu de cartes Memory mettant en scène des icônes de jojo pour plus de fun a fin d'améliorer leur mémoire

## 🚀 Fonctionnalités Clés

### 🎨 Interface & UX
* **Menu Intuitif :** Interface d'accueil professionnelle avec trois options : Jouer, Options (taille de la grille 4x4 ou 6x6) et Quitter.
* **Grille Dynamique :** Génération automatique de la zone de jeu en utilisant des PictureBox liées aux objets métiers.
* **Tableau de Bord :** Affichage en temps réel du chronomètre et du nombre d'essais courants pour stimuler le joueur
* **Design Thématique :** Utilisation d'images orientées cybersécurité pour les faces révélées et d'un design uniforme pour les faces cachées.

### ⚙️ Technique (C# & WinForms)
* **Programmation Orientée Objet (POO) :** Conception rigoureuse autour d'une classe Carte encapsulée (propriétés avec get et set) gérant son ID, son image et son état (Cachée, Révélée, Trouvée).
* **Moteur de Jeu & Collections :** Utilisation de listes (List<Carte>) et de la classe Random pour mélanger aléatoirement les cartes à chaque nouvelle partie.
* **Gestion Avancée des Timers :** Utilisation de System.Windows.Forms.Timer pour imposer un délai de mémorisation (1 à 2 secondes) avant de retourner les cartes non-identiques.
* **Sécurité de l'Interface :** Blocage dynamique des clics utilisateurs pendant le fonctionnement du Timer pour éviter la corruption de la logique de jeu.

## 🛠️ Stack Technique
Ce projet a été réalisé en binôme en utilisant C# et Visual Studio (technologie WinForms). Il repose sur une architecture en trois couches garantissant une séparation claire entre la logique de jeu, l'interface graphique et la gestion des données.


Développeur 1 : La Logique (Fichiers Carte.cs et JeuMemory.cs)
Pendant que l'autre s'occupe du visuel, ce développeur code le "moteur" du jeu sans jamais se soucier de l'interface graphique.
•    La logique interne de la classe Carte : Implémenter le constructeur et les méthodes (par exemple, une méthode Retourner()).
•    La classe JeuMemory : Coder la création de la liste complète des cartes (List<Carte>) et l'algorithme qui les mélange aléatoirement avec Random.
•    Le système de vérification : Créer une méthode qui reçoit deux cartes en paramètres, compare leurs identifiants numériques (ID), et renvoie vrai si c'est une paire, ou faux sinon.
•    Astuce pour ne pas attendre : Pour tester ce code sans l'interface visuelle, ce développeur peut utiliser de simples Console.WriteLine en arrière-plan pour vérifier que le mélange et les comparaisons fonctionnent.
__
Développeur 2 : L'Interface (Fichiers FormMenu.cs et FormJeu.cs)
Ce développeur conçoit l'interface graphique (WinForms) sans se soucier de la logique de validation des paires.
•    Création du Menu Principal : Placer les boutons Jouer, Options et Quitter, et coder le passage d'une fenêtre à l'autre.
•    Génération visuelle de la Grille : Coder une boucle qui crée dynamiquement des PictureBox sur la fenêtre.
•    Mise en place des "Bouchons" (Mockup) : Pour avancer sans attendre la vraie logique du Développeur 1, ce développeur peut associer de fausses images aux PictureBox et afficher des MessageBox temporaires au clic (ex: "Vous avez cliqué sur la carte 3").
•    Préparation du Timer et des Labels : Placer les compteurs d'essais et le chronomètre, et préparer le System.Windows.Forms.Timer pour le délai de 1 à 2 secondes.
curité, dos des cartes).
    * Intégration des Labels pour le suivi en temps réel du score et du chronomètre.
