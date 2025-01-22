import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Header from "./components/Header";
import Footer from "./components/Footer";
import HomePage from "./pages/HomePage";
import ArtistsPage from "./pages/ArtistsPage";
import PaintingsPage from "./pages/PaintingsPage";
import StylesPage from "./pages/StylesPage";
import GenresPage from "./pages/GenresPage";
import CollectionsPage from "./pages/CollectionsPage";
import ProfilePage from "./pages/ProfilePage";

function App() {
  return (
    <Router>
      <Header />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/artists" element={<ArtistsPage />} />
        <Route path="/paintings" element={<PaintingsPage />} />
        <Route path="/styles" element={<StylesPage />} />
        <Route path="/genres" element={<GenresPage />} />
        <Route path="/collections" element={<CollectionsPage />} />
        <Route path="/profile" element={<ProfilePage />} />
      </Routes>
      <Footer />
    </Router>
  );
}

export default App;
