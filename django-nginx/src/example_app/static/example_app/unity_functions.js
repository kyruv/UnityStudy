function disable_unity() {
    console.log("disable unity");
    var canvas = document.getElementById("unity-canvas");
    canvas.style.display = "none";
    myGameInstance.SendMessage("BackendLogger", "PauseUnity");
}

function enable_unity() {
    console.log("enable_unity");
    var canvas = document.getElementById("unity-canvas");
    canvas.style.display = null;
    myGameInstance.SendMessage("BackendLogger", "UnpauseUnity");
}