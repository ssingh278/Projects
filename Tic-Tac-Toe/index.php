<?
require_once './php/gameFlow.php';

/* starting session */
session_start();

/* storing session variable */
$_SESSION['p1name'] = 'Unknown';
$_SESSION['p2name'] = 'Unknown';
$_SESSION['turn'] = allotTurn();
$_SESSION['p1symbol'] = "";
$_SESSION['p2symbol'] = "";
$_SESSION['line'] = "";
$_SESSION['winner'] = "";
if ($_SESSION['turn'] == 1) {
    $_SESSION['p1symbol'] = "X";
    $_SESSION['p2symbol'] = "O";
} else {
    $_SESSION['p1symbol'] = "O";
    $_SESSION['p2symbol'] = "X";
}
$_SESSION['game'] = array(
    array('', '', ''),
    array('', '', ''),
    array('', '', '')
);
if (isset($_GET['p1name']) && strlen($_GET['p1name']) > 0 && isset($_GET['p2name']) && strlen($_GET['p2name']) > 0) {
    $_SESSION['p1name'] = strip_tags($_GET['p1name']);
    $_SESSION['p2name'] = strip_tags($_GET['p2name']);
}


if (isset($_GET['exit']) ) {
    session_unset();
    session_destroy();
}

?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tic Tac Toe</title>
    <link rel="stylesheet" href="../ICA02/style/style.css" type="text/css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="./js/TicTacToe.js"></script>
</head>

<body>
    <h1 class="heading">Sharry Singh - Tic Tac Toe</h1>
    <section>
        <div id="form-div">
            <form action="index.php" method="get" onsubmit="return ValidateForm()">
                <h3 id="status">Enter your name below :</h3>
                <input type="text" id="player1-tbx" placeholder="Player one name here !" name="p1name" value="<? if ($_SESSION['p1name'] != 'Unknown')
                                                                                                                    echo $_SESSION['p1name']; ?>">
                <input type="text" id="player2-tbx" placeholder="Player two name here !" name="p2name" value="<? if ($_SESSION['p2name'] != 'Unknown')
                                                                                                                    echo $_SESSION['p2name'];
                                                                                                                ?>">
                <input type="submit" id="playGame" value="New Game" name="play">
                <input type="submit" value="Quit Game" name="exit">
                <div id="status-turn"></div>
                <div id="error"></div>
            </form>

        </div>
        <hr>
        <div id="board-div">
            <div id="board">
                <input type="text" name="" id="1" locX="0" locY="0" readonly="readonly">
                <input type="text" name="" id="2" locX="0" locY="1" readonly="readonly">
                <input type="text" name="" id="3" locX="0" locY="2" readonly="readonly">
                <input type="text" name="" id="4" locX="1" locY="0" readonly="readonly">
                <input type="text" name="" id="5" locX="1" locY="1" readonly="readonly">
                <input type="text" name="" id="6" locX="1" locY="2" readonly="readonly">
                <input type="text" name="" id="7" locX="2" locY="0" readonly="readonly">
                <input type="text" name="" id="7" locX="2" locY="1" readonly="readonly">
                <input type="text" name="" id="9" locX="2" locY="2" readonly="readonly">

            </div>
        </div>
    </section>
    <footer>
        @ Sharry Singh
        <br>
        <script>
            document.write("Last Access: " + document.lastModified);
        </script>
    </footer>
</body>

</html>