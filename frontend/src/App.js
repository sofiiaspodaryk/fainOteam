import React from 'react';
import { BrowserRouter as Router, Route, Routes, useLocation } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import HomePage from './pages/home/HomePage';
import PaintingPage from './pages/painting/PaintingPage';
import SignUpPage from './pages/SignUpPage';
import LogInPage from './pages/LogInPage';

function Layout() {
  const location = useLocation();
  const hideHeaderFooter = location.pathname === "/signup" || location.pathname === "/login";

  return (
    <>
      {!hideHeaderFooter && <Header />}
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/painting" element={<PaintingPage />} />
        <Route path="/signup" element={<SignUpPage />} />
        <Route path="/login" element={<LogInPage />} />
      </Routes>
      {!hideHeaderFooter && <Footer />}
    </>
  );
}

function App() {
  return (
    <Router>
      <Layout />
    </Router>
  );
}

export default App;
