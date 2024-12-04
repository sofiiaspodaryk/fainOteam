use polotno;

show tables;

select * from painting;


create index idx_artist_first_name ON artist(first_name);
create index idx_artist_last_name ON artist(last_name);
create index idx_genre_name ON genre(genre_name);
create index idx_movement_name ON art_movement(movement_name);

DELIMITER //

CREATE TRIGGER validate_year_created
BEFORE INSERT ON painting
FOR EACH ROW
BEGIN
    IF NEW.year_created <= 1000 OR NEW.year_created > YEAR(CURDATE()) THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Invalid year of painting creation: must be between 1001 and the current year.';
    END IF;
END;
//

DELIMITER ;


DELIMITER $$

create procedure get_painting_details_by_id(IN p_painting_id INT)
BEGIN
    SELECT 
        p.painting_name AS PaintingName,
        a.first_name AS ArtistFirstName,
        a.last_name AS ArtistLastName,
        am.movement_name AS Style,
        g.genre_name AS Genre,
        p.year_created AS YearCreated,
        p.painting_description AS Description
    FROM 
        painting p
    LEFT JOIN artist a ON p.artist_id = a.artist_id
    LEFT JOIN art_movement am ON p.style_id = am.movement_id
    LEFT JOIN genre g ON p.genre_id = g.genre_id
    WHERE 
        p.painting_id = p_painting_id;
END $$

DELIMITER ;

call get_painting_details_by_id(1);

 

DELIMITER $$

CREATE PROCEDURE get_artist_details_by_id(IN p_artist_id INT)
BEGIN
    SELECT 
        a.first_name AS ArtistFirstName,
        a.last_name AS ArtistLastName,
        a.date_of_birth AS DateOfBirth,
        a.date_of_death AS DateOfDeath,
        a.place_of_birth AS PlaceOfBirth,
        a.bio AS Biography,
        am.movement_name AS ArtMovement,
        g.genre_name AS MainGenre
    FROM 
        artist a
    LEFT JOIN art_movement am ON a.movement_id = am.movement_id
    LEFT JOIN genre g ON a.genre_id = g.genre_id
    WHERE 
        a.artist_id = p_artist_id;
END $$

DELIMITER ;

call get_artist_details_by_id(1);


DELIMITER $$

CREATE PROCEDURE get_user_favorites_procedure(IN user_id INT)
BEGIN
    SELECT 
        p.painting_id, 
        p.painting_name, 
        CONCAT(a.first_name, ' ', a.last_name) AS artist_name, 
        p.year_created, 
        p.painting_description
    FROM 
        favorite f
    JOIN 
        painting p ON f.painting_id = p.painting_id
    JOIN 
        artist a ON p.artist_id = a.artist_id
    WHERE 
        f.user_id = user_id;
END$$

DELIMITER ;


CALL get_user_favorites_procedure(1); 

DELIMITER $$

CREATE FUNCTION get_painting_count(artistId INT)
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE painting_count INT;
    SELECT COUNT(*) INTO painting_count
    FROM painting
    WHERE artist_id = artistId;
    RETURN painting_count;
END$$

DELIMITER ;

SELECT get_painting_count(1) AS painting_count;

DELIMITER $$

CREATE FUNCTION get_average_test_score(userId INT)
RETURNS FLOAT
DETERMINISTIC
BEGIN
    DECLARE average_score FLOAT;
    SELECT AVG(score) INTO average_score
    FROM user_test_result
    WHERE user_id = userId;
    RETURN IFNULL(average_score, 0);
END$$

DELIMITER ;

SELECT get_average_test_score(2) AS average_score;

DELIMITER $$

CREATE PROCEDURE transfer_user_test_results(
    IN oldUserId INT,
    IN newUserId INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
    END;

    START TRANSACTION;

    IF (SELECT COUNT(*) FROM users WHERE user_id = newUserId) = 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Target user does not exist.';
    END IF;

    UPDATE user_test_result
    SET user_id = newUserId
    WHERE user_id = oldUserId;

    COMMIT;
END$$

DELIMITER ;

CALL transfer_user_test_results(1, 3);

