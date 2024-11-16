document.querySelectorAll("img.svg").forEach(function (img) {
  var imgID = img.id;
  var imgClass = img.className;
  var imgURL = img.src;

  fetch(imgURL)
    .then((response) => response.text())
    .then((data) => {
      var parser = new DOMParser();
      var xmlDoc = parser.parseFromString(data, "image/svg+xml");
      var svg = xmlDoc.querySelector("svg");

      if (imgID) {
        svg.setAttribute("id", imgID);
      }
      if (imgClass) {
        svg.setAttribute("class", imgClass + " replaced-svg");
      }

      svg.removeAttribute("xmlns:a");

      if (
        !svg.getAttribute("viewBox") &&
        svg.getAttribute("height") &&
        svg.getAttribute("width")
      ) {
        svg.setAttribute(
          "viewBox",
          "0 0 " + svg.getAttribute("height") + " " + svg.getAttribute("width")
        );
      }

      img.parentNode.replaceChild(svg, img);
    })
    .catch((error) => {
      console.error("Error fetching the SVG:", error);
    });
});

document.addEventListener("DOMContentLoaded", function () {
  AOS.init({
    once: "true",
  });

  const seePaswword = document.querySelectorAll(".see-paswword");
  const navbarIcon = document.querySelector(".nav-icons-check");
  const buttonFacebook = document.querySelector(".btn-facebook");
  const buttonTwitter = document.querySelector(".btn-twitter");
  const buttonLinkedIn = document.querySelector(".btn-linkedin");
  const aboutSlider = document.querySelector(".about-partner-slider");
  const basketMinus = document.querySelector(".basket-minus");
  const basketPlus = document.querySelector(".basket-plus");
  const homeEventCards = document.querySelectorAll(".event-list-card");
  // Home Header variables
  const eventItems = document.querySelectorAll(".box-content .item");
  const headerBackground = document.querySelector(".home-header-section");
  const headerHeading = document.querySelector(".header-heading");
  const buttonLink = document.getElementById("headerButtonLink");
  const frameModalHref = document.querySelectorAll("a[data-frame]");

  // SLİDER
  if (aboutSlider) {
    new Swiper(aboutSlider, {
      slidesPerView: 6,
      spaceBetween: 30,
      loop: true,
      speed: 800,
      // autoplay: {
      //   delay: 4000,
      // },
      breakpoints: {
        0: {
          slidesPerView: 2,
          spaceBetween: 50,
          centeredSlides: false,
        },
        684: {
          slidesPerView: 3,
          centeredSlides: false,
        },
        991: {
          slidesPerView: 4,
        },
        1300: {
          slidesPerView: 5,
        },
        1600: {
          slidesPerView: 6,
        },
      },
    });
  }

  // SCROLL EVENT START

  function handleScroll() {
    let totalHeight = window.scrollY;
    let scrollTop = document.querySelector(".navbar-content");
    if (totalHeight > 90) {
      scrollTop.classList.add("fixed-menu");
    } else {
      scrollTop.classList.remove("fixed-menu");
    }
  }
  handleScroll();

  window.addEventListener("scroll", function () {
    handleScroll();
  });

  // SCROLL EVENT END



  // PASSWORD SEE
  seePaswword.forEach(function (button) {
    button.addEventListener("click", function () {
      const input = this.previousElementSibling;
      if (input.type === "password") {
        input.type = "text";
      } else {
        input.type = "password";
      }
    });
  });

  // NAVBAR CLİCK START
  navbarIcon.addEventListener("click", function () {
    let bodyElement = document.body;
    let htmlElement = document.documentElement;
    if (navbarIcon.checked) {
      bodyElement.classList.add("overflow");
      htmlElement.classList.add("overflow");
    } else {
      bodyElement.classList.remove("overflow");
      htmlElement.classList.remove("overflow");
    }
  });
  // NAVBAR CLİCK END

  // SOCİAL SHARE  START
  buttonFacebook?.addEventListener("click", function () {
    let urlToShare = window.location.href;
    window.open(
      "https://www.facebook.com/sharer/sharer.php?u=" +
        encodeURIComponent(urlToShare),
      "_blank"
    );
  });


  buttonLinkedIn?.addEventListener("click", function () {
    let urlToShare = window.location.href;
    let title = "Başlık buraya"; // Paylaşım başlığını buraya ekleyin
    let summary = "Özet veya açıklama buraya"; // Paylaşım açıklamasını buraya ekleyin
  
    window.open(
      `https://www.linkedin.com/shareArticle?mini=true&url=${encodeURIComponent(
        urlToShare
      )}&title=${encodeURIComponent(title)}&summary=${encodeURIComponent(
        summary
      )}`,
      "_blank"
    );
  });
  

  buttonTwitter?.addEventListener("click", function () {
    let textToShare = document
      .getElementById("socialHeading")
      .textContent.trim();
    let urlToShare = window.location.href;
    window.open(
      "https://twitter.com/intent/tweet?text=" +
        encodeURIComponent(textToShare) +
        "&url=" +
        encodeURIComponent(urlToShare),
      "_blank"
    );
  });
  // SOCİAL SHARE  END

  // HOME HEADER START
  homeEventCards.forEach(function (card) {
    card.addEventListener("mouseenter", () => {
      let bgUrl = card.getAttribute("data-bg-url");
      card.style.setProperty("--bg-url", `url(${bgUrl})`);
    });
    card.addEventListener("mouseleave", () => {
      card.style.setProperty("--bg-url", "none");
    });
  });

  function handleItemClick(item, event) {
    eventItems.forEach((innerItem) => innerItem.classList.remove("active"));
    let headingText = item.getAttribute("data-text");
    let link = item.getAttribute("data-url");
    item.classList.add("active");
    let bgUrl = event
      ? event.target.tagName === "IMG"
        ? event.target.getAttribute("src")
        : null
      : item.querySelector("img").getAttribute("src");
    buttonLink.setAttribute("href", link);
    headerHeading.textContent = headingText;
    headerHeading.classList.remove("activetext");
    requestAnimationFrame(() => {
      headerHeading.classList.add("activetext");
    });
    if (bgUrl) {
      headerBackground.style.backgroundImage = `url(${bgUrl})`;
    }
  }

  eventItems.forEach((item) => {
    item.addEventListener("click", (event) => handleItemClick(item, event));
  });

  if (eventItems.length > 0) {
    const firstItem = eventItems[0];
    firstItem.classList.add("active");
    handleItemClick(firstItem);
  }

  // let currentIndex = 0;
  // setInterval(() => {
  //   currentIndex = (currentIndex + 1) % eventItems.length;
  //   const nextItem = eventItems[currentIndex];
  //   handleItemClick(nextItem);
  // }, 5000);

  // HOME HEADER END

  // VİDEO MODAL START
  frameModalHref.forEach(function (item) {
    item.addEventListener("click", function (e) {
      e.preventDefault();
      let url = item.getAttribute("href");
      let frameModal = document.createElement("div");
      let existingModal = document.querySelector(".frameModal");
      if (existingModal) return;
      frameModal.classList.add("frameModal");
      frameModal.innerHTML = htmlBody(url.split("=")[1]);
      document.body.appendChild(frameModal);
      const exitButton = frameModal.querySelector(".btn-frame-exit");
      exitButton?.addEventListener("click", function () {
        frameModal.remove();
      });
    });
  });

  
  function htmlBody(url) {
    let bodyElement = `<div class="frame-content">
        <iframe
          width="100%"
          height="100%"
          src="https://www.youtube.com/embed/${url}"
          title="YouTube video player"
          frameborder="0"
          allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
          referrerpolicy="strict-origin-when-cross-origin"
          allowfullscreen
        ></iframe>
      </div>
      <button type="button" class="btn btn-frame-exit">
        <i class="bi bi-x-lg"></i>
      </button>
   `;
    return bodyElement;
  }
  // VİDEO MODAL END

  // OTP START
  var timeoutHandle;
  function countdown(minutes, seconds) {
    function timeing() {
      var counter = document?.getElementById("timer");
      if (counter) {
        counter.innerHTML =
          minutes.toString() +
          ":" +
          (seconds < 10 ? "0" : "") +
          String(seconds);
        seconds--;
        if (seconds < 0) {
          minutes--;
          seconds = 59;
        }
        if (minutes < 0) {
          clearTimeout(timeoutHandle);
          const content = document.querySelector(".code-body");
          content.innerHTML += `<span class="btn btn-refresh-code">
                                    Yenidən göndər
                                </span>
                     `;
        } else {
          timeoutHandle = setTimeout(timeing, 1000);
        }
      }
    }
    timeing();
  }

  document.addEventListener("click", function (event) {
    if (event.target.classList.contains("btn-refresh-code")) {
      event.target.remove();
      countdown(0, 30);
      const codeInputs = document.querySelectorAll(".numbersing");
      codeInputs.forEach((input) => (input.value = ""));
    }
  });

  document.querySelectorAll(".numbersing").forEach((input) => {
    input.addEventListener("keyup", function (event) {
      if (event.key === "Backspace" && this.value === "") {
        console.log(input)
        const prevInput =
          this.closest(".item-numbers")?.previousElementSibling?.querySelector(
            "input"
          );

        if (prevInput) {
          prevInput.focus();
        }
      } else {
        const nextInput =
          this.closest(".item-numbers")?.nextElementSibling?.querySelector(
            "input"
          );

        if (nextInput) {
          nextInput.focus();
        }
      }

      let controls = true;
        document.querySelectorAll(".numbersing").forEach((inp) => {
        if (inp.value.trim() === "") {
          controls = false;
        }
      });

      const otpSendButton =
        this.closest("form").querySelector(".btn-send");
      if (controls) {
        otpSendButton?.removeAttribute("disabled");
      } else {
        otpSendButton?.setAttribute("disabled", "disabled");
      }
    });
  });

  countdown(0, 5);
  // OTP END

  // PROFİLE GÜN AY YIL YAZDIRMA

  const dayElement = document?.querySelector('.profile-day');
  const monthElement = document?.querySelector('.profile-month');
  const yearElement = document?.querySelector('.profile-year');
  const selectedDate  = document?.getElementById('selectedDate');

  let day = 31;
  let month = 12;
  let currentYear = new Date().getFullYear();
  let years = [];

  for (let year = 1950; year <= currentYear; year++) {
    years.push(year);

  }

if (yearElement) {
  years.forEach(year => {
    yearElement.innerHTML += `<option value="${year}">${year}</option>`;
  });

  for (let i = 1; i <= month; i++) {
    monthElement.innerHTML += `<option value="${i}">${i}</option>`;
  };

  
  for (let i = 1; i <= day; i++) {
    dayElement.innerHTML += `<option value="${i}">${i}</option>`;
  };


  dayElement.addEventListener('change', inputChange);
  monthElement.addEventListener('change', inputChange);
  yearElement.addEventListener('change', inputChange);


  function inputChange() {
    let dayValue = dayElement.value;
    let monthValue = monthElement.value;
    let yearValue = yearElement.value;
    if (dayValue && monthValue && yearValue) {
      selectedDate.value = `${yearValue}-${String(monthValue).padStart(2, '0')}-${String(dayValue).padStart(2, '0')}`;
    }
  }
}
  
const eventCarding = document.querySelectorAll('.event-list-card');

eventCarding.forEach((item, index) => {
  const delay = index * 250; 
  item.setAttribute('data-aos-delay', delay.toString());
});


const ticketPacketItem = document.querySelectorAll(".contactSubject .dropdown-item");

ticketPacketItem.forEach((item) => {
  item.addEventListener("click", function () {
    const value = this.getAttribute("data-value");
    item.closest(".dropdown").querySelector(".dropdownText").textContent = item.textContent;
    item.closest(".dropdown").querySelector(".subjectinput").value = value;
  });
});




});
