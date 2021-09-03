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