-- Створення бази даних
CREATE DATABASE IF NOT EXISTS ArtGallery;
USE ArtGallery;

-- Таблиця Users
CREATE TABLE IF NOT EXISTS Users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL
);

-- Таблиця ArtMovements
CREATE TABLE IF NOT EXISTS ArtMovements (
    movement_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    description TEXT NOT NULL
);

-- Таблиця Genres
CREATE TABLE IF NOT EXISTS Genres (
    genre_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    description TEXT NOT NULL
);

-- Таблиця Artists
CREATE TABLE IF NOT EXISTS Artists (
    artist_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    date_of_birth INT NOT NULL,
    date_of_death INT,
    place_of_birth TEXT NOT NULL,
    movement_id INT,
    genre_id INT,
    bio TEXT NOT NULL,
    FOREIGN KEY (movement_id) REFERENCES ArtMovements(movement_id),
    FOREIGN KEY (genre_id) REFERENCES Genres(genre_id)
);

-- Таблиця Paintings
CREATE TABLE IF NOT EXISTS Paintings (
    painting_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    artist_id INT NOT NULL,
    style_id INT,
    genre_id INT,
    year INT,
    description TEXT,
    FOREIGN KEY (artist_id) REFERENCES Artists(artist_id),
    FOREIGN KEY (style_id) REFERENCES ArtMovements(movement_id),
    FOREIGN KEY (genre_id) REFERENCES Genres(genre_id)
);

-- Таблиця Favorites
CREATE TABLE IF NOT EXISTS Favorites (
    user_id INT NOT NULL,
    painting_id INT NOT NULL,
    added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    PRIMARY KEY (user_id, painting_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (painting_id) REFERENCES Paintings(painting_id)
);

-- Таблиця Tests
CREATE TABLE IF NOT EXISTS Tests (
    test_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    difficulty INT DEFAULT 1,
    artist_id INT,
    FOREIGN KEY (artist_id) REFERENCES Artists(artist_id)
);

-- Таблиця Questions
CREATE TABLE IF NOT EXISTS Questions (
    question_id INT AUTO_INCREMENT PRIMARY KEY,
    test_id INT NOT NULL,
    question_text TEXT NOT NULL,
    FOREIGN KEY (test_id) REFERENCES Tests(test_id)
);

-- Таблиця Answers
CREATE TABLE IF NOT EXISTS Answers (
    answer_id INT AUTO_INCREMENT PRIMARY KEY,
    question_id INT NOT NULL,
    answer_text VARCHAR(255) NOT NULL,
    is_correct TINYINT DEFAULT 0,
    FOREIGN KEY (question_id) REFERENCES Questions(question_id)
);

-- Таблиця UserTestResults
CREATE TABLE IF NOT EXISTS UserTestResults (
    result_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    test_id INT NOT NULL,
    score INT NOT NULL,
    completion_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (test_id) REFERENCES Tests(test_id)
);
