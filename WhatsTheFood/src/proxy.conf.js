const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast", "/home"
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
