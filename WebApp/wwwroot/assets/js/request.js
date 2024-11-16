document.addEventListener("DOMContentLoaded", function () {
    const statusItems = document.querySelectorAll(".statusDown .dropdown-item");
    const categoryItems = document.querySelectorAll(".categoryDown .dropdown-item");
    const searchInput = document.getElementById("searchKeyInput");
    const searchBtnEvent = document.getElementById("searchButtonEvent");
    const searchBtnSpeaker = document.getElementById("searchButtonSpeaker");
    const btnBasketDelete = document.querySelectorAll('.btnBasketDelete');
    const ticketPacketItem = document.querySelectorAll(".ticketPacketDown .dropdown-item");
    const content = document.getElementById("cardList");
    const cardContent = content?.querySelector(".card-content");
    const loading = content?.querySelector(".loading");
    const basketMinus = document.querySelectorAll(".basket-minus");
    const basketPlus = document.querySelectorAll(".basket-plus");

    var loadngBasket = document.createElement("div");
    loadngBasket.classList.add("BasketLoading");
    loadngBasket.innerHTML = `
    <div class="spinner-border text-primary" role="status">
      <span class="visually-hidden">Loading...</span>
    </div>
  `;


    //SEPET TİCKET İTEM ARTIŞ AZALIŞ URL VE BODY BÖLÜMÜ DEĞİŞTİRİLECEK
    const updateBasketItem = (productId, quantity) => {
        document.body.appendChild(loadngBasket);
        fetch(`https://jsonplaceholder.typicode.com/todos/1`, {
            method: "PATCH",
            headers: {
                "Content-Type": "application/json",
            },
            // body: JSON.stringify({
            //   productId: productId,
            //   quantity: quantity,
            // }),
        })
            .then((response) => {
                if (!response.ok) {
                    throw new Error("Failed to update basket item");
                }
                return response.json();
            })
            .then(() => {
                document.querySelector(".BasketLoading").remove();
            })
            .catch((error) => {
                alert("İşlem gerçekleştirilmedi Sayfa yenilenecektir." + error);
                setTimeout(() => {
                    window.location.reload();
                }, 1000);
            });
    };

    function calculateTotal() {
        let total = 0;
        const basketCards = document.querySelectorAll('.basket-card');

        basketCards.forEach(card => {
            const price = parseFloat(card.querySelector('.card-price').textContent);
            const quantity = parseInt(card.querySelector('.basket-count').value);
            total += price * quantity;
        });


        const totalPriceInput = document.getElementById('totalPrice');
        const totalPriceDisplay = document.querySelector('.total-price');

        if (totalPriceInput) {
            totalPriceInput.value = total;
        }

        if (totalPriceDisplay) {
            totalPriceDisplay.textContent = total;
        }
    }


    calculateTotal();


    basketMinus.forEach((item) => {
        item.addEventListener("click", function () {
            const basketCard = this.closest(".basket-card");
            const input = basketCard.querySelector(".basket-count");
            const productId = basketCard.querySelector("#productId").value;
            let currentValue = parseInt(input.value);
            if (currentValue > 1) {
                currentValue -= 1;
                input.value = currentValue;
                updateBasketItem(productId, currentValue);
                calculateTotal();
            }
        });
    });


    basketPlus.forEach((item) => {
        item.addEventListener("click", function () {
            const basketCard = this.closest(".basket-card");
            const input = basketCard.querySelector(".basket-count");
            const productId = basketCard.querySelector("#productId").value;
            let currentValue = parseInt(input.value);
            currentValue += 1;
            input.value = currentValue;
            updateBasketItem(productId, currentValue);
            calculateTotal();
        });
    });


    // BASKET PACKET CHANGE SİLVER GOLD URL DEĞİŞTİRİLECEK VALUE AKTİF EDİLECEK
    ticketPacketItem.forEach((item) => {
        item.addEventListener('click', function () {
            document.body.appendChild(loadngBasket);
            const value = this.getAttribute("data-value");
            const productId = this.closest('.basket-card').querySelector('#productId').value;
            fetch('https://jsonplaceholder.typicode.com/todos/1', {
                method: "PATCH",
                headers: {
                    "Content-Type": "application/json",
                },
                // body: JSON.stringify({
                //   productId: productId,
                //   value: value,
                // }),
            })
                .then((response) => {
                    if (!response.ok) {
                        throw new Error("Error Response: " + response.statusText);
                    }
                    return response.json();
                })
                .then((data) => {
                    const dropdownTextElement = item
                        .closest(".dropdown")
                        .querySelector(".dropdownText");
                    dropdownTextElement.textContent = item.textContent;
                    document.querySelector(".BasketLoading").remove();
                })
                .catch((error) => {
                    alert("İşlem gerçekleştirilmedi Sayfa yenilenecektir." + error);
                    setTimeout(() => {
                        window.location.reload();
                    }, 1000);
                });
        })
    })
    // BASKET PACKET CHANGE SİLVER GOLD END

    // BASKET ÜRÜN DELETE URL DEĞİŞTİRİLECEK VALUE AKTİF EDİLECEK
    btnBasketDelete?.forEach((item) => {
        item.addEventListener('click', function () {
            const productId = this.closest('.basket-card').querySelector('#productId').value;
            Swal.fire({
                title: "silmək istədiyinizə əminsiniz?",
                showCancelButton: true,
                confirmButtonColor: "#140a6a",
                cancelButtonColor: "#fc5816",
                confirmButtonText: "Evet",
                cancelButtonText: "Hayır",
            }).then((result) => {
                if (result.isConfirmed) {
                    document.body.appendChild(loadngBasket);
                    fetch('https://jsonplaceholder.typicode.com/todos/1', {
                        method: "GET",
                        headers: {
                            "Content-Type": "application/json",
                        },
                        // body: { value: productId },
                    })
                        .then((response) => {
                            if (!response.ok) {
                                throw new Error("Error Response: " + response.statusText);

                            }
                            return response.json();
                        })
                        .then(() => {
                            calculateTotal();
                            const basketContent = document.querySelector('.basket-content');
                            const productCard = document.querySelectorAll(`.basket-card`);
                            const ısBasket = document.querySelector('.ısBasket');
                            this.closest('.basket-card').remove();
                            document.querySelector(".BasketLoading").remove();
                            calculateTotal();
                            if (productCard.length == 1) {
                                ısBasket.innerHTML = '';
                                basketContent.innerHTML = `
                       <div class="no-basket d-flex flex-column align-items-center">
                        <i class="bi bi-ticket-perforated-fill"></i>
                        <p>Səbətinizdə bilet yoxdur.</p>
                      </div>
                `;
                            }
                        })
                        .catch((error) => {
                            alert("İşlem gerçekleştirilmedi Sayfa yenilenecektir." + error);
                            setTimeout(() => {
                                window.location.reload();
                            }, 2000);
                        });

                }
            });
        })
    })
    // BASKET ÜRÜN DELETE END

    // EVENT,SPEAKER SEARCH DROPDOWN AND KEY SEARCH URL DEĞİŞTİRİLECEK VALUE AKTİF EDİLECEK
    function fetchData(url, value, dropdownTextElement, itemText, contentType = "application/json") {
        if (dropdownTextElement) {
            dropdownTextElement.textContent = itemText;
        }
        cardContent?.classList.add("d-none");
        loading.classList.remove("d-none");
        fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": contentType
            },
            // body: { value: value },
        })
            .then((response) => {
                if (!response.ok) {
                    throw new Error("Error Response: " + response.statusText);
                }
                return contentType === "application/json" ? response.json() : response.text();
            })

            .then((data) => {
                cardContent.innerHTML = '';
                cardContent.classList.remove("d-none");
                loading.classList.add("d-none");
                if (data.trim() === "") {
                    cardContent.innerHTML = '<p class="text-center">Nəticə tapılmadı</p>';
                } else {
                    cardContent.innerHTML = data;
                }


            })
            .catch((error) => {
                cardContent.classList.remove("d-none");
                loading.classList.add("d-none");
            });
    }

    // EVENT STATUS AKTİV PASİF DROPDOWN SELECT URL DEĞİŞTİRİLECEK 
    statusItems.forEach((item) => {
        item.addEventListener("click", function () {
            alert("Status Click");
            const value = this.getAttribute("data-value");
            const dropdownTextElement = item
                .closest(".dropdown")
                .querySelector(".dropdownText");
            fetchData(
                "https://jsonplaceholder.typicode.com/todos/1",
                value,
                dropdownTextElement,
                item.textContent
            );
        });
    });

    // EVENT CATEGORY SELECT DROPDOWN  URL DEĞİŞTİRİLECEK
    categoryItems.forEach((item) => {
        item.addEventListener("click", function () {
            const value = this.getAttribute("data-value");
            const dropdownTextElement = item
                .closest(".dropdown")
                .querySelector(".dropdownText");
            fetchData(
                "https://jsonplaceholder.typicode.com/todos/1",
                value,
                dropdownTextElement,
                item.textContent
            );
        });
    });

    // EVENT SEARCH BUTTON CLİCK URL DEĞİŞTİRİLECEK

    // SPEAKER SEARCH BUTTON CLICK URL DEĞİŞTİRİLECEK
    searchBtnSpeaker?.addEventListener('click', function () {
        const value = searchInput.value;
        const lang = "az";
        const searchUrl = `/${lang}/spikerler/ara`;

        const urlWithQuery = `${searchUrl}?query=${encodeURIComponent(value)}`;

        fetchData(urlWithQuery, value, dropdownTextElement = null, itemText = '', contentType = "html");
    });


});










