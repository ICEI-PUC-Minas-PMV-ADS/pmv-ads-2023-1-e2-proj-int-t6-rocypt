var selectedGroupId = null;


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
function groupPasswordsOn(button) {
    selectedGroupId = button.id;
    var groupId = button.id;

    $.ajax({
        type: 'GET',
        url: '/Painel/ListarSenhasPorGruposId/' + groupId,
        success: function (result) {
            $("#password-zone").html(result);
        }
    });

    var passwords = document.getElementById("mobile-passwords");
    var groups = document.getElementById("mobile-groups");
    var passid = document.getElementsByClassName("btn-style-mobile");


    var newGroupPassButton = document.querySelectorAll("#new-group-pass");

    passid.id = groupId;
    newGroupPassButton.forEach((group) => { group.dataset.id = groupId })


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
    var newGroupPassButton = document.querySelector("#new-group-pass");
    var groupId = newGroupPassButton.dataset.id;
    console.log(groupId);




    const overlayPassword = document.querySelector("#overlay-new-password");
    const contentPassword = document.querySelector("#content-new-password");
    const mainTitle = document.getElementById("popup-title");
    const mainText = document.getElementById("popup-text");
    const groupIdInput = document.querySelector("#id-input");
    
    groupIdInput.value = groupId;

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

function editPasswordOff() {
    const overlayPassword = document.querySelector("#overlay-edit-password");
    const contentPassword = document.querySelector("#content-edit-password");

    overlayPassword.style.display = "none";
    contentPassword.style.scale = "0";
}

//Abrir e fechar popup de editar senha
function editPasswordOn(passId, passName, passEmail, passUserName, passSenha) {
    console.log(passId);
    console.log(passName);
    console.log(passEmail);
    console.log(passUserName);
    console.log(passSenha);

    const overlayPassword = document.querySelector("#overlay-edit-password");
    const contentPassword = document.querySelector("#content-edit-password");
    const mainTitle = document.getElementById("popup-title-edit");
    const mainText = document.getElementById("popup-text-edit");
    const passIdInput = document.querySelector("#pass-id-input");
    const passwordNameInput = document.querySelector("#password-name-input");
    const passwordEmailInput = document.querySelector("#password-email-input");
    const passwordUserInput = document.querySelector("#password-user-input");
    const passwordUserpassInput = document.querySelector("#password-userpass-input");

    overlayPassword.style.display = "flex";
    contentPassword.style.scale = "1";

    mainTitle.innerHTML = "Visualização da senha...";
    mainText.innerHTML = "Pode ser editada...";

    if (passIdInput) {
        passIdInput.value = passId;
    }

    if (passwordNameInput) {
        passwordNameInput.value = passName;
    }

    if (passwordEmailInput) {
        passwordEmailInput.value = passEmail;
    }

    if (passwordUserInput) {
        passwordUserInput.value = passUserName;
    }

    if (passwordUserpassInput) {
        passwordUserpassInput.value = passSenha;
    }

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
// Visualização de senha no cadastro
function viewPassword() {
    const inputPassword = document.getElementById("password");
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
function viewPasswordConfirm() {
    const inputPassword = document.getElementById("password-confirm");
    const eye = document.getElementById("hidden-pass-icon-confirm");

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

function viewPasswordEdit() {
    const inputPassword = document.getElementById("password-userpass-input");
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

function ramdomPassword() {
    let pass = "";
    let charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789!@#";
    for (let contador = 0, n = charset.length; contador < 10; ++contador) {

        pass += charset.charAt(Math.floor(Math.random() * n))
    }
    const passwordEl = document.querySelector("#password-user-password");

    if (passwordEl) {
        passwordEl.value = pass;
    }

}

function ramdomPasswordEdit() {
    let pass = "";
    let charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789!@#";
    for (let contador = 0, n = charset.length; contador < 10; ++contador) {

        pass += charset.charAt(Math.floor(Math.random() * n))
    }
    const passwordEl = document.querySelector("#password-userpass-input");

    if (passwordEl) {
        passwordEl.value = pass;
    }

}

