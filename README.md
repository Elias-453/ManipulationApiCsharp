ManipulationApiCsharp
Salut, bienvenue sur mon projet. Je suis en train d'apprendre le C# et le développement web. Après avoir bossé les bases avec des cours comme ceux de Bro Code et quelques exercices de mon côté, je me lance ici dans mon tout premier projet d'envergure.

C'est une application complète de catalogue de jeux et de films qui combine un back-end en C# et un front-end simple en HTML, CSS et JavaScript.

Ce que j'ai fait et mis en place
Le Back-End avec C# et ASP.NET Core
Création d'une API REST : J'ai mis en place un serveur avec des contrôleurs pour exposer mes données proprement.

Les routes et le CRUD complet : J'ai géré toutes les méthodes HTTP de base pour faire le pont avec la base de données :

Des routes GET pour récupérer la liste complète des jeux ou chercher un élément précis.

Une route POST pour envoyer et enregistrer un nouveau jeu dans le catalogue.

Une route PUT pour modifier les informations d'un jeu existant.

Une route DELETE pour supprimer un élément de la base.

Les DTOs (Data Transfer Objects) : J'ai utilisé des objets de transfert de données pour séparer la structure de ma base de données de ce qui est affiché ou reçu par l'API. Ça permet de garder le code propre, de contrôler exactement quelles données transitent et d'éviter d'exposer directement mes modèles de données internes.

Le fichier appsettings.json : Je m'en suis servi pour configurer proprement mon application, notamment pour stocker la chaîne de connexion à la base de données SQLite et paramétrer les environnements.

Base de données et Entity Framework Core : J'ai utilisé EF Core avec SQLite pour gérer le stockage local, faire le lien entre mes classes C# et les tables de la base de données, et suivre les migrations.

Swagger : Je l'ai utilisé pour tester mes routes directement dans le navigateur et voir si tout répondait bien.

Le Front-End et l'Intégration
Interface sur mesure : J'ai codé une interface en HTML et CSS avec un style terminal rétro (tons sombres, polices monospaces et bordures personnalisées), loin des designs par défaut générés automatiquement.

JavaScript et liaison avec l'API : J'utilise du code en JavaScript pur avec des requêtes fetch pour aller chercher les données de mon API C# et les afficher dynamiquement sous forme de cartes sur la page.

Recherche en temps réel : J'ai ajouté une barre de recherche interactive qui filtre instantanément les jeux affichés selon ce que tu tapes.

Intégration d'une API externe : Le site va chercher en plus des images de couverture pour chaque jeu en interrogeant l'API publique de RAWG à partir du titre.
