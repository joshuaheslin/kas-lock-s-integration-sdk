const net = require('net');

const HOST = '172.20.10.7';
const PORT = 10003;

const client = new net.Socket();

client.connect(PORT, HOST, function () {

    console.log('CONNECTED TO: ' + HOST + ':' + PORT);
    // Write a message to the socket as soon as the client is connected, the server will receive it as message from the client 
    const startByte = Buffer.alloc(1, 0x02)
    const endByte = Buffer.alloc(1, 0x03)

    // REMOTE UNLOCK DOOR "0101" by "ADMIN"
    const buf = Buffer.from('9800O|R0101|UAdmin', "ascii")

    const send = Buffer.concat([startByte, buf, endByte])
    console.log(send)

    client.write(send);

});

// Add a 'data' event handler for the client socket
// data is what the server sent to this socket
client.on('data', async function (data) {

    console.log('DATA: ' + data);
    // Close the client socket completely
    const str = data.toString()
    const res = str.substring(1, str.length - 1)
    console.log(res)

    const arr = res.split('J')
    console.log(arr)

    const obj = JSON.parse(arr[1])
    console.log(obj)

    if (obj.ack === 0) {
        console.log('Command success!')
    } else {
        console.log('Command failed!')
    }

    //client.destroy();

});

// // Add a 'close' event handler for the client socket
client.on('close', function () {
    console.log('Connection closed');
});