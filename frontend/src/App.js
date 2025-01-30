import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import HomePage from './pages/home/HomePage'; // Правильний імпорт
import ArtistsPage from './pages/artist/ArtistPage';
import PaintingsPage from './pages/painting/PaintingPage';
import StylesPage from './pages/style/StylePage';
import GenresPage from './pages/genre/GenrePage';
import CollectionsPage from './pages/profile/CollectionPage';
import ProfilePage from './pages/profile/ProfilePage';

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