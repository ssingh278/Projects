let count = 0;
$(document).ready(() => {
    let playe1name = $("#player1-tbx").val();
    if (playe1name.length > 0) {
        PreStuff();
        $("#board>input").each((index, item) => {
            $(item).click(() => {
                let X = $(item).attr('locX');
                let Y = $(item).attr('locY');
                count++;
                let getData = {};
                getData['locX'] = X;
                getData['locY'] = Y;
                getData['click'] = count;

                CallAJAX('./php/gameFlow.php', getData, 'POST', 'json', markLocation, ShowStatusError);

            })
        });

    }

});

/**
 * This function will do an ajax call and will initially hide the status div
 * @param  "No param"
 * @return nothing 
 */
function PreStuff() {
    $("#status-turn").hide();
    let getData = {};
    getData['status'] = "status";
    CallAJAX('./php/gameFlow.php', getData, 'GET', 'json', ShowStatus, ShowStatusError);


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
 * This function is success method for showing names of player after ajax call
 * @param  "No param"
 * @return nothing 
 */
function ShowStatus(data, response) {
    console.log(data);
    let playe1name = $("#player1-tbx").val();
    let playe2name = $("#player2-tbx").val();

    if (playe1name.length > 0 && playe2name.length > 0) {
        $("#status").html(data['res']);
        $("#status-turn").show();
        $("#status-turn").html(data['turn']);
        $("#player1-tbx").attr('readonly', 'readonly');
        $("#player2-tbx").attr('readonly', 'readonly');
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

function markLocation(data, response) {
    console.log(data);
    $("#status-turn").html(data['message']);
    $("#board>input").each((index, item) => {
        let X = $(item).attr('locX');
        let Y = $(item).attr('locY');

        if (data['locX'] == X && data['locY'] == Y) {

            if (data['symbol'] == "X") {
                $(item).css('color', "cadetblue");
            }
            else {
                $(item).css('color', "chartreuse");
            }
            if (data['winMessage']) {
                $("#status-turn").css("color", "green");
                $("#status-turn").html(data['winMessage']);
                $("#error").css('display',"none");
            }
            $(item).val(data['symbol']);
            $("#error").hide();
        }
        if (data['error']) {
            $("#error").show();
            $("#error").html(data['error']);
        }
    });

}


function ValidateForm() {

    playe1name = $("#player1-tbx").val();
    playe2name = $("#player2-tbx").val();

    if (playe1name.length > 0 && playe2name.length > 0) {
        return true;
    }
    else {
        $("#status").html('Names must be atleast one charachter ! ');
        return false;
    }
}
