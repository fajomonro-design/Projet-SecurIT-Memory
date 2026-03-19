# Projet-SecurIT-Memory

# SecurIT Memory 🛡️🧠
**Le mini-jeu interactif de cybersécurité**

## 📄 À propos
[cite_start]SecurIT Memory est un mini-jeu interactif développé pour le prochain stand de la start-up SecurIT au Salon de l'Innovation Tech[cite: 4, 5]. 
[cite_start]L'objectif de ce projet WinForms était de réaliser un jeu de cartes Memory mettant en scène des icônes de cybersécurité (mots de passe, pare-feu, virus, etc.) pour captiver les visiteurs et tester leur mémoire[cite: 6]. 

## 🚀 Fonctionnalités Clés

### 🎨 Interface & UX
* [cite_start]**Menu Intuitif :** Interface d'accueil professionnelle avec trois options : Jouer, Options (taille de la grille 4x4 ou 6x6) et Quitter[cite: 65, 66, 68, 69, 70].
* [cite_start]**Grille Dynamique :** Génération automatique de la zone de jeu en utilisant des PictureBox liées aux objets métiers[cite: 73, 74].
* [cite_start]**Tableau de Bord :** Affichage en temps réel du chronomètre et du nombre d'essais courants pour stimuler le joueur[cite: 75, 76].
* [cite_start]**Design Thématique :** Utilisation d'images orientées cybersécurité pour les faces révélées et d'un design uniforme pour les faces cachées[cite: 77, 78, 79].

### ⚙️ Technique (C# & WinForms)
* [cite_start]**Programmation Orientée Objet (POO) :** Conception rigoureuse autour d'une classe Carte encapsulée (propriétés avec get et set) gérant son ID, son image et son état (Cachée, Révélée, Trouvée)[cite: 50, 52, 55, 57, 58, 59].
* [cite_start]**Moteur de Jeu & Collections :** Utilisation de listes (List<Carte>) et de la classe Random pour mélanger aléatoirement les cartes à chaque nouvelle partie[cite: 61, 86].
* [cite_start]**Gestion Avancée des Timers :** Utilisation de System.Windows.Forms.Timer pour imposer un délai de mémorisation (1 à 2 secondes) avant de retourner les cartes non-identiques[cite: 98, 99].
* [cite_start]**Sécurité de l'Interface :** Blocage dynamique des clics utilisateurs pendant le fonctionnement du Timer pour éviter la corruption de la logique de jeu[cite: 100, 101].

## 🛠️ Stack Technique
[cite_start]Ce projet a été réalisé en binôme en utilisant C# et Visual Studio (technologie WinForms)[cite: 7, 20]. [cite_start]Il repose sur une architecture en trois couches garantissant une séparation claire entre la logique de jeu, l'interface graphique et la gestion des données[cite: 39, 44].

---

**Chef de Projet / Lead Logique : [Prénom Élève 1]**
* [cite_start]**Rôle :** Conception Orientée Objet, Développement C# (Moteur de jeu), Gestion des Timers[cite: 42, 44, 48].
* **Tâches réalisées :**
    * [cite_start]Création de la classe Carte avec respect strict de l'encapsulation[cite: 59].
    * [cite_start]Développement des algorithmes de mélange aléatoire et de vérification des paires[cite: 86, 89, 90].
    * [cite_start]Implémentation du System.Windows.Forms.Timer pour le délai de retournement et blocage des clics[cite: 98, 99, 100].
    * [cite_start]Gestion du dépôt GitHub et rédaction de la documentation[cite: 20, 137].

**Membre de l'équipe : [Prénom Élève 2]**
* [cite_start]**Rôle :** Lead UI/UX & Intégrateur WinForms[cite: 40, 44].
* **Tâches réalisées :**
    * [cite_start]Conception du formulaire Menu Principal (Jouer, Options, Quitter)[cite: 64, 65].
    * [cite_start]Génération dynamique de la grille de jeu avec intégration des PictureBox[cite: 72, 73].
    * [cite_start]Mise en place des visuels (icônes cybersécurité, dos des cartes)[cite: 77, 79].
    * [cite_start]Intégration des Labels pour le suivi en temps réel du score et du chronomètre[cite: 75, 76].

---

### 🗺️ Roadmap Technique (Fonctionnalités Bonus)
Si le projet devait être poursuivi (ou pour les bonus de l'évaluation), voici la roadmap :
* [cite_start][ ] **Leaderboard SQL :** Connexion à une base de données locale pour sauvegarder les scores et afficher un classement dynamique[cite: 106, 107].
* [cite_start][ ] **Thèmes de Cartes :** Ajout de plusieurs thèmes visuels (Matériel, Logiciel, Cryptographie) sélectionnables dans les options[cite: 108, 109].
* [cite_start][ ] **Effets Sonores :** Ajout de sons immersifs (clic, succès, fanfare de victoire)[cite: 111, 112].
* [cite_start][ ] **Mode Hardcore :** Implémentation d'un mode où les cartes non-trouvées échangent leurs positions toutes les 30 secondes[cite: 113, 114].
