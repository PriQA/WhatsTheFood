const PROXY_CONFIG = [
  {
    context: [
      "/food", "/home"
    ],
    target: "https://localhost:5001",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
