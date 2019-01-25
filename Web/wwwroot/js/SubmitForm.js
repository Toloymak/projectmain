$('.post').click(function() {
    // создать объект для формы
    var formData = new FormData(document.forms.blockForm);

    // отослать
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/url");
    xhr.send(formData);
})
