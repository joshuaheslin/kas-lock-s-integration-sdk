Use the following steps to get started with building an integration with KAS Lock-S Software.

#### Before you start:

[Contact KAS](https://www.kas.com.au) to order your demo locks for development. You will also need a license key and software download link from KAS.


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
2. Observe the PMS Server commands and conduct the Remote Unlock command you did in above steps
3. Replicate this command to remote unlock the door through your TCP/IP integration. Notice the ’R’ to signify room number [(see documentation)](/INTEGRATION-PACK/Docs). R0101A means Room “0101A”. The room number is a string which is the string which was set inside the Lock-S Software during room setup.
4. Follow documentation on the [additional commands](/INTEGRATION-PACK/Docs) and response acknowledgments.
5. [node.js sample code](/Nodejs)
6. [C# sample code](/ConsoleApp3)

#### [Optional] RFID card integrations

1. Install “PMS Client”
2. Ensure the PMS Server has the PMS client registered (see photos)
3. Now you can conduct the RFID card commands using your TCP/IP Integration.
4. When you send the packets to the PMS Server, it will forward the packets to the PMS Client and program the card. Please ensure you put a blank card on the encoder at this time.
5. Can only program guest cards through PMS interface at this time.

#### Overview Block Diagram:




#### Notes:
- Lock-S Software, PMS Server and MSSQL must be in same network (on the same computer)
- KAS normally setup the Lock-S Software, MSSQL, PMS Server on the customers dedicated computer and sets up the doors
- It is now up to you to integrate with the solution, here are some options for integration:
  1. Use port forwarding with firewall rules to host your application somewhere else to communicate with the PMS Server for production.
  2. OR host your integration locally next to the PMS Server as a PC app and connect to your own server using HTTPS API. 
  3. OR see cloud connection option below...

#### Minimum Required Software Versions:

- Lock-S Software Version:  V11.0 or above
- PMS Server:               V11.0 or above
- PMS Client:               V9.6 or above


#### Additional Supporting Docs

[Support Knowledge Base](support.kas.com.au)


#### Have questions?

1. First step: [ask KAS](support.kas.com.au) - they can assist with demo lock setup and all things Lock-S Software & PMS server.
2. Second step: [create an issue on this repo](https://github.com/joshuaheslin/kas-lock-s-integration-sdk/issues) and the contributor will endeavour to answer it.


#### Final words

End of instructions to build your own TCP/IP connection interface to Lock-S Software.

<hr>

## *NEW* PMS-SDK Cloud Connector App:

Want an easier way to integrate with Lock-S Software? Continue reading...