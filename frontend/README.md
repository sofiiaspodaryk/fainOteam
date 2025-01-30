1) структура файлів проєкту

src/ – основна папка, що містить файли додатка:
components/ – містить спільні компоненти:
pages/ – містить окремі сторінки:
App.js – головний файл маршрутизації між сторінками.
index.js – точка входу до додатка.

2) налаштування 
node -v
npm -v

cd frontend

npm install

npm start - команда для запуску проекту в папці frontend

якщо виникає проблема: 
1) cd frontend
2) npm install react-scripts --save
3) в файлі .gitignore напишіть: "node_modules/" та ігноруйте цю папку 
3) npm install