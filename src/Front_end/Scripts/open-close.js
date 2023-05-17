//Abrir e fechar popup de criar grupo
function createPopup() {
    const overlay = document.querySelector(".overlay");
    const content = document.querySelector(".content");

    overlay.style.display = "block";
    content.style.scale = "1";
}
function createClose() {

    const overlay = document.querySelector(".overlay");
    const content = document.querySelector(".content");
    const userInput = document.querySelector(".user-input");

    overlay.style.display = "none";
    content.style.scale = "0";
    
    userInput.value = "";
}

//Abrir e fechar popup de editar grupo
function editPopup () {

    const overlayEdit = document.querySelector("#overlay-edit");
    const contentEdit = document.querySelector("#content-edit");

    overlayEdit.style.display = "flex";
    contentEdit.style.scale = "1";
}
function editClose () {
    const overlayEdit = document.querySelector("#overlay-edit");
    const contentEdit = document.querySelector("#content-edit");

    overlayEdit.style.display = "none";
    contentEdit.style.scale = "0";
}

//Trocar entre tela de grupos e de senhas
function groupPasswordsOn() {
    var passwords = document.getElementById("mobile-passwords");
    var groups = document.getElementById("mobile-groups");

    passwords.style.display = "flex";

    groups.style.display = "none";
}
function groupPasswordsOff() {
    var passwords = document.getElementById("mobile-passwords");
    var groups = document.getElementById("mobile-groups");

    passwords.style.display = "none";

    groups.style.display = "flex";
}

//Abrir e fechar popup de criar senha
function createNewPasswordOn() {
    const overlayPassword = document.querySelector("#overlay-new-password");
    const contentPassword = document.querySelector("#content-new-password");

    overlayPassword.style.display = "flex";
    contentPassword.style.scale = "1";
}
function createNewPasswordOff() {
    const overlayPassword = document.querySelector("#overlay-new-password");
    const contentPassword = document.querySelector("#content-new-password");

    overlayPassword.style.display = "none";
    contentPassword.style.scale = "0";
}