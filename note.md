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


