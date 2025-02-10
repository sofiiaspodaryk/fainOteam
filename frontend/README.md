1) структура файлів проєкту

src/ – основна папка, що містить файли додатка:
components/ – містить спільні компоненти:
pages/ – містить окремі сторінки:
App.js – головний файл маршрутизації між сторінками.
index.js – точка входу до додатка.

2) налаштування 
node -v
npm -v

cd frontend (в ній працюємо і запускаємо)

npm install react-scripts --save
npm install @mui/material @emotion/react @emotion/styled
npm install formik formik-mui @mui/icons-material
npm install yup --save

// в файлі .gitignore напишіть: "node_modules/" та ігноруйте цю папку 

npm install

3) запуск
npm start