
# Board game architecture

* How are your board game build?

The game starts with a cookie being set in the HomeController.The StartPage view is returned to the user.
The user enters his Player-Model data, and chooses between Starting A Game, and Joining A Game.
User Name and Email is stored in Gameengine/User-class.

>  If **Start-button** is pressed, the LoginUser-method is called, and sets cookieID as PlayerID and letter "O" as Player.Side.  
> A GenerateRandomID-method is then called to set the gameID. CreateGame-method is called to create a gamesession-object.   
> The player is added to this object and set as player 1 in a PendingGame-array. His status is now on hold till a new player enters.

> If **Join-button** is pressed, the FindGame-method is called, User Name and Email is set, cookieID will be PlayerID and letter "X" as Player.Side.
> FindGame-method is called that sets the Player 2 as the second player in the PendingGame-array. Arrayposition[0] is now filled and is removed from the PendingGame-array.

Player 2 is redirected to the Game View and the **game can begin**.
Player 1 makes his first move. If button 3 is clicked, the Player-object is set at position 2 in the Board-array, and this cell is blocked from further changes.
A new button is clicked and the PlayerMove-method is called and checkes first with the GetSession-method by the cookieID, which existing game it is a part of.
The Turn-method is called to check if the PlayerID-value is set to "true". In that case the method allows the buttonclick. The method ends with swaping the value to "false" and continues. This is to prevent the same player to make two moves in a row.
The cursor then enters the WinCondition-method to check if the gamesession in this stage has a winning row.
If not, it enters the WriteBoard-method and displays the move on the screen. THEN IT GOES THROUGH THE WRITEBOARD AGAIN AND UPDATES THE HTML PAGE SO THAT THE MOVE CAN BE VISIBLE TO THE OPPONENT TOO. ??
A new buttonclick is made the loop goes back to row 18.




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
  
