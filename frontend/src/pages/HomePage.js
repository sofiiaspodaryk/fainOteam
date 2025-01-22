import React from "react";
import SearchBar from "../components/SearchBar";

function HomePage() {
  return (
    <div>
      <SearchBar />
      <section>
        <h1>Картина дня</h1>
        <p>Ілюстрація до "Світова Королева" – Владислав Єрко</p>
      </section>
      <section>
        <h2>Рекомендуємо для вас</h2>
        <div>
          <img src="/path/to/recommended1.jpg" alt="Recommendation 1" />
          <img src="/path/to/recommended2.jpg" alt="Recommendation 2" />
          <img src="/path/to/recommended3.jpg" alt="Recommendation 3" />
        </div>
      </section>
    </div>
  );
}

export default HomePage;
