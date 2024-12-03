USE Polotno;

INSERT INTO users (username, email, password_hash) VALUES
('Oleg', 'oleg@example.com', 'hash11'),
('Anna', 'anna@example.com', 'hash12'),
('Petro', 'petro@example.com', 'hash13'),
('Iryna', 'iryna@example.com', 'hash14'),
('Yulia', 'yulia@example.com', 'hash15'),
('Viktor', 'viktor@example.com', 'hash16'),
('Natalia', 'natalia@example.com', 'hash17'),
('Andriy', 'andriy@example.com', 'hash18'),
('Dmytro', 'dmytro@example.com', 'hash19'),
('Olena', 'olena@example.com', 'hash20');


INSERT INTO art_movement (movement_name, movement_description) VALUES
('Бароко', 'Стиль з акцентом на пишність і динамічність.'),
('Класицизм', 'Раціональний і гармонійний стиль.'),
('Романтизм', 'Фокус на емоції і природу.'),
('Модерн', 'Поєднання традиційного і нового.'),
('Супрематизм', 'Абстрактний стиль Малевича.'),
('Імпресіонізм', 'Показ миттєвих вражень.'),
('Експресіонізм', 'Емоційна і символічна манера.'),
('Реалізм', 'Відтворення повсякденного життя.'),
('Футуризм', 'Технології та динаміка майбутнього.'),
('Сюрреалізм', 'Сни та фантазії.');


INSERT INTO genre (genre_name, genre_description) VALUES
('Іконопис', 'Релігійні сюжети.'),
('Портрет', 'Зображення людей.'),
('Пейзаж', 'Природа і краєвиди.'),
('Натюрморт', 'Предмети побуту.'),
('Історичний', 'Сцени з історії.'),
('Релігійний', 'Релігійні теми.'),
('Анімалістичний', 'Зображення тварин.'),
('Абстрактний', 'Необ’єктивне мистецтво.'),
('Фантастичний', 'Міфи і фантазії.'),
('Генр-живопис', 'Повсякденне життя.');


INSERT INTO artist (artist_name, date_of_birth, date_of_death, place_of_birth, movement_id, genre_id, bio) VALUES
('Тарас Шевченко', 1814, 1861, 'Моринці, Україна', 1, 2, 'Видатний український художник і поет.'),
('Марія Примаченко', 1908, 1997, 'Болотня, Україна', 6, 7, 'Майстриня народного мистецтва.'),
('Казимир Малевич', 1879, 1935, 'Київ, Україна', 5, 8, 'Автор "Чорного квадрата".'),
('Михайло Бойчук', 1882, 1937, 'Романівка, Україна', 4, 1, 'Піонер монументального живопису.'),
('Іван Марчук', 1936, NULL, 'Малеве, Україна', 7, 3, 'Сучасний український імпресіоніст.'),
('Олександр Архипенко', 1887, 1964, 'Київ, Україна', 9, 8, 'Піонер кубізму в скульптурі.'),
('Василь Кричевський', 1873, 1952, 'Ворожба, Україна', 1, 9, 'Митець, що створив герб України.'),
('Ілля Рєпін', 1844, 1930, 'Чугуїв, Україна', 4, 2, 'Один із найвідоміших реалістів.'),
('Микола Пимоненко', 1862, 1912, 'Київщина, Україна', 4, 3, 'Малював українські пейзажі.'),
('Олександра Екстер', 1882, 1949, 'Білосток, Україна', 9, 8, 'Футурист і авангардист.');


INSERT INTO painting (painting_name, artist_id, style_id, genre_id, year_created, painting_description) VALUES
('Катерина', 1, 1, 2, 1842, 'Відомий портрет української жінки.'),
('Соняхи', 2, 6, 7, 1975, 'Робота Примаченко з фантастичними елементами.'),
('Чорний квадрат', 3, 5, 8, 1915, 'Знаковий твір супрематизму.'),
('Дівчина з Поділля', 4, 4, 1, 1910, 'Картина у стилі модерн.'),
('Золота осінь', 5, 6, 3, 1990, 'Пейзаж Марчука.'),
('Танок', 6, 9, 8, 1914, 'Авангардна скульптурна робота.'),
('Вечорниці', 7, 1, 9, 1900, 'Картина з побутовими сценами.'),
('Запорожці пишуть листа', 8, 4, 2, 1891, 'Історична робота Рєпіна.'),
('Біля річки', 9, 4, 3, 1908, 'Мотиви української природи.'),
('Букет квітів', 10, 9, 7, 1920, 'Натюрморт з елементами кубізму.');


INSERT INTO favorite (user_id, painting_id) VALUES
(1, 1), (1, 2), (2, 3), (2, 4), (3, 5), (3, 6), (4, 7), (4, 8), (5, 9), (5, 10);

INSERT INTO test (test_name, difficulty, artist_id) VALUES
('Тест про Шевченка', 1, 1),
('Тест про Малевича', 2, 3),
('Тест про Примаченко', 2, 2),
('Тест про Рєпіна', 1, 8),
('Тест про Архипенка', 3, 6),
('Тест про Марчука', 2, 5),
('Тест про Кричевського', 1, 7),
('Тест про Пимоненка', 1, 9),
('Тест про Екстер', 3, 10),
('Загальний тест про українських митців', 3, NULL);

