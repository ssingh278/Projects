<?
session_start();
initialGameSetup(); //if game is initially start

//if user response is getting
if (isset($_POST['locX']) && isset($_POST['locY'])) {
    $x = strip_tags($_POST['locX']);
    $y = strip_tags($_POST['locY']);
    clickedSquare($x, $y);
}

//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will send inital message to the user 
//params  =>No params
//Returns =>Nothing 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function initialGameSetup()
{
    if (isset($_POST['start']) && strlen($_POST['start']) > 0) {
        $str = strip_tags($_POST['start']);
        if ($str == 'start') {
            $data = new stdClass(); //json object
            $next = "";
            if ($_SESSION['turn'] == 1) {
                $next = "Black's turns";
            } else if ($_SESSION['turn'] == 2) {
                $next = "White's turns";
            }
            nextspot(1);
            $data->aff = $_SESSION['affect'];
            $data->next = $next;
            $data->currentBoardState = $_SESSION['board'];
            $data->status = "Game between " . $_SESSION['p1name'] . "<span style='font-size:30px;'> &#x25CF;</span> and " . $_SESSION['p2name'] . "<span style='color:white;font-size:30px;'> &#x25CF;</span>";
            $data->statusCode = "Initial";
            $myOBJ = json_encode($data);
            echo $myOBJ;
            die();
        }
    }
}

//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will get User X and Y location 
//           and will send response back to the user. 
//params  => $row:Xlocation  , $column :Ylocation
//Returns =>Nothing 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function clickedSquare($row, $column)
{
    //if that posotion has not been already took up by either of the user
    if ($_SESSION['board'][$row][$column] == 0) {
        //to check that spot is clicable or not
        if (canClickSpot($row, $column, $_SESSION['turn']) == true) {
            $affectedDics = array(); //array to store affected rows after clicked

            //if turn is of first player
            if ($_SESSION['turn'] == 1) {
                $_SESSION['board'][$row][$column] = 1; //putting disc at that location
                $affectedDics = getAffectedDiscs($row, $column, $_SESSION['turn']); //getting back all disc that needs to be flipped
                flipDiscs($affectedDics); //flipping all the discs
                nextspot(2); //checking for the next spot available for other player
                if (CheckFornext(2)) {
                    $_SESSION['turn'] = 2; //only changing turn if spot available else passing on to the current again
                }

            } else { //same as above
                $_SESSION['board'][$row][$column] = 2;
                $affectedDics = getAffectedDiscs($row, $column, $_SESSION['turn']);
                flipDiscs($affectedDics);
                nextspot(1);
                if (CheckFornext(1)) {
                    $_SESSION['turn'] = 1;
                }
            }
            //after inserting discs checking for the win
            Win("");

            //else returning back result to the response
            Result();

        } else {

            Invalid();

        }
    } else {
        Win("Game Over");
        Invalid();

    }
}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will return user back the response for valid move. 
//params  => nothing
//Returns =>Nothing 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function Result()
{
    //getting total score
    $score = TotalScore();
    $data = new stdClass(); //json object
    $next = "";
    if ($_SESSION['turn'] == 1) {
        $next = "Black's turns";
        nextspot(1); //making array for hints
    } else if ($_SESSION['turn'] == 2) {
        $next = "White's turns";
        nextspot(2);
    }
    $data->next = $next;
    $data->currentBoardState = $_SESSION['board'];
    $data->score = $score;
    $data->aff = $_SESSION['affect'];
    $myOBJ = json_encode($data);
    echo $myOBJ;
    die();
}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will return user back the response for inValid move. 
//params  => nothing
//Returns =>Nothing 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function Invalid()
{
    $data = new stdClass(); //json object
    $data->currentBoardState = $_SESSION['board'];
    $data->message = "Invalid";
    $myOBJ = json_encode($data);
    echo $myOBJ;
    die();
}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will return user back the response for if someone wins. 
//params  => nothing
//Returns =>Nothing 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function Win($gameOver)
{
    nextspot(1);
    if (CheckFornext(1) == false) {
        nextspot(2);
        if (CheckFornext(2) == false) {
            $score = TotalScore();
            $winner = "";
            if ($score->black > $score->white) {
                $winner = $_SESSION['p1name'] . " wins with " . $score->black . " Discs";
            } else {
                $winner = $_SESSION['p2name'] . " wins with " . $score->white . " Discs";
            }
            $data = new stdClass(); //json object
            $data->score = $score;
            $data->currentBoardState = $_SESSION['board'];
            $data->aff = $_SESSION['affect'];
            $data->gameOver = $gameOver;
            $data->winner = $winner;
            $data->message = "someone wins";
            $myOBJ = json_encode($data);
            echo $myOBJ;
            die();
        }

    }
}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will return the Total score. 
//params  => nothing
//Returns =>Object containing white and black score 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function TotalScore()
{
    $black = 0;
    $white = 0;
    for ($i = 0; $i < 8; $i++) {
        for ($j = 0; $j < 8; $j++) {

            $currentState = $_SESSION['board'][$i][$j];
            if ($currentState == 1)
                $black += 1;
            if ($currentState == 2)
                $white += 1;
        }
    }
    $obj = new stdClass();
    $obj->black = $black;
    $obj->white = $white;
    return $obj;
}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will return array of possible next move for the curremt players turn 
//params  => $current : current player turn
//Returns =>Nothing 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function nextspot($current)
{
    $aff = $_SESSION['board'];
    for ($i = 0; $i < 8; $i++) {
        for ($j = 0; $j < 8; $j++) {

            $currentState = $_SESSION['board'][$i][$j];
            if ($currentState == 0 && canClickSpot($i, $j, $current)) {
                if ($current == 1) {

                    $aff[$i][$j] = 3;
                }
                if ($current == 2) {

                    $aff[$i][$j] = 4;
                }

            }
        }
    }
    $_SESSION['affect'] = $aff; //session variable for the future moves
}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will tell either valid move is available for the next user or not 
//params  => $turn : current player turn
//Returns =>return true or false 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function CheckFornext($turn)
{
    for ($i = 0; $i < 8; $i++) {
        for ($j = 0; $j < 8; $j++) {

            $currentState = $_SESSION['affect'][$i][$j];
            if ($turn == 1) {
                if ($currentState == 3) {
                    return true;
                }
            } else if ($turn == 2) {
                if ($currentState == 4) {
                    return true;
                }
            }

        }
    }
    return false;

}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will check wheter the spot is clickable or not 
//params  => $row,$column,$cturn:turn of current player
//Returns =>return true or false 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function canClickSpot($row, $column, $cturn)
{
    $affectedDiscs = getAffectedDiscs($row, $column, $cturn);
    if (count($affectedDiscs) == 0)
        return false;
    else
        return true;
}

