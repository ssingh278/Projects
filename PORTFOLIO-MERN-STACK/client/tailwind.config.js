/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{js,jsx,ts,tsx}",
  ],
  theme: {
    extend: {
      colors:{
        "primary":"#20474f",
        "secondary":"#c7b3cc",
        "tertiary":"#95ecb0"
      }
    },
  },
  plugins: [],
}