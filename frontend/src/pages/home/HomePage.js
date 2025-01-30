import React from 'react';
import { Link } from 'react-router-dom';
import './HomePage.css';

const HomePage = () => {
  const paintingOfTheDay = {
    title: "Катерина",
    artist: "Тарас Шевченко",
    year: "1852",
    style: "Романтизм",
    genre: "Літературний живопис",
    fact: "На картині Шевченка «Катерина» є маленький собачка, який ніби намагається наздогнати москаля. Деякі мистецтвознавці вважають, що це символ ганьби, адже навіть пес проводить його гавкотом, тоді як сам москаль не озирається і швидко тікає.",
    image: "/Катерина.png"
  };

  // Приклад даних для рекомендованих зображень
  const recommendedPaintings = [
    { id: 1, title: "Український поліський бичок-третячок гуляє у лісі та силу збирає", image: "/бичок.jpeg" },
    { id: 2, title: "Спортсмени", image: "/спортсмени.jpg" },
    { id: 3, title: "Богданівські яблука", image: "/богданівські_яблука.jpg" },
    { id: 4, title: "Бокораші", image: "/бокораші.jpg" },
  ];

  const [currentIndex, setCurrentIndex] = React.useState(0);

  const nextSlide = () => {
    setCurrentIndex((prevIndex) => (prevIndex + 1) % recommendedPaintings.length);
  };

  const prevSlide = () => {
    setCurrentIndex((prevIndex) => 
      prevIndex === 0 ? recommendedPaintings.length - 1 : prevIndex - 1
    );
  };

  return (
    <div className="home-page">

      {/* Секція "Картина дня" */}
      <section className="painting-of-the-day">
        <h2>Картина дня</h2>
        <div className="painting-details">
          <img src={paintingOfTheDay.image} alt={paintingOfTheDay.title} />
          <div className="painting-info">
            <h3>{paintingOfTheDay.title}</h3>
            <p><strong>Художник:</strong> {paintingOfTheDay.artist}</p>
            <p><strong>Рік:</strong> {paintingOfTheDay.year}</p>
            <p><strong>Стиль:</strong> {paintingOfTheDay.style}</p>
            <p><strong>Жанр:</strong> {paintingOfTheDay.genre}</p>
            <p><strong>Цікавий факт:</strong> {paintingOfTheDay.fact}</p>
          </div>
        </div>
        <Link to="/painting-details" className="more-link">Дізнатися більше →</Link>
      </section>

      {/* Секція "Рекомендоване" з каруселлю */}
      <section className="recommended-paintings">
        <h2>Рекомендоване для Вас</h2>
        <div className="carousel">
          <button className="carousel-button prev" onClick={prevSlide}>‹</button>
          <div className="carousel-content">
            {recommendedPaintings.map((painting, index) => (
              <div
                key={painting.id}
                className={`carousel-item ${index === currentIndex ? 'active' : ''}`}
              >
                <img src={painting.image} alt={painting.title} />
                <p>{painting.title}</p>
              </div>
            ))}
          </div>
          <button className="carousel-button next" onClick={nextSlide}>›</button>
        </div>
      </section>

      
    </div>
  );
};

export default HomePage;