
# Board game architecture

## How are your board game build?

#### This board game is built with MVC-Framework, where Models contains all classes that define our objects, Views contain the cshtml-files for showing the output to the user and Controller redirects information between the interaction on the screen and gameenginge logic.
#### We have added a unit-test project, for testing the gameengine-methods.
#### Comments are added in VS to generate API-Documentation, with the run doc.fx- function, as Gameengine Documentation. There can also User stories and this Architecture be found.
#### The Gameengine is built so that the Lobby-, ActiveGame-, User-class can be reused in other games. Our GameSesson-class needs a few alterations with the rules, but is a good base for other projects. Models need small adjustments.
#### Below is a step by step review of the game:

> The game starts with a cookie being set in the HomeController.The StartPage view is returned to the user.
>
> The user enters his Player-Model data, and chooses between Starting A Game, and Joining A Game.
>
 >User Name and Email is stored in Gameengine/User-class.
> 
> If **Start-button** is pressed, the LoginUser-method is called, and sets cookieID as PlayerID and letter "O" as Player.Side.  
>
> A GenerateRandomID-method is then called to set the gameID. 
>
> CreateGame-method is called to create a gamesession-object.   
>
> The player is added to this object and set as player 1 in a PendingGame-array. 
>
> The system redirects to Game-mode and loops through the methods there: the GetSession-method checks for an exisiting game, but since it's NULL, it returns empty.
>
> It loops though an empty WinConditions and into the Writeboard-method where the array of nine boxes is created and then checked that there is an active gamesession awaiting, which it is now.
>
> A Board-object is then created and set to empty strings, instead of NULL, awaiting to be filled by Player-objects clicking on the gameboard.
>
> The HomeController then return us to the Game View and the HTML and CSS pages loads.
>
> The Gameboard appear.
>
>**Player 1 status is now on hold till a new player enters.**

> When **Join-button** is pressed, the FindGame-method is called, User Name and Email is set, cookieID will be PlayerID and letter "X" as Player.Side.
>
> FindGame-method is called that sets the Player 2 as the second player in the PendingGame-array.
>
> Arrayposition[0] is now filled and is removed from the PendingGame-array.
>
> **Player 2 is redirected to the Game View and the GAME CAN BEGIN**.
>
> Player 1 makes his first move. If, for example, button 3 is clicked, the Player-object is set at position 2 in the Board-array, and this cell is blocked from further changes. The letter "O" is marked on the board.
>
> Player 2 makes a buttonclick and the PlayerMove-method is called and checks first with the GetSession-method by the cookieID, which existing game it is a part of.
>
> The Turn-method is called to check if the PlayerID-value is set to "true". In that case the method allows the buttonclick. The method ends with swaping the value to "false" and continues. This is to prevent the same player of making two moves in a row.
>
> The cursor then enters the WinCondition-method to check if the gamesession in this stage has a winning row.
>
> If not, it enters the WriteBoard-method and loops through the Gameboard-array, filling the clicked number in the array with its letter "X". The rest is left empty. The Board-object that was created in the beginning is now getting a box filled.
>
> The HomeControl is now sending us back to the Game View, placing the "X" on the screen for the user, by linking the Gameboard-array to the HTML-buttons.
>
> Player 1 makes his second move and the loop starts again.
>
> If WinConditions are met, the GameSession is redirected to EndGame-method, where it allows the Game-methods to loop one last time to update the opponent a fresh board with a message to the winning player.
>
> GameSession is ended with the cookie expiring.


## Which components does your application consist of?

Three Views:
* StartPage: Where the player enter login data, and choose game.
* Game: Where the game takes place.
* EndGame: Showing game end with a result message.

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

* UnitTest1: Inserted a few tests.

Content:

* Bootstrap.css
* GameBackground.css
* Reset.css
* Site.css
  
