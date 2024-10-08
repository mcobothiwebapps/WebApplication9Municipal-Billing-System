// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Bootstrap JS and dependencies
const popperScript = document.createElement("script");
popperScript.src = "https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js";
document.head.appendChild(popperScript);

const bootstrapScript = document.createElement("script");
bootstrapScript.src = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js";
document.head.appendChild(bootstrapScript);

// Custom shuffle.js
const shuffleScript = document.createElement("script");
shuffleScript.src = "assets/js/shuffle.js";  // Make sure the path is correct
document.head.appendChild(shuffleScript);
