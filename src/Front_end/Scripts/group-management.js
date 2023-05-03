function createPopup() {
    const overlay = document.querySelector(".overlay");
    const content = document.querySelector(".content");

    overlay.style.display = "block";
    content.style.scale = "1";
}

function createGroup () {

    const userInput = document.querySelector(".user-input");
    const groupTemplate = document.querySelector(".group-template");
    
    var groupCreate = groupTemplate.cloneNode(true);
    groupCreate.style.display = "flex";

    const groupName = userInput.value;
    groupCreate.querySelector("#group-name").textContent = groupName;
    groupCreate.querySelector("#group-name").name = groupName;
    
    groupCreate.classList.remove("group-template")
    groupCreate.classList.add("user-group")

    document.querySelector(".group-zone").appendChild(groupCreate);

    if (groupName == "") {
    
        var groupIds = document.querySelectorAll(".user-group");

        for (var i = 0; i < groupIds.length; i++) {
             groupIds[i].id = "Novo Grupo-" + i;
             groupCreate.querySelector("#group-name").textContent = "Novo Grupo - " + (i + 1) ;

        }
    }
    else {
        const groupName = userInput.value;
        groupCreate.id = groupName;
    }
    
    const overlay = document.querySelector(".overlay");
    const content = document.querySelector(".content");

    overlay.style.display = "none";
    content.style.scale = "0";
    
}
function createClose() {

    const overlay = document.querySelector(".overlay");
    const content = document.querySelector(".content");
    const userInput = document.querySelector(".user-input");

    overlay.style.display = "none";
    content.style.scale = "0";
    
    userInput.value = "";
}


function editPopup () {

    const overlayEdit = document.querySelector("#overlay-edit");
    const contentEdit = document.querySelector("#content-edit");

    overlayEdit.style.display = "flex";
    contentEdit.style.scale = "1";
}
function editGroup () {

    const userInput = document.querySelector(".user-input");

    const groupName = userInput.value;
    groupCreate.querySelector("#group-name").textContent = groupName;
    groupCreate.querySelector("#group-name").name = groupName;

    
    if (groupName == "") {
        groupCreate.querySelector("#group-name").textContent = "New Group";
    }

}
function deleteGroup () {

}
function editClose () {
    const overlayEdit = document.querySelector("#overlay-edit");
    const contentEdit = document.querySelector("#content-edit");

    overlayEdit.style.display = "none";
    contentEdit.style.scale = "0";
}