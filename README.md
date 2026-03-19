# Projet-SecurIT-Memory

# SecurIT Memory 🛡️🧠
**Le mini-jeu interactif de cybersécurité**

## 📄 À propos
SecurIT Memory est un mini-jeu interactif développé pour le prochain stand de la start-up SecurIT au Salon de l'Innovation Tech. 
L'objectif de ce projet WinForms était de réaliser un jeu de cartes Memory mettant en scène des icônes de cybersécurité (mots de passe, pare-feu, virus, etc.) pour captiver les visiteurs et tester leur mémoire. 

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

**Chef de Projet / Lead Logique : [Prénom Élève 1]**
* **Rôle :** Conception Orientée Objet, Développement C# (Moteur de jeu), Gestion des Timers.
* **Tâches réalisées :**
    * Création de la classe Carte avec respect strict de l'encapsulation.
    * Développement des algorithmes de mélange aléatoire et de vérification des paires.
    * Implémentation du System.Windows.Forms.Timer pour le délai de retournement et blocage des clics.
    * Gestion du dépôt GitHub et rédaction de la documentation.

**Membre de l'équipe : [Prénom Élève 2]**
* [cite_start]**Rôle :** Lead UI/UX & Intégrateur WinForms.
* **Tâches réalisées :**
    * Conception du formulaire Menu Principal (Jouer, Options, Quitter).
    * Génération dynamique de la grille de jeu avec intégration des PictureBox.
    * Mise en place des visuels (icônes cybersécurité, dos des cartes).
    * Intégration des Labels pour le suivi en temps réel du score et du chronomètre.
