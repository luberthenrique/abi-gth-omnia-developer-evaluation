const { env } = require('process');

console.log('proxy', env.ASPNETCORE_HTTPS_PORT)
if (env.ASPNETCORE_HTTPS_PORTS) {
  target = `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`;
}
else if (env.ASPNETCORE_URLS) {
  target = env.ASPNETCORE_URLS.split(';')[0];
}
else {
  target = 'https://localhost:8081';
}

const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: target,
    secure: false,
    logLevel: "debug",
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
