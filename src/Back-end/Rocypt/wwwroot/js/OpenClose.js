
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
function editPopup(groupId, groupName) {
    console.log(`ID do grupo: ${groupId}`);
    console.log(`Nome do grupo: ${groupName}`);


    const overlayEdit = document.querySelector("#overlay-edit");
    const contentEdit = document.querySelector("#content-edit");
    const groupNameInput = document.querySelector("#group-name-input");
    const groupIdInput = document.querySelector("#group-id-input");


    overlayEdit.style.display = "flex";
    contentEdit.style.scale = "1";

    if (groupNameInput) {
        groupNameInput.value = groupName;
    }

    if (groupIdInput) {
        groupIdInput.value = groupId;
    }



}
function editClose() {
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
    const mainTitle = document.getElementById("popup-title");
    const mainText = document.getElementById("popup-text");


    overlayPassword.style.display = "flex";
    contentPassword.style.scale = "1";

    mainTitle.innerHTML = "Adicionar nova Senha...";
    mainText.innerHTML = "";


}
function createNewPasswordOff() {
    const overlayPassword = document.querySelector("#overlay-new-password");
    const contentPassword = document.querySelector("#content-new-password");

    overlayPassword.style.display = "none";
    contentPassword.style.scale = "0";
}

//Abrir e fechar popup de editar senha
function editPasswordOn() {
    const overlayPassword = document.querySelector("#overlay-new-password");
    const contentPassword = document.querySelector("#content-new-password");
    const mainTitle = document.getElementById("popup-title");
    const mainText = document.getElementById("popup-text");

    overlayPassword.style.display = "flex";
    contentPassword.style.scale = "1";

    mainTitle.innerHTML = "Visualização da senha...";
    mainText.innerHTML = "Pode ser editada...";

}

//Popup de deletar senha
function deletePasswordOn() {
    const overlayExclude = document.querySelector("#overlay-exclude");
    const contentExclude = document.querySelector("#content-exclude");

    overlayExclude.style.display = "flex";
    contentExclude.style.scale = "1";
}
function deletePasswordOff() {
    const overlayExclude = document.querySelector("#overlay-exclude");
    const contentExclude = document.querySelector("#content-exclude");

    overlayExclude.style.display = "none";
    contentExclude.style.scale = "0";
}

//Popup de deletar grupo
function deleteGroupOn() {
    const contentExcludeGroup = document.querySelector("#content-exclude-group");

    contentExcludeGroup.style.scale = "1";
}
function deleteGroupCancel() {
    const contentExcludeGroup = document.querySelector("#content-exclude-group");

    contentExcludeGroup.style.scale = "0";
}
function deleteGroupExclude() {
    const contentExcludeGroup = document.querySelector("#content-exclude-group");
    const overlayEdit = document.querySelector("#overlay-edit");
    const contentEdit = document.querySelector("#content-edit");

    overlayEdit.style.display = "none";
    contentEdit.style.scale = "0";
    contentExcludeGroup.style.scale = "0";
}

//Visualização da senha apertando o olho
function viewPassword() {
    const inputPassword = document.getElementById("password-user-password");
    const eye = document.getElementById("hidden-pass-icon");

    // Ver senha ou esconder senha
    if (inputPassword.type == "password") {

        inputPassword.type = "text";
    }
    else {
        inputPassword.type = "password";
    }

    //Troca o icone do olho
    if (eye.className == "fa fa-eye-slash") {
        eye.className = "fa fa-eye";
    }

    else {
        eye.className = "fa fa-eye-slash";
    }
    }

