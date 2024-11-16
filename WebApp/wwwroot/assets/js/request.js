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
  function fetchData(url, value, dropdownTextElement, itemText) {
    if (dropdownTextElement) {
      dropdownTextElement.textContent = itemText;
    }
    cardContent?.classList.add("d-none");
    loading.classList.remove("d-none");
    fetch(url, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      // body: { value: value },
    })
      .then((response) => {
        if (!response.ok) {

          throw new Error("Error Response: " + response.statusText);
          }
          console.log(response.json());
        return response.json();
      })

      .then((data) => {
        cardContent.innerHTML = '';
        cardContent.classList.remove("d-none");
        loading.classList.add("d-none");
        cardContent.innerHTML = data;
      })
      .catch((error) => {
        alert("İşlem gerçekleştirilmedi Sayfa yenilenecektir." + error);
        setTimeout(() => {
          window.location.reload();
        }, 2000);
        cardContent.classList.remove("d-none");
        loading.classList.add("d-none");
      });
    }




    //const lang = "az";

    //searchBtnSpeaker?.addEventListener('click', function () {
    //    const value = searchInput.value;
    //    const searchUrl = `/${lang}/spikerler/ara`;
    //    const urlWithQuery = `${searchUrl}?query=${encodeURIComponent(value)}`;

    //    fetchData(urlWithQuery);
    //});

    //// Fetch Data Function
    //function fetchData(url) {
    //    cardContent?.classList.add("d-none");
    //    loading.classList.remove("d-none");

    //    fetch(url, {
    //        method: "GET",
    //        headers: {
    //            "Content-Type": "application/json",
    //        },
    //    })
    //        .then((response) => {
    //            if (!response.ok) {
    //                throw new Error('HTTP error ' + response.status);
    //            }
    //            return response.json();
    //        })
    //        .then((data) => {
    //            cardContent.innerHTML = ''; // Clear previous content
    //            cardContent.classList.remove("d-none");
    //            loading.classList.add("d-none");

    //            // Check if 'data' is an array and process accordingly
    //            if (Array.isArray(data.data)) {  // 'data.data' is the array that holds the speaker objects
    //                // Loop through the array and create HTML elements for each speaker
    //                data.data.forEach(item => {
    //                    const itemElement = document.createElement('div');
    //                    itemElement.classList.add('speaker-item'); // Add a class for styling, if needed

    //                    // Add speaker data (modify as per your data)
    //                    itemElement.innerHTML = `
    //                <div class="speaker-card">
    //                    <img src="/images/${item.fileCode}" alt="${item.fullName}" class="speaker-image" />
    //                    <div class="speaker-info">
    //                        <h3>${item.fullName}</h3>
    //                        <p>${item.position}</p>
    //                        <a href="/${lang}/spikerler/${item.slugUrl}">Profile</a>
    //                    </div>
    //                </div>
    //            `;
    //                    cardContent.appendChild(itemElement);
    //                });
    //            } else {
    //                console.error('Unexpected data format:', data);
    //                alert('Beklenmedik bir hata oluştu.');
    //            }
    //        })
    //        .catch((error) => {
    //            console.error('Fetch error:', error);
    //            alert("İşlem gerçekleştirilmedi. Sayfa yenilenecektir. Hata: " + (error.message || "Bilinmeyen hata"));
    //            setTimeout(() => {
    //                window.location.reload();
    //            }, 2000);
    //            cardContent.classList.remove("d-none");
    //            loading.classList.add("d-none");
    //        });
    //}



    

  
  // EVENT STATUS AKTİV PASİF DROPDOWN SELECT URL DEĞİŞTİRİLECEK 
  statusItems.forEach((item) => {
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
  
  

  // SPEAKER SEARCH BUTTON CLİCK URL DEĞİŞTİRİLECEK
  //searchBtnSpeaker?.addEventListener('click', function () {
  //  const value = searchInput.value;
  //  fetchData("https://jsonplaceholder.typicode.com/todos/1", value, dropdownTextElement = null, itemText = '')
    //});



    // SPEAKER SEARCH BUTTON CLICK URL DEĞİŞTİRİLECEK
    searchBtnSpeaker?.addEventListener('click', function () {
        const value = searchInput.value;
        const lang = "az"; 
        const searchUrl = `/${lang}/spikerler/ara`;

        const urlWithQuery = `${searchUrl}?query=${encodeURIComponent(value)}`;

        fetchData(urlWithQuery, value, dropdownTextElement = null, itemText = '');
    });




});










