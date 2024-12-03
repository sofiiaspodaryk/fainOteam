use polotno;

show tables;

select * from painting;


create index idx_artist_first_name ON artist(first_name);
create index idx_artist_last_name ON artist(last_name);
create index idx_genre_name ON genre(genre_name);
create index idx_movement_name ON art_movement(movement_name);


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
