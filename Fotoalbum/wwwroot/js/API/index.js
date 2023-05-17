const url = "https://localhost:7069/";
const urlApiGetPhotos = "api/HomePhoto/GetPhotos";
const urlApiGetPhoto = "api/HomePhoto/GetPhoto";
const noPhotoDiv = document.getElementById("no_photos");
const photoListDiv = document.getElementById("photo_list");
const loader = document.getElementById("loader");

const sendMsgButton = document.getElementById("sendMsg");

getAllPhotos();

async function getAllPhotos(input) {
    try {
        loader.classList.remove("d-none");
        const response = await axios.get(`${url}${urlApiGetPhotos}`, {
            params: {
                filter: input,
            }
        });

        const photos = response.data;
        if (photos.length == 0) {
            loader.classList.add("d-none");
            noPhotoDiv.classList.remove("d-none");
            photoListDiv.classList.add("d-none");

        } else {
            loader.classList.add("d-none");
            noPhotoDiv.classList.add("d-none");
            photoListDiv.classList.remove("d-none");

            photoListDiv.innerHTML = "";
            photos.forEach(photo => {
                photoListDiv.innerHTML += `
                    <div class="col-md-4 mb-3">
                        <div class="card h-100 photo_card">
                            <img class="card-img-top photo_img" src="${photo.imageBase64}" alt="${photo.title}">
                            <div class="card-body d-flex flex-column justify-content-between">
                                <h5 class="card-title">${photo.title}</h5>
                                <p class="card-text lead">${photo.description}</p>
                                <div class="photo_categories">
                                    ${photo.categories.map(category => `
                                        <span class="badge bg-success">${category.name}</span>
                                    `).join('')}
                                </div>
                            </div>
                        </div>
                    </div>
                    `
            });
        }
    }
    catch (err) {
        console.log(err);
    };
}

sendMsgButton.addEventListener("click", () => {
    const email = document.getElementById("msgEmail");
    const text = document.getElementById("msgText");
    console.log(email.value, text.value);
    
});