//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will change color of the discs as per user response 
//params  => $affectedDiscs : array containing object of the rows and column that need to be changed
//Returns =>Nothing 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function flipDiscs($affectedDics)
{
    for ($i = 0; $i < count($affectedDics); $i++) {
        $spot = $affectedDics[$i];
        if ($_SESSION['board'][$spot->row][$spot->column] == 1) {
            $_SESSION['board'][$spot->row][$spot->column] = 2;
        } else {
            $_SESSION['board'][$spot->row][$spot->column] = 1;
        }
    }
}
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
//Des     => This function will check in all 8 direction and will return affected rows
//           and column that can be chnage to the other player color
//params  => $row,$column,$cturn:turn of current player
//Returns =>return Affected object of rows and column 
//||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
function getAffectedDiscs($row, $column, $cturn)
{
    $affectedDics = array(); //array to store all the rows and column object

    //right
    $couldBeAffected = array();
    $columnIterator = $column;

    while ($columnIterator < 7) {
        $columnIterator = $columnIterator + 1;

        $valueAtSpot = $_SESSION['board'][$row][$columnIterator];


        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {

                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($row);
            $discLocation->column = (int) ($columnIterator);
            array_push($couldBeAffected, $discLocation);
        }
    }


    //left
    $couldBeAffected = array();
    $columnIterator = $column;

    while ($columnIterator > 0) {
        $columnIterator = $columnIterator - 1;

        $valueAtSpot = $_SESSION['board'][$row][$columnIterator];


        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {

                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($row);
            $discLocation->column = (int) ($columnIterator);
            array_push($couldBeAffected, $discLocation);
        }
    }

    //above
    $couldBeAffected = array();
    $rowIterator = $row;

    while ($rowIterator > 0) {
        $rowIterator = $rowIterator - 1;

        $valueAtSpot = $_SESSION['board'][$rowIterator][$column];


        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {

                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($rowIterator);
            $discLocation->column = (int) ($column);
            array_push($couldBeAffected, $discLocation);
        }
    }


    //below
    $couldBeAffected = array();
    $rowIterator = $row;

    while ($rowIterator < 7) {
        $rowIterator = $rowIterator + 1;

        $valueAtSpot = $_SESSION['board'][$rowIterator][$column];


        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {

                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($rowIterator);
            $discLocation->column = (int) ($column);
            array_push($couldBeAffected, $discLocation);
        }
    }

    //down right
    $couldBeAffected = array();
    $rowIterator = $row;
    $columnIterator = $column;

    while ($rowIterator < 7 && $columnIterator < 7) {
        $rowIterator = $rowIterator + 1;
        $columnIterator = $columnIterator + 1;

        $valueAtSpot = $_SESSION['board'][$rowIterator][$columnIterator];


        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {

                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($rowIterator);
            $discLocation->column = (int) ($columnIterator);
            array_push($couldBeAffected, $discLocation);
        }
    }


    //down left
    $couldBeAffected = array();
    $rowIterator = $row;
    $columnIterator = $column;

    while ($rowIterator < 7 && $columnIterator > 0) {
        $rowIterator = $rowIterator + 1;
        $columnIterator = $columnIterator - 1;

        $valueAtSpot = $_SESSION['board'][$rowIterator][$columnIterator];


        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {

                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($rowIterator);
            $discLocation->column = (int) ($columnIterator);
            array_push($couldBeAffected, $discLocation);
        }
    }

    //up left
    $couldBeAffected = array();
    $rowIterator = $row;
    $columnIterator = $column;
    while ($rowIterator > 0 && $columnIterator > 0) {
        $rowIterator = $rowIterator - 1;
        $columnIterator = $columnIterator - 1;
        $valueAtSpot = $_SESSION['board'][$rowIterator][$columnIterator];
        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {
                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($rowIterator);
            $discLocation->column = (int) ($columnIterator);
            array_push($couldBeAffected, $discLocation);
        }
    }

    //up right
    $couldBeAffected = array();
    $rowIterator = $row;
    $columnIterator = $column;
    while ($rowIterator > 0 && $columnIterator < 7) {
        $rowIterator = $rowIterator - 1;
        $columnIterator = $columnIterator + 1;
        $valueAtSpot = $_SESSION['board'][$rowIterator][$columnIterator];
        if ($valueAtSpot == 0 || $valueAtSpot == $cturn) {
            if ($valueAtSpot == $cturn) {
                $affectedDics = array_merge($affectedDics, $couldBeAffected);
            }
            break;
        } else {
            $discLocation = new stdClass();
            $discLocation->row = (int) ($rowIterator);
            $discLocation->column = (int) ($columnIterator);
            array_push($couldBeAffected, $discLocation);
        }
    }
    return $affectedDics;
}