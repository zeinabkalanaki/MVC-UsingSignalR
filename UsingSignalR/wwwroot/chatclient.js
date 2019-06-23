const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub") //from startup
    .build();

connection.on("ReceivedMessage", (user, message) => {

    const msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    const encodedMsg = user + " says " + msg;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    li.className = "text-success";
    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(err => console.error(err.toString()));

document.getElementById("sendButton").addEventListener("click", event => {
    const user = document.getElementById("userInput").value;
    const message = document.getElementById("messageInput").value;
    //SendMessage نام متدی در هاب که می خواهیم آنرا صدا بزنیم
    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});