CREATE DATABASE IF NOT EXISTS Polotno;
USE Polotno;


CREATE TABLE IF NOT EXISTS users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL
);


CREATE TABLE IF NOT EXISTS art_movement (
    movement_id INT AUTO_INCREMENT PRIMARY KEY,
    movement_name VARCHAR(50) NOT NULL UNIQUE,
    movement_description TEXT NOT NULL
);


CREATE TABLE IF NOT EXISTS genre (
    genre_id INT AUTO_INCREMENT PRIMARY KEY,
    genre_name VARCHAR(50) NOT NULL UNIQUE,
    genre_description TEXT NOT NULL
);


CREATE TABLE IF NOT EXISTS artist (
    artist_id INT AUTO_INCREMENT PRIMARY KEY,
    artist_name VARCHAR(100) NOT NULL,
    date_of_birth INT NOT NULL,
    date_of_death INT,
    place_of_birth TEXT NOT NULL,
    movement_id INT,
    genre_id INT,
    bio TEXT NOT NULL,
    FOREIGN KEY (movement_id) REFERENCES art_movement(movement_id),
    FOREIGN KEY (genre_id) REFERENCES genre(genre_id)
);


CREATE TABLE IF NOT EXISTS painting (
    painting_id INT AUTO_INCREMENT PRIMARY KEY,
    painting_name VARCHAR(100) NOT NULL,
    artist_id INT NOT NULL,
    style_id INT,
    genre_id INT,
    year_created INT,
    painting_description TEXT,
    FOREIGN KEY (artist_id) REFERENCES artist(artist_id),
    FOREIGN KEY (style_id) REFERENCES art_movement(movement_id),
    FOREIGN KEY (genre_id) REFERENCES genre(genre_id)
);


CREATE TABLE IF NOT EXISTS favorite (
    user_id INT NOT NULL,
    painting_id INT NOT NULL,
    added_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    PRIMARY KEY (user_id, painting_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (painting_id) REFERENCES painting(painting_id)
);


CREATE TABLE IF NOT EXISTS test (
    test_id INT AUTO_INCREMENT PRIMARY KEY,
    test_name VARCHAR(100) NOT NULL,
    difficulty INT DEFAULT 1,
    artist_id INT,
    FOREIGN KEY (artist_id) REFERENCES artist(artist_id)
);


CREATE TABLE IF NOT EXISTS question (
    question_id INT AUTO_INCREMENT PRIMARY KEY,
    test_id INT NOT NULL,
    question_text TEXT NOT NULL,
    FOREIGN KEY (test_id) REFERENCES test(test_id)
);


CREATE TABLE IF NOT EXISTS answer (
    answer_id INT AUTO_INCREMENT PRIMARY KEY,
    question_id INT NOT NULL,
    answer_text VARCHAR(255) NOT NULL,
    is_correct TINYINT DEFAULT 0,
    FOREIGN KEY (question_id) REFERENCES question(question_id)
);


CREATE TABLE IF NOT EXISTS user_test_result (
    result_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    test_id INT NOT NULL,
    score INT NOT NULL,
    completion_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (test_id) REFERENCES test(test_id)
);

