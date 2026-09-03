const http_C = "http://localhost:5112";
const ApiRAWG = "f38eff5c647d4ae986221a0053d3539a"; 

let BarreRecherche = document.getElementById("barrerecherche");
let resultatJeu = document.getElementById("resultat");

async function RecuperationApi(texte){
    const api = await fetch(`${http_C}/Jeux`);
    const data = await api.json();
    
    if(!texte) return data;
    
    return data.filter(j => j.titre.toLowerCase().includes(texte.toLowerCase()) || j.genre.toLowerCase().includes(texte.toLowerCase()));
}

async function ListenBarreRecherche (){
    const premier = await RecuperationApi();
    
    resultatJeu.innerHTML = ``;
    for (const Jeu of premier) {
        let urlImage = "";
        try {
            const rawg = await fetch(`https://api.rawg.io/api/games?search=${encodeURIComponent(Jeu.titre)}&key=${ApiRAWG}`);
            const dataR = await rawg.json();
            
            if(dataR.results && dataR.results.length > 0) {
                urlImage = dataR.results[0].background_image;
            }
        } catch (e) {}

        const carte = document.createElement("div");
        carte.className = "carte-film";

        if (urlImage) {
            const img = document.createElement("img");
            img.src = urlImage;
            img.className = "img-jeu";
            carte.appendChild(img);
        }

        carte.innerHTML += `
            <h1> Titre : ${Jeu.titre} </h1>
            <h2> Genre : ${Jeu.genre}</h2>
            <h2>Date de Sortie : ${Jeu.datePublication}</h2>
           
        `;
        resultatJeu.appendChild(carte);
    }

    BarreRecherche.addEventListener("input", async ()=>{
        let valeur = BarreRecherche.value;
        const input = await RecuperationApi(valeur);

        resultatJeu.innerHTML = ``;

        for (const Jeu of input) {
            let urlImage = "";
            try {
                const rawg = await fetch(`https://api.rawg.io/api/games?search=${encodeURIComponent(Jeu.titre)}&key=${ApiRAWG}`);
                const dataR = await rawg.json();
                if(dataR.results && dataR.results.length > 0) {
                    urlImage = dataR.results[0].background_image;
                }
            } catch (e) {}

            const carte = document.createElement("div");
            carte.className = "carte-film";

            if (urlImage) {
                const img = document.createElement("img");
                img.src = urlImage;
                img.className = "img-jeu";
                carte.appendChild(img);
            }

            carte.innerHTML += `
                <h1> Titre : ${Jeu.titre} </h1>
                <h2> Genre : ${Jeu.genre}</h2>
                <h2>Date de Sortie : ${Jeu.datePublication}</h2>
               
            `;
            resultatJeu.appendChild(carte);
        }
    });
}

ListenBarreRecherche();