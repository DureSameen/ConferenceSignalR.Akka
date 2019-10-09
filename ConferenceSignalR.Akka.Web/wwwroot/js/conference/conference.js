"use strict";

var connection = new signalR.HubConnectionBuilder().configureLogging(signalR.LogLevel.Information).withUrl("/conferenceHub").build();

//Disable send button until connection is established
document.getElementById("joinButton").disabled = true;

connection.on("UserJoined", (user)=> {
   
    var encodedMsg = user.userName;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("usersList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("joinButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("joinButton").addEventListener("click", function (event) {
    var userName = document.getElementById("userInput").value;
  
    connection.invoke("JoinConference", userName).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});