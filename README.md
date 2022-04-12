## C# client to interact with an OpenFFBoard

### HID
Get a list of connected OpenFFBoards
```C#
var boards = await OpenFFBoard.Hid.GetBoardsAsync();
```
then you can declare a new OpenFFBoard object from the first connected board (in this case using HID communications)
```C#
OpenFFBoard.Board openFFBoard = new OpenFFBoard.Hid(boards[0]);
```
then you can connect to the board
```C#
openFFBoard.Connect();
```

Once this initialisation process has been followed, you can now access the board properties.

