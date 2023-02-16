let nextMoveArr;//array to show user for next moves
let currenArr;//array of current state of players
$(() => {
    /* -----Initially Hiding most of the stuf and populating the Grid ------------*/
    PopulateBoard();
    let playe1name = $("#player1-tbx").val();
    let playe2name = $("#player2-tbx").val();
    $("#board-div").hide();
    $("#disc").hide();
    $("hint").hide();

    /* -----Populating most of the stuff and enabling onlclick event on the grid ------------*/
    if (playe1name.length > 0 && playe2name.length > 0) {
        fillBoard();
        $("#disc").show();
        $("#board-div").show();
        $('hint :checkbox').change(function () {
            if ($(this).is(':checked')) {
                Hint();
            } else {
                DrawBalls(currenArr);
            }
        });
        $("#board>div").each((index, item) => {

            $(item).click(() => {
                let X = $(item).attr('locX');
                let Y = $(item).attr('locY');
                MakeMove(X, Y);
                    $("hint").show();
            })
        });
    }

});

/**
 * this function will show the user with hints
 * @param  "No param"
 * @return nothing 
 */
function Hint() {
    for (let i = 0; i < 8; i++) {
        for (let j = 0; j < 8; j++) {
            $("#board>div").each((index, item) => {
                if (nextMoveArr[i][j] == 1) {
                    if ($(item).attr("locX") == i && $(item).attr("locY") == j) {

                        $(item).html(`<p style='margin: 0px; background-image:radial-gradient(#333333 30%, black 70%);width:50px;height:50px ;border-radius:40px' ></p>`);
                    }
                }
                else if (nextMoveArr[i][j] == 2) {
                    if ($(item).attr("locX") == i && $(item).attr("locY") == j) {

                        $(item).html(`<p style='margin: 0px; background-image:radial-gradient(white 30%, #cccccc 70%);width:50px;height:50px ;border-radius:40px' ></p>`);
                    }
                }
                else if (nextMoveArr[i][j] == 3 || nextMoveArr[i][j] == 4) {
                    if ($(item).attr("locX") == i && $(item).attr("locY") == j) {

                        $(item).html(`<p style='margin-top: 47%;margin-left: 47%; background-image:radial-gradient(red 30%, #cccccc 70%);width:10px;height:10px ;border-radius:40px' ></p>`);

                    }
                }

            });
        }
    }
}


/**
  * function will make a grid of 8 columns and 8 rows
 * @param  "No param"
 * @return nothing 
 */
function PopulateBoard() {
    var str = "";
    var id = 0;
    for (let j = 0; j < 8; ++j) {
        for (let i = 0; i < 8; ++i) {
            id++;
            str += `<div id="${id}" locX="${j}" locY="${i}" readonly="readonly"></div>`;

        }
    }
    $("#board").html(str);
}
/**
  * function will make a Draw Balls on the grid
 * @param  array board
 * @return nothing 
 */
function DrawBalls(board) {
    $('#hint').prop('checked', false); // Unchecks it
    for (let i = 0; i < 8; i++) {
        for (let j = 0; j < 8; j++) {

            $("#board>div").each((index, item) => {
                if (board[i][j] == 1) {
                    if ($(item).attr("locX") == i && $(item).attr("locY") == j) {

                        $(item).html(`<p style='margin: 0px; background-image:radial-gradient(#333333 30%, black 70%);width:50px;height:50px ;border-radius:40px' ></p>`);
                    }
                }
                else if (board[i][j] == 2) {
                    if ($(item).attr("locX") == i && $(item).attr("locY") == j) {

                        $(item).html(`<p style='margin: 0px; background-image:radial-gradient(white 30%, #cccccc 70%);width:50px;height:50px ;border-radius:40px' ></p>`);
                    }
                }
                else if (board[i][j] == 0) {
                    if ($(item).attr("locX") == i && $(item).attr("locY") == j) {

                        $(item).html('');
                    }
                }

            });
        }
    }
}

/**
  * function will make a Ajax call on clicked location
 * @param  int x
 * @param  int y
 * @return nothing 
 */
function MakeMove(x, y) {
    let getData = {};
    getData['locX'] = x;
    getData['locY'] = y;
    CallAJAX('php/gameflow.php', getData, 'POST', 'json', fillBoardSuccess, ShowStatusError);
}

/**
  * function will Validate The form
 * @param "nothing"
 * @return nothing 
 */
function ValidateForm() {
    playe1name = $("#player1-tbx").val();
    playe2name = $("#player2-tbx").val();


    if (playe1name.length > 0 && playe2name.length > 0) {
        return true;
    }

    else {
        $("#status").html('Names must be atleast one character ! ');
        return false;
    }
}

/**
 * This is generenic AJAXmake function
 * AJAX! This the minimum set of properties to send
    //url - where to send the request
    //type - GET(select)/POST(update)/PUT(insert)/DELETE(delete) -> this is a REST interface
    //type DEFAULTS to GET
    //data - what data are we sending? MUST MATCH WEB SERVICE SPEC
    //dataType - what response do we want back from the WS? html/json/xml
    //success - callback for successful completion
    //error - callback for error in operation
 * @param  "url, postData, type, dataType, fxnSuccess, fxnError"
 * @return nothing 
 */
function CallAJAX(url, postData, type, dataType, fxnSuccess, fxnError) {
    let ajaxOptions = {}; //init options object

    ajaxOptions['url'] = url;
    ajaxOptions['data'] = postData;
    ajaxOptions['type'] = type;
    ajaxOptions['dataType'] = dataType;
    /*ajaxOptions['success'] = fxnSuccess;
    ajaxOptions['error'] = fxnError;*/
    let concorde = $.ajax(ajaxOptions); //doing the AJAX request, non-blocking
    concorde.done(fxnSuccess);
    concorde.fail(fxnError);
    // concorde.always(alwaysDoThis);
}

/**
 * This function will do an ajax call and will initially hide the status div
 * @param  "No param"
 * @return nothing 
 */
function fillBoard() {
    let getData = {};
    getData['start'] = "start";
    CallAJAX('php/gameflow.php', getData, 'POST', 'json', fillBoardSuccess, ShowStatusError);


}
function fillBoardSuccess(data, response) {
    console.log(data);
    if (data['statusCode'] == "Initial")
        $("#status").html(data['status']);


    currenArr = data.currentBoardState;
    DrawBalls(currenArr);
    if (data.aff) {
        nextMoveArr = data.aff;
    }
    if (data.score) {
        let score = data.score;
        $("#disc").html(`Black : ${score.black} White :${score.white}`);
    }
    if (data.message == 'Invalid') {
        alert('Ooops! Invalid Spot');
    }
    if (data.winner) {
        $("status").html(data.winner);
        if (data.gameOver == "Game Over") {
            alert("Game Already Over");
        }
    }
    if (data.next) {
        $("status").html(data.next);
    }
}
/**
 * This function is success method for showing names of player after ajax call
 * @param  "No param"
 * @return nothing 
 */
function ShowStatusError(ajaxReq, textStatus, errorThrown) {
    console.log('Error : ' + ajaxReq + ' : ' + textStatus + ' : ' + errorThrown);
}