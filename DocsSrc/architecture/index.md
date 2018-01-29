# Board game architecture

* How are your board game build?


* Which components does your application consist of?

Two (three/four) Views:
* StartPage: Where the player enter login data, and choose game.
* Game: Where the game takes place.
* TOC:Links to documentation. NOT DONE YET.
* EndPage: NOT DONE YET.

Two Models:
* Player: Contains Name and Email.
* Board: Contains GameID, Cells, Player and Win

One Controller:
* HomeController: Contains all links between gameenging and view.

One Gameengine:

* ActiveGame: Method that returns GameSession depending on cookie value:

* GameSession: 
  * Turn: Method for Switching active player.
  * WriteBoard: Method that writes GameBoard state to view.
  * WinConditions: Method that checks if winning conditions are met.
  * GenerateRandomGameID: Method that generates random GameID.
  
* Lobby:
  * CreateGame: Creates new game.
  * FindGame: Finds pending game.
  * GetSession: Finds GameSession object.
  
* Class User: Contains Name, PlayerID, Cell, Email.

Gameengine Tests:

* UnitTest1: NOT FINISHED YET.

Content:

* 
  
