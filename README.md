Use the following steps to get starting with building an integration with KAS Lock-S Software.

#### Before you start:

[Contact KAS](https://www.kas.com.au) to order your demo locks for development. You will also need a license key and software download.


#### Setup the equipment:

[Setup the development environment](/INTEGRATION-PACK/Docs/Development-environment-setup.docx)

1. Install the latest version of Lock-S Software
2. Install the latest version of PMS Server
3. [Optional] install the latest version of PMS Client (for RFID card integrations only!)
4. Setup a lock and gateway by following guides
5. Ensure the lock works by swiping a Master card (Lock-S Software + USB RFID card reader)
6. Ensure the gateway is setup by conducting a Remote Unlock in Lock-S Software

#### Now you can start the integration:

1. Connect to PMS Server by TCP/IP through what host it is running on (such as 172.20.10.7) and port 10003 (See code examples)
2. Observe the PMS server commands and conduct the Remote Unlock command you did in above steps
3. Replicate this command to remote unlock the door through your TCP/IP integration. Notice the ’R’ to signify room number [(see documentation)](/INTEGRATION-PACK/Docs). R0101A means Room “0101A”. The room number is a string and the same as you set in above steps
4. Follow documentation on the additional commands and response acknowledgments
5. [node.js sample code](/Nodejs)
6. [C# sample code](/ConsoleApp3)

#### [Optional] RFID card integrations

1. Install “PMS Client”
2. Ensure the PMS Server has the PMS client registered (see photos)
3. Now you can conduct the RFID card commands using your TCP/IP Integration.


#### Notes:
- Lock-S Software, PMS Server and MSSQL must be in same network. 
- Use port forwarding with firewall rules to host your application somewhere else to communicate with the PMS Server for production. 
- OR host your integration locally next to the PMS Server and connect to your own server using HTTPS API. 


### Minimum Required Software Versions:

- Lock-S Software Version:  V11.0 or above
- PMS Server:               V11.0 or above
- PMS Client:               V9.6 or above
