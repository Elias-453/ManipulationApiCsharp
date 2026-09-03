const http_C = "http://localhost:5112";
//juste pour les image des films pour le site c juste du design
const ApiOMBD =`30f432f1`;

let BarreRecherche = document.getElementById("barrerecherche");
let resultatFilm =document.getElementById("resultat")

async function RecuperationApi(texterecherche){

const api = await fetch(`${http_C}/Film/Recherche?titre=${texterecherche}`);
const data = await api.json();
return data;
};

async function ListenBarreRecherche (){

document.getElementById("barrerecherche").addEventListener("input", async ()=>{

let valeur = document.getElementById("barrerecherche").value;
const input = await RecuperationApi(valeur);

const contenaire = document.getElementById("resultat");

contenaire.innerHTML =``;


input.forEach(async (Film) => {
    const carte = document.createElement("div");
    carte.className = "carte-film";

    // On utilise OMDb juste pour choper l'image 
    const OMDbimage = await fetch(`https://www.omdbapi.com/?t=${encodeURIComponent(Film.titre)}&apikey=${ApiOMBD}`);
    const dataO = await OMDbimage.json();
    const urlImage = dataO.Poster !== "N/A" ? dataO.Poster : "";


    carte.innerHTML = `
        <img src="${urlImage}" alt="Affiche" width="100" />
        <h1> Titre : ${Film.titre} </h1>
        <h2> Realisateur : ${Film.realisateur}</h2>
        <h2>Date de Sortie : ${Film.sortie}</h2>
    `;
    contenaire.appendChild(carte);
});

});

}



ListenBarreRecherche ()

