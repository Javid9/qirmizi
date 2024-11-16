let variantSelect = document.getElementById('variant-select');
let variantAppend = document.getElementById('variant-append');
let variantAppendTable = document.getElementById('variant-append-table');
let mainGroupId = document.getElementById('main-group');
let variants = [];
let tableList = [];


document.addEventListener('DOMContentLoaded', function () {

    document.getElementById('add-variant').addEventListener('click', function (e) {
        e.target.closest('.add').classList.add('d-none');
        document.querySelector('.main-select').classList.remove('d-none');
    });


    /***  Main Variant Section Start   */
    variantSelect.addEventListener('change', (e) => {
        let groupId = e.target.value;
        let groupText = e.target.options[e.target.selectedIndex].text;
        let categoryButton = document.getElementById('category-button');
        let buttonNode = categoryButton.querySelectorAll('.btn-variant-delete');

        if (mainGroupId.value === "") mainGroupId.value = groupId;

        let isButtonExist = checkButtonExist(buttonNode, groupId);

        if (!isButtonExist) {
            categoryButton.appendChild(createVariantButton(groupId, groupText));
            variantAppend.appendChild(createParentSelect(groupId, groupText));
        }

        e.target.selectedIndex = 0;
    });

    function createVariantButton(buttonId, buttonText) {
        let button = document.createElement('button');
        button.setAttribute('data-id', buttonId);
        button.className = 'btn btn-outline-danger me-2 btn-variant-delete';
        button.innerHTML = ` <i class="bi bi-trash2-fill"></i><span class="ms-2">${buttonText}</span>`;

        button.addEventListener('click', (e) => {
            e.currentTarget.remove();
            let variantRemove = variantAppend.querySelector(`.mb-3[data-groupId="${buttonId}"]`);
            if (variantRemove) {

                if (mainGroupId.value === buttonId) {
                    variants = [];
                    tableList = [];
                    mainGroupId.value = "";
                    variantAppend.innerHTML = "";
                    variantAppendTable.innerHTML = "";
                    document.getElementById('category-button').innerHTML = "";

                } else {
                    tableList = [];
                    variants = variants.filter(item => item.groupId !== buttonId);
                    variants.forEach((item) => {
                        tableList.push({column: item.text, id: item.id});
                    });

                }
                variantRemove.remove();
            }
        });

        return button;
    }

    /***  Main Variant Section End   */
    function createParentSelect(variantId, variantText) {
        let createMain = document.createElement('div');
        createMain.className = 'mb-3';
        createMain.setAttribute('data-groupId', variantId);

        let createMainItem = document.createElement('div');
        createMainItem.className = 'select-form';

        let label = document.createElement('label');
        label.className = 'form-label';
        label.innerHTML = variantText;

        let select = document.createElement('select');
        select.className = 'form-select';
        select.id = variantId;
        select.innerHTML = Data(variantId);
        select.addEventListener("change", handleSelectChange());

        createMainItem.appendChild(label);
        createMainItem.appendChild(select);

        let createMainItemButtonPanel = document.createElement('div');
        createMainItemButtonPanel.className = 'select-form-group-button my-2';

        createMain.appendChild(createMainItem);
        createMain.appendChild(createMainItemButtonPanel);

        return createMain;


    }

    function handleSelectChange() {
        return (e) => {

            let buttonId = e.target.value;
            let buttonText = e.target.options[e.target.selectedIndex].text;
            let groupId = e.target.closest('.mb-3').getAttribute('data-groupId');
            let parentElement = e.target.closest('.mb-3').querySelector('.select-form-group-button');
            let buttonNode = parentElement.querySelectorAll('.btn-parent-delete');


            let isButtonExist = checkButtonExist(buttonNode, buttonId);

            if (!isButtonExist) {

                variants.push({
                    id: buttonId,
                    text: buttonText,
                    groupId: groupId
                });

                console.log(variants);

                tableListFilter(groupId, buttonId, buttonText);
                createVariantHiddenInput(buttonId);

                variantAppendTable.appendChild(createTable())

                e.target.parentElement?.nextElementSibling?.appendChild(createParentSelectButton(buttonId, buttonText));

            }
            e.target.selectedIndex = 0;
        }

    }

    function createVariantHiddenInput(id) {
        let hiddenInput = document.createElement('input');
        hiddenInput.type = 'hidden';
        hiddenInput.name = 'OptionHidden';
        hiddenInput.value = id;

        let optionHidden = document.getElementById('optionHidden');
        optionHidden.appendChild(hiddenInput);

    }

    function tableListFilter(groupId, buttonId, buttonText) {
        if (groupId === mainGroupId.value) {
            tableList.push({column: buttonText, id: buttonId});

            let parentVariant = variants.filter((item) => item.groupId !== mainGroupId.value);

            parentVariant.forEach((item) => {
                tableList = tableList.filter(innerItem => innerItem.column !== buttonText);
                tableList.push({column: buttonText + "-" + item.text, parentId: buttonId, id: item.id});
            });
        } else {
            let mainVariant = variants.filter((item) => item.groupId === mainGroupId.value);

            mainVariant.forEach((item) => {
                tableList = tableList.filter(innerItem => innerItem.column !== item.text);
                tableList.push({column: item.text + "-" + buttonText, parentId: item.id, id: buttonId});
            });
        }
    }

    function createParentSelectButton(buttonId, buttonText) {
        let button = document.createElement('button');
        button.setAttribute('data-id', buttonId);
        button.className = 'btn btn-outline-danger me-2 btn-parent-delete my-2';
        button.innerHTML = ` <i class="bi bi-trash2-fill"></i><span class="ms-2">${buttonText}</span>`;

        button.addEventListener('click', (e) => {
            e.currentTarget.remove();

            variants = variants.filter(item => item.id !== buttonId);

            let variantRemove = tableList.filter((item) => item.id === buttonId || item.parentId === buttonId);

            removeTableRow(variantRemove);

            tableList = tableList.filter(item => item.id !== buttonId && item.parentId !== buttonId);

            if (tableList.length === 0) {
                variantAppendTable.innerHTML = "";
            }
            let optionHidden = document.getElementById('optionHidden');
            let hiddenInput = optionHidden.querySelector(`input[value="${buttonId}"]`);
            if (hiddenInput) {
                hiddenInput.remove();
            }
        });


        return button;

    }

    function createTable() {
        let variantTable = document.getElementById("variantTable");

        if (variantTable) {
            let tbodyElement = variantTable.querySelector('tbody');
            tableList.forEach((item) => {
                let row = tbodyElement.querySelector(`tr[data-name="${item.column}"]`);
                if (!row) {
                    row = document.createElement("tr");
                    row.setAttribute("data-name", item.column);
                    let isButtonExist = updateAndAddTableRow(item.column);
                    if (!isButtonExist) {
                        row.innerHTML = createTableRow(item.column);
                        tbodyElement.appendChild(row);
                    }
                }
            });


            return variantTable;
        }

        let createTable = document.createElement("table");
        createTable.className = "table table-bordered table-hover table-striped";
        createTable.id = "variantTable";

        let createThead = document.createElement("thead");
        createThead.innerHTML = `<tr>
        <th scope="col">Adi</th>
        <th scope="col">Satış Fiyati</th>
        <th scope="col">İndirimli Fiyat</th>
        <th scope="col">SKU</th>
        <th scope="col">Bar Kod</th>
        <th scope="col">Stok</th>
        </tr>`;

        let createTbody = document.createElement("tbody");
        tableList.forEach((item) => {
            createTbody.innerHTML += createTableRow(item.column);
        });
        createTable.appendChild(createThead);
        createTable.appendChild(createTbody);

        return createTable;

    }

    function createTableRow(text) {
        let table = document.getElementById("variantTable");

        let count = table !== null
            ? variantTable.querySelectorAll("tbody tr").length
            : 0;

        return `<tr data-name="${text}">
                <td>
                <span class="name">${text}</span>
                     <input type="hidden" name="ProductVariants[${count}].Name" value="${text}" />
                </td>
                <td width="15%">
                   <input type="number" class="form-control" name="ProductVariants[${count}].SalePrice" />
                </td>
                <td width="20%">
                   <input type="number" class="form-control" name="ProductVariants[${count}].Discount" />
                </td>
                <td width="15%">
                   <input type="text" class="form-control" name="ProductVariants[${count}].Sku" />
                </td>
                <td width="15%">
                   <input type="text" class="form-control" name="ProductVariants[${count}].BarCode" />
                </td>
                <td width="15%">
                   <input type="number" class="form-control" name="ProductVariants[${count}].Stock" />  
                </td>
            </tr>`;

    }

    function updateAndAddTableRow(newText) {


        let table = document.getElementById("variantTable");
        let tr = table?.querySelectorAll('tbody tr');

        let isButtonExist = false;

        for (const item of tr) {
            let getDataName = item.getAttribute('data-name');
            let searchName = tableList.find((inlineItem) => inlineItem.column === getDataName);

            if (!searchName) {

                item.setAttribute('data-name', newText);
                let nameCell = item.querySelector('.name');
                let inputName = item.querySelector('input[name^="ProductVariants"]');
                if (nameCell) {
                    nameCell.innerHTML = newText;
                    inputName.value = newText;
                }
                isButtonExist = true;
                break;
            }
        }

        return isButtonExist;
    }

    function removeTableRow(tableRemoveList) {

        let table = document.getElementById("variantTable");
        let tr = table?.querySelectorAll('tbody tr');

        tr?.forEach((item) => {
            let getDataName = item.getAttribute('data-name');
            if (tableRemoveList.some(inlineItem => getDataName === inlineItem.column)) {
                item.remove();
            }
        });
    }

    function checkButtonExist(buttonNode, buttonId) {
        let isButtonExist = false;
        if (buttonNode.length === 0) return isButtonExist;

        buttonNode.forEach((item) => {
            if (item.getAttribute('data-id') === buttonId) {
                isButtonExist = true;
            }
        });

        return isButtonExist;
    }

    /******    Static data section    */
    function Data(id) {
        let option = '<option value=""></option>';
        let http = new XMLHttpRequest();
        let url = '/cms/product/getoptions?id=' + id;
        http.open('GET', url, false);

        http.onload = function () {
            if (http.status === 200) {
                let data = JSON.parse(http.response);
                data.forEach((item) => {
                    option += `<option value="${item.id}">${item.name}</option>`;
                });
            }
        }
        http.send();

        return option;
    }


    let formSelect = document.querySelectorAll('.edit-formSelect');
    let variantDeleteEdit = document.querySelectorAll('.btn-variant-delete-edit');
    let variantGroupDelete = document.querySelectorAll('.variant-group-delete');

    if (formSelect.length > 0) {
        formSelect.forEach((item) => {
            item.addEventListener('change', (e) => {
                let buttonId = e.target.value;
                let buttonText = e.target.options[e.target.selectedIndex].text;
                let groupId = e.target.closest('.mb-3').getAttribute('data-groupId');
                let parentElement = e.target.closest('.mb-3').querySelector('.select-form-group-button');
                let buttonNode = parentElement.querySelectorAll('.btn-parent-delete');


                let isButtonExist = checkButtonExist(buttonNode, buttonId);

                if (!isButtonExist) {

                    variants.push({
                        id: buttonId,
                        text: buttonText,
                        groupId: groupId
                    });

                    tableListFilter(groupId, buttonId, buttonText);
                    createVariantHiddenInput(buttonId);

                    variantAppendTable.appendChild(createTable())

                    e.target.parentElement?.nextElementSibling?.appendChild(createParentSelectButton(buttonId, buttonText));

                }
                e.target.selectedIndex = 0;
            });
        });
    }

    if (variantDeleteEdit.length > 0) {
        variantDeleteEdit.forEach((item) => {
            let data = {
                id: item.getAttribute('data-id'),
                text: item.getAttribute('data-text'),
                groupId: item.getAttribute('data-groupId')
            };

            variants.push(data);
            tableListFilter(data.groupId, data.id, data.text);

            item.addEventListener("click", (e) => {
                let buttonId = e.currentTarget.getAttribute('data-id');
                e.currentTarget.remove();


                variants = variants.filter(item => item.id !== buttonId);

                let variantRemove = tableList.filter((item) => item.id === buttonId || item.parentId === buttonId);

                removeTableRow(variantRemove);

                tableList = tableList.filter(item => item.id !== buttonId && item.parentId !== buttonId);

                if (tableList.length === 0) {
                    variantAppendTable.innerHTML = "";
                }
                let optionHidden = document.getElementById('optionHidden');
                let hiddenInput = optionHidden.querySelector(`input[value="${buttonId}"]`);
                if (hiddenInput) {
                    hiddenInput.remove();
                }


            });
        });
    }

    if (variantGroupDelete.length > 0) {
        variantGroupDelete.forEach((item) => {
            item.addEventListener("click", (e) => {
                let buttonId = e.currentTarget.getAttribute('data-id');
                e.currentTarget.remove();
                let variantRemove = variantAppend.querySelector(`.mb-3[data-groupId="${buttonId}"]`);
                if (variantRemove) {

                    if (mainGroupId.value === buttonId) {
                        variants = [];
                        tableList = [];
                        mainGroupId.value = "";
                        variantAppend.innerHTML = "";
                        variantAppendTable.innerHTML = "";
                        document.getElementById('category-button').innerHTML = "";

                    } else {
                        tableList = [];
                        variants = variants.filter(item => item.groupId !== buttonId);
                        variants.forEach((item) => {
                            tableList.push({column: item.text, id: item.id});
                        });

                    }
                    variantRemove.remove();
                }
            });
        });
    }

});
/******************************* */