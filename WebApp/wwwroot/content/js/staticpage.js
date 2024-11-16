$(document).ready(function () {

    GenerateClass()

    function GenerateClass() {
        let lang = $('#langHidden').val();
        let tags = [".cos h1", ".cos h2", ".cos h3", ".cos h4", ".cos p", ".cos li", ".cos strong", ".cos a"];
        let textTags = document.querySelectorAll(tags);
        let imgTags = document.querySelectorAll('.cos  img');

        for (let i = 0; i < textTags.length; i++) {
            let button = createButton();
            let videoTag = textTags[i];

            if (!videoTag.hasAttribute('data-lity')) {
                textTags[i].style.position = "relative";
                textTags[i].innerHTML += button;
                textTags[i].setAttribute('data-type', 'text');
            }


        }

        if (lang === "az") {
            for (let i = 0; i < imgTags.length; i++) {
                let button = createButton();
                imgTags[i].parentElement.setAttribute('data-type', 'image');
                imgTags[i].style.position = "relative";
                imgTags[i].parentElement.innerHTML += button;

            }
        }
    }

    function createButton(text = "") {

        return `${text} <button class="btn btn-black btn-sm content-edit position-absolute p-1"  type="button"  style="left: 0px; top: -35px;">
                                    <i class="bi bi-pencil-square" style="font-size: 18px"></i>
                                 </button> `;
    }

    $(document).on('click', '.content-edit', function (e) {
        e.preventDefault();
        $('#offCanvasRight').offcanvas('show');
        let type = $(this).parent().attr('data-type');
        let changeId = Math.floor(Math.random() * 100);
        $(this).parent().attr('data-changeId', changeId);

        if (type === "text") {
            let text = $(this).parent().text().trim();
            let parentElement = $(this).parent()[0];
            let hrefAppend = '';
            if (parentElement.hasAttribute('href')) {
                let link = parentElement.href;
                hrefAppend = `<div class="mb-3">
                    <label for="hrefLink" class="form-label">Yönlendirilecek Url</label>
                        <input class="form-control" type="text" id="hrefLink" value="${link}">
                    </div>`;
            }
            $('#offCanvasRight').find('.offcanvas-body').html(`
                    <div class="mb-3"
                        <label for="text">Değişecek alan</label>
                        <textarea class="form-control" id="text" rows="3">${text}</textarea>
                    </div>
                    ${hrefAppend}
                    <div class="mb-3">
                         <button type="button" data-id="${changeId}" class="btn btn-primary change-text">Kaydet</button>
                    </div>
                `);
        } else if (type === "image") {
            let src = $(this).parent().find('img').attr('src');
            let parentElement = $(this).parent()[0];
            let videoAppend = '';
            if (parentElement.hasAttribute('data-lity')) {

                let url = parentElement.href;
                videoAppend = `<div class="mb-3">
                    <label for="videoLink" class="form-label">VideoUrl</label>
                        <input class="form-control" type="text" id="videoLink" value="${url}">
                    </div>`;

            }

            $('#offCanvasRight').find('.offcanvas-body').html(`
                    <div class="mb-3">
                        <label for="formFile" class="form-label">Değişecek alan</label>
                        <input class="form-control" type="file" id="formFile">
                    </div>
                    ${videoAppend}
                    <div class="mb-3">
                        <img src="${src}" class="img-fluid" alt="...">
                    </div>
                    <div class="mb-3">
                        <button type="button" data-id="${changeId}" class="btn btn-primary change-image">Kaydet</button>
                    </div>
                `);
        }

    });
    $(document).on('click', '.change-text', function () {
        let changeId = $(this).attr('data-id');
        let text = $('#text').val().trim();
        let hrefLink = $('#hrefLink').val();
        let changeText = $(`[data-changeId=${changeId}]`);



        if (changeText[0].hasAttribute('data-count')) {
            changeText.attr('data-count', text);

        }
        else {
            changeText.text('');
            let button = createButton(text);
            changeText.append(button);

            if (hrefLink) {
                changeText.attr('href', hrefLink);
            }
        }

        $('#text').val('');
        $('#offCanvasRight').offcanvas('hide');
        $(`[data-changeId=${changeId}]`).removeAttr('data-changeId');
        $(this).removeAttr('data-type');
    });

    $(document).on('click', '.change-image', function () {
        let changeId = $(this).attr('data-id');
        let file = $('#formFile')[0].files[0];
        let videoLink = $('#videoLink').val();
        let changeImage = $(`[data-changeId=${changeId}]`);
        const formData = new FormData();

        if (file) {
            formData.append("file", file);
            let xhr = new XMLHttpRequest();
            xhr.open("POST", "/Upload/FileStatic");
            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    let responseData = JSON.parse(xhr.responseText);
                    let data = responseData.response;
                    let src = `/${data}`;
                    changeImage.find('img').attr('src', src);

                }
            };
            xhr.send(formData);
        }

        if (videoLink) {
            changeImage.attr('href', videoLink);
        }

        $('#offCanvasRight').offcanvas('hide');
        $(`[data-changeId=${changeId}]`).removeAttr('data-changeId');
        $(this).removeAttr('data-type');
    });

    $('.save-html').click(function () {
        let removeButton = document.querySelectorAll('.content-edit');
        for (let i = 0; i < removeButton.length; i++) {
            removeButton[i].parentElement.removeAttribute('style');
            removeButton[i].parentElement.removeAttribute('data-type');
            removeButton[i].remove();
        }
        let htmlData = $('.html-content').html();
        let lang = $('#langHidden').val();
        let page = $('#pageHidden').val();
        const formData = new FormData();
        formData.append("content", htmlData);
        formData.append("lang", lang);
        formData.append("page", page);
        let xhr = new XMLHttpRequest();
        xhr.open("POST", "/cms/Static/Update");
        xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
                window.location.href = "/cms/Static/Index";
            } else {
                window.location.href = "/cms/Static/Index";
            }
        };
        xhr.send(formData);
    });
});
