<?
session_start(); //starting session

$_SESSION['count'] = ""; //use to check click count on boxes

/* this method wil show initial status of game only */
ShowStatus();

switchTurn();

/**
 * This function will randomly select one player for first turn
 * @param  "No param"
 * @return "random number either 1 or 2" 
 */
function allotTurn()
{
    return rand(1, 2);
}

/**
 * This method will show symbol of player i.e either 'X' or 'O'
 * Then it will also show name of player and who has alloted with first trun
 * @param  "No param"
 * @return "nothing" 
 */
function ShowStatus()
{
    if (isset($_GET['status'])) {
        if ($_GET['status'] == 'status') {
            $data = new stdClass();
            if ($_SESSION['p1symbol'] == "X") {
                $data->turn = $_SESSION['p1name'] . " is alloted with first turn";
            } else {
                $data->turn = $_SESSION['p2name'] . " is alloted with first turn";
            }
            $data->res = $_SESSION['p1name'] . " = " . $_SESSION['p1symbol'] . " and " . $_SESSION['p2name'] . " = " . $_SESSION['p2symbol'];
            $myJSON = json_encode($data);
            echo $myJSON;
        }
    }
}

/**
 * This method will get location of clicked box and will assign either 1 or 2 at that position 
 * I have choose 1 for 'X' and 2 for '0'
 * in this way i will pass JSON object back to the user to give back symbol,message as well as next turn
 * every ,move will be playe in this method
 * and we will check whether user has win or not
 * @param  "No param"
 * @return "nothing"
 */
function switchTurn()
{
    if (isset($_POST['locX']) && isset($_POST['locY'])) {
        $symbol = "";
        $message = "";
        $winMessage = "";
        $locX = "";
        $locY = "";
        $locX = strip_tags($_POST['locX']);
        $locY = strip_tags($_POST['locY']);


        //first check if game already finished but user keep trying to click on the boxes
        if (CheckWin()) {
            $data = new stdClass();
            $data->message = "Game Already Finished";
            $myOBJ = json_encode($data);
            echo $myOBJ;
            die();
        }
        //else the game flow
        else {
            //check for if the location has been already filled by either X or O
            if ($_SESSION['game'][$locX][$locY] == '1' || $_SESSION['game'][$locX][$locY] == '2') {
                $data = new stdClass();
                $data->error = "Position Already Marked Select Other.";
                $myOBJ = json_encode($data);
                echo $myOBJ;
                die();
            }
            //updating count of real click
            if (isset($_POST['click'])) {
                $data = new stdClass();
                $_SESSION['count'] = $_POST['click'];

                //if no one is winner 
                if ($_SESSION['count'] >= 9 && CheckWin() == false) {

                    $winMessage = "CATS ! Match Ties No Winner .";
                }
            }
            //inserting in Array
            if ($_SESSION['game'][$locX][$locY] == '') {
                $_SESSION['game'][$locX][$locY] = $_SESSION['turn'];
            }
            //swapping turn and updating message likewise
            if ($_SESSION['turn'] == 1) {
                $symbol = $_SESSION['p1symbol'];
                $message = "It is " . $_SESSION['p2name'] . "'s turn .";
                error_log($_SESSION['p1symbol']);
                $_SESSION['turn'] = 2;
            } else {

                $symbol = $_SESSION['p2symbol'];
                error_log($_SESSION['p2symbol']);
                $message = "It is " . $_SESSION['p1name'] . "'s turn .";
                $_SESSION['turn'] = 1;
            }

            //checking for the winner
            if (CheckWin()) {

                $winMessage = $_SESSION['winner'] . " wins at " . $_SESSION['line'];
            }

            //passing object to the user
            $data = new stdClass();
            $data->symbol = $symbol;
            $data->message = $message;
            $data->locX = $locX;
            $data->locY = $locY;
            $data->winMessage = $winMessage;
            $data->turns = $_SESSION['count'];
            $data->winner = $_SESSION['winner'];
            $data->array = $_SESSION['game'];
            $myOBJ = json_encode($data);
            echo $myOBJ;
            die();
        }
    }
}
/**
* This method will basically check for the win in all direction and will decide the winner and will also tell location at which user win
 * @param  "No param"
 * @return bool
 */
function CheckWin()
{
    $board = $_SESSION['game'];
    // check rows
    for ($i = 0; $i < 3; $i++) {
        if ($board[$i][0] == $board[$i][1] && $board[$i][1] == $board[$i][2] && $board[$i][0] != '' && $board[$i][1] != '' && $board[$i][2] != '') {
            if ($board[0][0] == $board[0][1] && $board[0][1] == $board[0][2]) {
                $_SESSION['line'] = "Top Line";
            } else if ($board[1][0] == $board[1][1] && $board[1][1] == $board[1][2]) {
                $_SESSION['line'] = "Center Line";
            } else if ($board[2][0] == $board[2][1] && $board[2][1] == $board[2][2]) {
                $_SESSION['line'] = "Bottom Line";
            }

            if ($board[0][0] == "1") {
                $_SESSION['winner'] = $_SESSION['p1name'];
            } else {
                $_SESSION['winner'] = $_SESSION['p2name'];
            }
            return true;
        }


    }
    // check columns
    for ($i = 0; $i < 3; $i++) {
        if ($board[0][$i] == $board[1][$i] && $board[1][$i] == $board[2][$i] && $board[0][$i] != '' && $board[1][$i] != '' && $board[2][$i] != '') {
            if ($board[0][1] == $board[1][1] && $board[2][1] == $board[1][1]) {
                $_SESSION['line'] = "Center Line";

            } else if ($board[0][0] == $board[1][0] && $board[1][0] == $board[2][0]) {
                $_SESSION['line'] = "Left Line";
            } else if ($board[0][2] == $board[1][2] && $board[1][2] == $board[2][2]) {
                $_SESSION['line'] = "Right Line";
            }


            if ($board[0][0] == "1") {
                $_SESSION['winner'] = $_SESSION['p1name'];
            } else {
                $_SESSION['winner'] = $_SESSION['p2name'];
            }
            return true;
        }
    }
    // check diagonals
    if ($board[0][0] == $board[1][1] && $board[1][1] == $board[2][2] && $board[0][0] != '' && $board[1][1] != '' && $board[2][2] != '') {
        $_SESSION['line'] = "Diagnol Line";
        if ($board[0][0] == "1") {
            $_SESSION['winner'] = $_SESSION['p1name'];
        } else {
            $_SESSION['winner'] = $_SESSION['p2name'];
        }
        return true;
    }
    if ($board[0][2] == $board[1][1] && $board[1][1] == $board[2][0] && $board[0][2] != '' && $board[1][1] != '' && $board[2][0] != '') {
        $_SESSION['line'] = "Diagnol Line";
        if ($board[0][2] == "1") {
            $_SESSION['winner'] = $_SESSION['p1name'];
        } else {
            $_SESSION['winner'] = $_SESSION['p2name'];
        }
        return true;
    }
    return false;
}