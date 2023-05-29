var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Chat/Index')
    .build();

connection.on('ReceiveMessage');

connection.start()
    .catch(error => {
        console.error(error.message);
    });
