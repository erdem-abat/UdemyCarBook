import "./styles.css"

const map = L.map("map").setView([51.505, -0.09], 13);
L.tileLayer("https://tile.openstreetmap.org/{z}/{x}/{y}", {
    maxZoom: 19,
    attribution: '&copy;'})