function CallLightbox(type, id) {
    AppendLightboxSpace();
    var xhr = GetLightbox(type, id);
    PutLightbox('#lightbox_space', xhr.response);
}

function AppendLightboxSpace() {
    if (!$('div').is('#lightbox_space'))
    {
        $("body").append("<div id='lightbox_space'>test</div>");
    }
}

function GetLightbox(type, id) {
    var xhr = new XMLHttpRequest();
    var url = "/lightbox?type="+ type +"&id=" + id;
    
    xhr.open("Get", url, false);
    xhr.send();
    return xhr;
}

function PutLightbox(selector, content) {
    $(selector).html(content);
}

function HideLightbox() {
    $('#lightbox_space').html('');
}

jQuery(function($){
    $(document).mousedown(function (e){ // событие клика по веб-документу
        var div = $(".lightbox-window"); // тут указываем ID элемента
        if (!div.is(e.target) // если клик был не по нашему блоку
            && div.has(e.target).length === 0) { // и не по его дочерним элементам
            HideLightbox(); // скрываем его
        }
    });
});

function SendLightbox(url) {
    var formData = new FormData(document.forms.EditElement);
    var xhr = SendForm(formData, "/homeedit/" + url);
    ReloadPage(xhr.response);
}

function SendForm(formData, url) {    
    var xhr = new XMLHttpRequest();
    xhr.open("POST", url, false);
    xhr.send(formData);
    return xhr;
}

function ReloadPage(result) {
    if(result!=='null')
    {
        $('.send-error').text(result);
    }
    else location.reload();
}