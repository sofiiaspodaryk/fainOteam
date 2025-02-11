import React from 'react';
import './Footer.css';

const Footer = () => {
  return (
    <footer className="footer">
      <div className="footer-left">
        <div className="logo-container">
          <img src="/logo.png" alt="POLOTNO" className="logo" />
          <span className="logo-text">OLOTNO</span>
        </div>
      </div>

      <div className="footer-center">
        <p className="phone">+38 (012) 345-67-89</p>
      </div>

      <div className="footer-right">
        <div className="social-links">
          <a href="https://facebook.com" target="_blank" rel="noopener noreferrer">
            <img src="/facebook.png" alt="Facebook" className="social-icon" />
          </a>
          <a href="https://instagram.com" target="_blank" rel="noopener noreferrer">
            <img src="/instagram.png" alt="Instagram" className="social-icon" />
          </a>
        </div>
      </div>
    </footer>
  );
};

export default Footer;