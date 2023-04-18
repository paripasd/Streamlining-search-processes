/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./public/**/*.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  theme: {
    extend: {
      colors: {
        'cyorange': '#f28033',
        'customgray': '#F6F6F7',
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
  ],
}
