document.body.addEventListener('htmx:configRequest', function(evt) {
    // not needed for GET requests
    if (evt.detail.verb === 'GET') {
        return;
    }
    
    let antiForgeryRequestToken = document.querySelector('input[name="__RequestVerificationToken"]')[0];
    if (antiForgeryRequestToken) {
        evt.detail.parameters['__RequestVerificationToken'] = antiForgeryRequestToken.value;
        console.log(antiForgeryRequestToken);
    }    
});

function showModal() {
    const backdrop = document.getElementById("modal-backdrop");
    const modal = document.getElementById("modal");

    setTimeout(() => {
        modal.classList.add("show")
        backdrop.classList.add("show")
    }, 10);
}

function closeModal() {
    const container = document.getElementById("product-modal-container");
    const backdrop = document.getElementById("modal-backdrop");
    const modal = document.getElementById("modal");

    modal.classList.remove("show")
    backdrop.classList.remove("show")

    setTimeout(function() {
        container.removeChild(backdrop)
        container.removeChild(modal)
    }, 200)
}