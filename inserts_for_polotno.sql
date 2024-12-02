USE Polotno;

-- Додавання записів у таблицю Users
INSERT INTO users (username, email, password_hash) VALUES
('JohnDoe', 'john.doe@example.com', 'hash1'),
('JaneSmith', 'jane.smith@example.com', 'hash2'),
('Alice', 'alice@example.com', 'hash3'),
('Bob', 'bob@example.com', 'hash4'),
('Charlie', 'charlie@example.com', 'hash5'),
('David', 'david@example.com', 'hash6'),
('Eve', 'eve@example.com', 'hash7'),
('Frank', 'frank@example.com', 'hash8'),
('Grace', 'grace@example.com', 'hash9'),
('Hank', 'hank@example.com', 'hash10');

-- Додавання записів у таблицю ArtMovements
INSERT INTO art_movement (name, description) VALUES
('Impressionism', 'Focus on light and color.'),
('Expressionism', 'Emphasis on emotion and meaning.'),
('Cubism', 'Abstract forms and geometric shapes.'),
('Baroque', 'Dramatic use of light and shadow.'),
('Renaissance', 'Rebirth of classical learning and art.'),
('Romanticism', 'Focus on emotion and nature.'),
('Surrealism', 'Dream-like scenes and symbolic images.'),
('Realism', 'Representation of everyday life.'),
('Futurism', 'Emphasis on technology and modernity.'),
('Abstract', 'Non-representational and expressive.');

-- Додавання записів у таблицю Genres
INSERT INTO genre (name, description) VALUES
('Portrait', 'Focus on individual subjects.'),
('Landscape', 'Depiction of nature and outdoors.'),
('Still Life', 'Arrangement of inanimate objects.'),
('Historical', 'Scenes from history.'),
('Religious', 'Religious themes and figures.'),
('Abstract', 'Non-representational.'),
('Genre Painting', 'Scenes of everyday life.'),
('Animal', 'Depiction of animals.'),
('Marine', 'Scenes of the sea.'),
('Fantasy', 'Imaginary and mythical subjects.');

-- Додавання записів у таблицю Artists
INSERT INTO artist (name, date_of_birth, date_of_death, place_of_birth, movement_id, genre_id, bio) VALUES
('Claude Monet', 1840, 1926, 'Paris, France', 1, 2, 'Father of Impressionism.'),
('Vincent van Gogh', 1853, 1890, 'Zundert, Netherlands', 2, 4, 'Known for expressive brushwork.'),
('Pablo Picasso', 1881, 1973, 'Málaga, Spain', 3, 6, 'Co-founder of Cubism.'),
('Caravaggio', 1571, 1610, 'Milan, Italy', 4, 5, 'Master of Baroque light and shadow.'),
('Leonardo da Vinci', 1452, 1519, 'Vinci, Italy', 5, 5, 'Renaissance polymath.'),
('Eugène Delacroix', 1798, 1863, 'Charenton, France', 6, 5, 'Leader of Romanticism.'),
('Salvador Dalí', 1904, 1989, 'Figueres, Spain', 7, 10, 'Known for Surrealist works.'),
('Diego Velázquez', 1599, 1660, 'Seville, Spain', 8, 1, 'Spanish Golden Age painter.'),
('J. M. W. Turner', 1775, 1851, 'London, England', 9, 2, 'Master of atmospheric effects.'),
('Wassily Kandinsky', 1866, 1944, 'Moscow, Russia', 10, 6, 'Pioneer of Abstract Art.');

-- Додавання записів у таблицю Paintings
INSERT INTO painting (name, artist_id, style_id, genre_id, year, description) VALUES
('Water Lilies', 1, 1, 2, 1906, 'Series of Monet’s paintings.'),
('Starry Night', 2, 2, 4, 1889, 'One of van Gogh’s most famous works.'),
('Les Demoiselles d\'Avignon', 3, 3, 6, 1907, 'Picasso’s revolutionary work.'),
('The Calling of Saint Matthew', 4, 4, 5, 1600, 'Caravaggio’s masterpiece.'),
('Mona Lisa', 5, 5, 5, 1503, 'Leonardo da Vinci’s iconic painting.'),
('Liberty Leading the People', 6, 6, 5, 1830, 'Symbol of French Revolution.'),
('The Persistence of Memory', 7, 7, 10, 1931, 'Famous for melting clocks.'),
('Las Meninas', 8, 8, 1, 1656, 'Velázquez’s masterpiece.'),
('The Fighting Temeraire', 9, 9, 2, 1839, 'Celebration of industrialization.'),
('Composition VIII', 10, 10, 6, 1923, 'Kandinsky’s abstract masterpiece.');

-- Додавання записів у таблицю Favorites
INSERT INTO favorite (user_id, painting_id) VALUES
(1, 1), (1, 2), (2, 3), (2, 4), (3, 5), (3, 6), (4, 7), (4, 8), (5, 9), (5, 10);

-- Додавання інших записів за потреби...
