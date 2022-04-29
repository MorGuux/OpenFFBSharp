# OpenFFBSharp - C# client to interact with an OpenFFBoard

There are two methods of communication to an OpenFFBoard, HID and Serial. Each method has its own benefits and drawbacks, which you may wish to consider. Changing between the two communication methods requires very little code changes.

| Communication | Benefits | Drawbacks | General use case |
| ------------- | -------- | --------- | ---------------- |
| HID | Multiple simultaneous connections | Does not support some commands (help, class lists etc.) | Changing simple board parameters (power, rotation degrees etc.) |
| Serial | Supports all commands and data types | Single connection to one client | More advanced board settings |

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

