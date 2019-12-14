// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var span = document.getElementById('DateTime');

function time() {
    var d = new Date();
    span.innerHTML = d.toLocaleString();
} setInterval(time, 1000);

window.onload = time();