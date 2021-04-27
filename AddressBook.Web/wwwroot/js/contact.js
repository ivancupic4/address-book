
var connection = new signalR.HubConnectionBuilder().withUrl("/contactHub").build();

connection.on("ReceiveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    var li = document.createElement("li");
    li.textContent = msg;

    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});
