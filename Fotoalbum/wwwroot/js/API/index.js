// api
const url = "https://localhost:7069/";
const urlApiGetPhotos = "api/HomePhoto/GetPhotos";
const urlApiGetPhoto = "api/HomePhoto/GetPhoto";
const urlApiSendMessage = "api/HomeMessage/SendMessage";

// html nodes
const noPhotoDiv = document.getElementById("no_photos");
const photoListDiv = document.getElementById("photo_list");
const loader = document.getElementById("loader");

// post api
const sendMsgButton = document.getElementById("sendMsg");
let emailErrorDiv = document.getElementById("emailError");
let textErrorDiv = document.getElementById("textError");

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
    let email = document.getElementById("msgEmail");
    let text = document.getElementById("msgText");

    axios.post(`${url}${urlApiSendMessage}`, {
        Email: email.value,
        TextMessage: text.value
    })
        .then(resp => {
            email.value = '';
            text.value = '';
            emailErrorDiv.innerHTML = '';
            textErrorDiv.innerHTML = '';
        })
        .catch(err => {
            console.log(err)
            emailErrorDiv.innerHTML = '';
            textErrorDiv.innerHTML = '';
            const errorsObject = err.response.data.errors;
            if ("Email" in errorsObject) {
                errorsObject["Email"].forEach(error => {
                    emailErrorDiv.innerHTML += `
                    <span>${error}</>
                    `
                });
            }
            if ("TextMessage" in errorsObject) {
                errorsObject["TextMessage"].forEach(error => {
                    textErrorDiv.innerHTML += `
                    <span>${error}</>
                    `
                });
            }
        })
});