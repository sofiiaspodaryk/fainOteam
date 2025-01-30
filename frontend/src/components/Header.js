import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './Header.css';

const Header = () => {
  const [isEducationOpen, setEducationOpen] = useState(false);
  const [isCatalogOpen, setCatalogOpen] = useState(false);
  const [isCollectionsOpen, setCollectionsOpen] = useState(false);

  const toggleEducation = () => setEducationOpen(!isEducationOpen);
  const toggleCatalog = () => setCatalogOpen(!isCatalogOpen);
  const toggleCollections = () => setCollectionsOpen(!isCollectionsOpen);

  return (
    <header className="header">
      <div className="header-left">
        <Link to="/" className="logo">
          POLOTNO
        </Link>
      </div>

      <div className="header-center">
        <input type="text" placeholder="Пошук..." className="search-bar" />
      </div>

      <div className="header-right">
        <nav className="nav">
          <div className="nav-item" onMouseEnter={toggleEducation} onMouseLeave={toggleEducation}>
            <span>Освіта</span>
            {isEducationOpen && (
              <div className="dropdown">
                <Link to="/tests" className="dropdown-item">
                  Тести
                </Link>
                <Link to="/coloring" className="dropdown-item">
                  Розмальовки
                </Link>
              </div>
            )}
          </div>

          <div className="nav-item" onMouseEnter={toggleCatalog} onMouseLeave={toggleCatalog}>
            <span>Каталоги</span>
            {isCatalogOpen && (
              <div className="dropdown">
                <Link to="/artists" className="dropdown-item">
                  Художники
                </Link>
                <Link to="/paintings" className="dropdown-item">
                  Картини
                </Link>
                <Link to="/styles" className="dropdown-item">
                  Стилі
                </Link>
                <Link to="/genres" className="dropdown-item">
                  Жанри
                </Link>
              </div>
            )}
          </div>

          <div className="nav-item" onMouseEnter={toggleCollections} onMouseLeave={toggleCollections}>
            <span>Колекції</span>
            {isCollectionsOpen && (
              <div className="dropdown">
                <Link to="/top-paintings" className="dropdown-item">
                  Топ 10 картин
                </Link>
                <Link to="/my-collections" className="dropdown-item">
                  Мої колекції
                </Link>
              </div>
            )}
          </div>

          {/* Вкладка "Про нас" */}
          <div className="nav-item">
            <Link to="/about" className="nav-link">
              Про нас
            </Link>
          </div>

          {/* Вкладка "Особистий кабінет" */}
          <div className="nav-item">
            <Link to="/profile" className="nav-link">
              Особистий кабінет
            </Link>
          </div>
        </nav>
      </div>
    </header>
  );
};

export default Header;