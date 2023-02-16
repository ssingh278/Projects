<?
require_once 'php/gameflow.php';//brain file of game

session_start();
$_SESSION['p1name'] = 'Unknown';
$_SESSION['p2name'] = 'Unknown';
$_SESSION['gameOver'] = false;
$_SESSION['turn']=1;
$_SESSION['affect'] ;

//checking for the valid names
if (isset($_GET['p1name']) && strlen($_GET['p1name']) > 0 && isset($_GET['p2name']) && strlen($_GET['p2name']) > 0) {
    $_SESSION['p1name'] = strip_tags($_GET['p1name']);
    $_SESSION['p2name'] = strip_tags($_GET['p2name']);
}

//if user click exit
if (isset($_GET['exit'])) {
    session_unset();
    session_destroy();
}

//array of 8 columns and 8 rows
$_SESSION['board'] = array();
for ($i = 0; $i < 8; $i++) {
    for ($j = 0; $j < 8; $j++) {
        $_SESSION['board'][$i][$j] = 0;
    }
}
//initial whites
$_SESSION['board'][3][3]=2;
$_SESSION['board'][4][4]=2;

//initial black
$_SESSION['board'][3][4]=1;
$_SESSION['board'][4][3]=1;

?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Othello</title>
    <link rel="stylesheet" href="./style/style.css" type="text/css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="./js/code.js"></script>
</head>

<body>
    <h1 class="heading">Sharry Saini - Othello</h1>
    <section>
        <div id="form-div">
            <form action="index.php" method="get" onsubmit="return ValidateForm();">
                <h3 id="status">Enter your name below :</h3>
                <status></status>
                <input type="text" id="player1-tbx" placeholder="Player one name here !" name="p1name"
                    value="<? if ($_SESSION['p1name'] != 'Unknown')
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


            </div>
        </div>
    </section>
    <hint ><input type="checkbox"  id="hint" >Hint ?</hint>
    <aside id="disc">Black : 2 White :2</aside>
    <footer>
        @ Sharry Saini
        <br>
        <script>
            document.write("Last Access: " + document.lastModified);
        </script>
    </footer>
</body>

</html>