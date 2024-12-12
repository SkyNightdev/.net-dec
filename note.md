# Note sur l'application MVC pour la gestion des enseignants, étudiants et événements

Cette application est conçue pour gérer trois entités principales : **enseignants**, **étudiants**, et **événements**. Elle suit le modèle MVC (Modèle-Vue-Contrôleur) en utilisant ASP.NET Core et Entity Framework pour gérer les données de manière dynamique.

## Informations général
Lancer un programme : dotnet run
    -> le premier fichier qui se lance est Program.cs
    -> faire attention au ligne d erreur dans le run

Mvc est un framework.

Les methodes des controllers sont des actions.
Les controllers sont ceux qui gèrent l'app, ce sont les "cerveaux" de l'application.

fichier layout = Header + footer

Il est IMPORTANT de toujours mettre @Models "nomdelafonciton" dans les pages où l'on utilise les controllers.

Dans le Dossier Views, il contient les fichiers qui permet de faire les formulaires et d'afficher la liste que l'on veux dans index.
Chaque form est lié au controller "StudentController" et "TeacherController", dans ce fichier se tiennent les informations brutes des tableaux.

"@**@" permet de faire un commentaire dans les vues.

Lors de la récupération de donnée de formulaire, on récupère seulement les informations importantes.

Pomelo est utiliser pour se connecter sur la BDD sql.
Le mapping objet relationnel permet de manipuler la BDD les classes et instance sur l'application.

BDD -> entité (permet d'éviter des données brutes dans les controllers)

Installation de Pomelo et d'un autre outil : dotnet tool install --global dotnet-ef



## Fonctionnement général

### 1. Gestion des enseignants
- **Liste des enseignants :**
  - La page d'accueil des enseignants affiche une liste de tous les enseignants enregistrés.
  - Chaque ligne contient les informations de base (prénom, nom, email, site personnel).

- **Ajout d'un enseignant :**
  - Un formulaire permet de saisir les informations suivantes : prénom, nom, email et site personnel.
  - Les champs obligatoires sont validés avant l'enregistrement.
  - Les données sont sauvegardées dans une base de données.

- **Modification d'un enseignant :**
  - L'utilisateur peut sélectionner un enseignant et modifier ses informations.
  - Les validations s'assurent que les données sont correctes.

- **Suppression d'un enseignant :**
  - Une confirmation est demandée avant la suppression.

- **Afficher les étudiants associés :**
  - Chaque enseignant peut être lié à plusieurs étudiants. Une page affiche tous les étudiants associés à un enseignant.




### 2. Gestion des étudiants
- **Liste des étudiants :**
  - La liste affiche tous les étudiants enregistrés avec leurs informations de base : prénom, nom, âge, spécialisation ("Major") et enseignant assigné.
  - Si un étudiant n'est pas assigné à un enseignant, il est marqué comme "Non assigné".

- **Ajout d'un étudiant :**
  - Un formulaire permet de saisir les informations suivantes : prénom, nom, âge, date d'admission, GPA, spécialisation et enseignant assigné.
  - Une liste déroulante permet de sélectionner un enseignant.
  - Les validations vérifient que tous les champs obligatoires sont remplis.

- **Modification d'un étudiant :**
  - Les données d'un étudiant peuvent être modifiées en sélectionnant l'étudiant dans la liste.
  - Les validations s'appliquent ici aussi.

- **Suppression d'un étudiant :**
  - L'utilisateur peut supprimer un étudiant avec une confirmation.




### 3. Gestion des événements
- **Liste des événements :**
  - Tous les événements sont listés avec leur titre, description, date, lieu et enseignant organisateur.

- **Ajout d'un événement :**
  - Un formulaire permet de créer un événement avec les informations suivantes : titre, description, date de l'événement, nombre maximum de participants, lieu, et enseignant organisateur.
  - Une liste déroulante affiche les enseignants disponibles.
  - Les données sont validées avant l'enregistrement.

- **Modification d'un événement :**
  - Les détails d'un événement peuvent être modifiés à tout moment.
  - Les validations garantissent que les données restent cohérentes.

- **Suppression d'un événement :**
  - Une page de confirmation permet de supprimer un événement.





## Points techniques

- **Base de données :**
  - Utilisation d'Entity Framework Core pour la gestion de la base de données relationnelle.
  - Les entités `Teacher`, `Student` et `Event` sont liées par des relations clé étrangère.
  - Les données sont persistantes, c'est-à-dire qu'elles ne disparaissent pas après le redémarrage de l'application.



- **Architecture MVC :**
  - Les **modèles** (`Teacher`, `Student`, `Event`) représentent les données.
  - Les **contrôleurs** (ex. `TeacherController`, `StudentController`, `EventController`) gèrent la logique de l'application.
  - Les **vues** (fichiers `.cshtml`) affichent les données et reçoivent les entrées utilisateur.



- **Validation des données :**
  - Des attributs comme `[Required]`, `[StringLength]`, et `[Range]` assurent la validation des champs.
  - Les erreurs de validation sont affichées directement dans les formulaires.



## Utilisation de l'application
1. **Naviguer entre les sections :**
   - Les sections pour les enseignants, les étudiants, et les événements sont accessibles via des liens de navigation.



2. **Ajout et gestion des données :**
   - Pour chaque entité, des actions CRUD (Create, Read, Update, Delete) sont disponibles.
   - Les listes affichent toutes les entités enregistrées avec des options pour modifier ou supprimer chaque entrée.



3. **Relations entre entités :**
   - Les enseignants peuvent organiser des événements.
   - Les étudiants peuvent être assignés à un enseignant et participer à des événements.



## Conclusion
Cette application offre une solution complète pour gérer des enseignants, étudiants, et événements de manière intuitive et efficace. Grâce à son architecture MVC et à Entity Framework Core, elle est extensible et maintenable pour de futurs besoins.