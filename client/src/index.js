import React from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.min.css'; // Zaimportuj Bootstrap CSS
import App from './App'; // Zaimportuj główny komponent aplikacji
import { BrowserRouter } from 'react-router-dom';



ReactDOM.render(
  <React.StrictMode>
      <BrowserRouter>
        <App />
      </BrowserRouter>

  </React.StrictMode>,
  document.getElementById('root') // Znajdź element z id 'root' w pliku HTML
);
