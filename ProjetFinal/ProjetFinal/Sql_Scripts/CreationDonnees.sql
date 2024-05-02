USE DevLibraryDB;
GO

INSERT INTO Utilisateur (Nom, Email, DateInscription, LangagesDeProgrammation, BibliothequesPreferees, Rue, Ville, Pays, CodePostal)
VALUES 
('John Doe', 'unique.john.doe@example.com', '2022-01-01', 'C#, SQL', 'Standard Library', '123 Maple Street', 'Springfield', 'USA', '12345'),
('Jane Smith', 'unique.jane.smith@example.com', '2022-02-01', 'Java, Python', 'Data Science Toolkit', '456 Oak Avenue', 'Shelbyville', 'USA', '67890'),
('Alice Johnson', 'unique.alice.johnson@example.com', '2022-03-01', 'JavaScript, HTML', 'Frontend Frameworks', '789 Pine Road', 'Metropolis', 'USA', '10112'),
('Bob Williams', 'unique.bob.williams@example.com', '2022-04-01', 'PHP, MySQL', 'Web Development Tools', '321 Birch Lane', 'Gotham', 'USA', '20224'),
('Charlie Brown', 'unique.charlie.brown@example.com', '2022-05-01', 'Ruby, Rails', 'Web Application Frameworks', '654 Elm Street', 'Star City', 'USA', '30336'),
('Diana Prince', 'unique.diana.prince@example.com', '2022-06-01', 'Python, Django', 'Web Frameworks', '987 Cedar Boulevard', 'Themyscira', 'USA', '40448'),
('Edward Norton', 'unique.edward.norton@example.com', '2022-07-01', 'C++, Boost', 'System Programming', '123 Aspen Circle', 'Fight Club', 'USA', '50560');
GO

INSERT INTO Bibliothèque (Nom, Description, DateCreation, Categorie)
VALUES
('Web Development Essentials', 'Frameworks and tools for building modern websites', '2020-03-10', 'Web Development'),
('Game Development Frameworks', 'Libraries and engines for creating video games', '2019-07-22', 'Game Development'),
('Mobile App Development Kit', 'Resources for building mobile applications', '2020-11-30', 'Mobile Development'),
('Cloud Computing Solutions', 'Technologies for deploying and managing cloud services', '2021-09-05', 'Cloud Computing'),
('Network Security Suite', 'Tools for securing computer networks', '2018-12-18', 'Security'),
('UI/UX Design Templates', 'Design assets for creating user interfaces', '2019-04-25', 'Design'),
('Embedded Systems Library', 'Software components for embedded system development', '2021-02-14', 'Embedded Systems'),
('Robotics Framework', 'Frameworks for programming and controlling robots', '2020-08-09', 'Robotics'),
('Artificial Intelligence Toolbox', 'Libraries and algorithms for AI applications', '2019-10-12', 'Artificial Intelligence'),
('Blockchain Development Kit', 'Resources for building blockchain-based applications', '2021-04-17', 'Blockchain');
GO

INSERT INTO MiseÀJour (Version, DescMiseÀJour, IdBibliothèque)
VALUES 
('1.0.1', 'Bug fixes and performance improvements', 1),
('2.0.0', 'Major update with new features', 2),
('2.0.1', 'Added additional security features', 1),
('2.0.2', 'Improved user interface', 2),
('2.0.3', 'Fixed critical bug affecting performance', 1),
('2.1.0', 'Introduced new API endpoints', 2),
('2.1.1', 'Optimized database queries', 1),
('2.1.2', 'Enhanced error handling', 2),
('2.1.3', 'Improved documentation', 1),
('2.2.0', 'Added support for new data formats', 2);
GO

INSERT INTO Critique (Date, Message, Rating, NomUtilisateur, IdBibliothèque)
VALUES 
('2022-03-01', 'Very useful library for my projects.', 5, 'John Doe', 1),
('2022-04-10', 'I love the new features in this update.', 4, 'Jane Smith', 2),
('2022-05-15', 'Great improvements, keep up the good work!', 4, 'Alice Johnson', 1),
('2022-06-20', 'Best library I have used so far.', 5, 'Bob Brown', 2),
('2022-07-25', 'Easy to integrate into my projects.', 4, 'Eve White', 1),
('2022-08-30', 'Helped me speed up development.', 5, 'Charlie Green', 2),
('2022-09-05', 'Looking forward to future updates.', 4, 'Grace Davis', 1),
('2022-10-10', 'Highly recommended for all developers.', 5, 'Harry Black', 2),
('2022-11-15', 'Solved a critical issue in my project.', 5, 'Olivia Grey', 1),
('2022-12-20', 'Excellent support team.', 4, 'Sophia Lee', 2);
GO

INSERT INTO Fonction (Nom, Description, NombreLignesDeCode, DernierUpdate, IdBibliothèque)
VALUES 
('Logging Function', 'Provides application logging functionality', 150, '2022-03-01', 1),
('Data Analysis Function', 'Functions for statistical data analysis', 200, '2022-04-15', 2),
('Authentication Function', 'Handles user authentication', 180, '2022-05-20', 1),
('Reporting Function', 'Generates reports based on data analysis', 220, '2022-06-25', 2),
('Security Function', 'Implements security measures', 190, '2022-07-30', 1),
('Search Function', 'Provides search functionality', 210, '2022-08-05', 2),
('Notification Function', 'Sends notifications to users', 170, '2022-09-10', 1),
('Integration Function', 'Integrates with external systems', 230, '2022-10-15', 2),
('Performance Function', 'Optimizes application performance', 240, '2022-11-20', 1),
('UI Function', 'Handles user interface components', 260, '2022-12-25', 2);
GO

INSERT INTO RéglageConfig (Theme, nomMembre, langPref, notificationAct)
VALUES 
('Dark Mode', 'John Doe', 'English', 1),
('Light Mode', 'Jane Smith', 'French', 0),
('Custom Theme', 'Alice Johnson', 'German', 1),
('High Contrast Mode', 'Bob Brown', 'Spanish', 0),
('Accessibility Theme', 'Eve White', 'Dutch', 1),
('Standard Theme', 'Charlie Green', 'Italian', 0),
('Professional Theme', 'Grace Davis', 'Portuguese', 1),
('Simple Theme', 'Harry Black', 'Russian', 0),
('User-defined Theme', 'Olivia Grey', 'Chinese', 1),
('Basic Theme', 'Sophia Lee', 'Japanese', 0);
GO

DECLARE @i INT = 1;

WHILE @i <= 40
BEGIN
    INSERT INTO UtilisateurBibliothèque (IdUtilisateur, IdBibliothèque, DateTelechargement)
    VALUES (@i, (@i % 2) + 1, DATEADD(day, @i, '2024-01-01'));
    SET @i = @i + 1;
END;
GO