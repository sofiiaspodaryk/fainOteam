import React from "react";
import { Link } from "react-router-dom";

function Header() {
  return (
    <header>
      <nav>
        <Link to="/">Головна</Link>
        <Link to="/artists">Художники</Link>
        <Link to="/paintings">Картини</Link>
        <Link to="/styles">Стилі</Link>
        <Link to="/genres">Жанри</Link>
        <Link to="/collections">Колекції</Link>
        <Link to="/profile">Особистий кабінет</Link>
      </nav>
    </header>
  );
}

export default Header;
