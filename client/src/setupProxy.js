const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {
  app.use(
    '/api', // Lub dowolny inny prefiks, który chcesz używać do API
    createProxyMiddleware({
      target: 'http://localhost:5231', // Adres i port Twojego API
      changeOrigin: true,
    })
  );
};