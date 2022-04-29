## C# client to interact with an OpenFFBoard

### HID
Get a list of connected OpenFFBoards
```C#
var boards = await OpenFFBoard.Hid.GetBoardsAsync();
```
then you can declare a new OpenFFBoard object from the first connected board
```C#
OpenFFBoard.Board openFFBoard = new OpenFFBoard.Hid(boards[0]);
```

### Serial
Get a list of connected OpenFFBoards
```C#
var boards = OpenFFBoard.Serial.GetBoards();
```
then you can declare a new OpenFFBoard object from the first connected board
```C#
OpenFFBoard.Board openFFBoard = new OpenFFBoard.Hid(boards[0]);
```

## Initialisation

Once you have declared a board, you can connect to it
```C#
openFFBoard.Connect();
```

Once this initialisation process has been followed, you can now access the board properties.

