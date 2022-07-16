// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const navDropdownButton = document.querySelector("#nav-dropdown-btn")
const navDropdownMenu = document.querySelector("#nav-dropdown-menu")
navDropdownButton.addEventListener("click", function(event) {
    console.log("Button clicked!");
    if(navDropdownMenu.classList.contains("show")) {
        navDropdownMenu.classList.remove("show")
    }
    else {
        navDropdownMenu.classList.add("show")
    }
})
