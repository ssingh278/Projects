///////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////Author : Sharry Singh ////////////////////////////////////////////////
///////////////////////////////////////Email : Singh21Sharry@gmail.com/////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////

let count = 0;//for player turns
let count2 = 0;//count if player already cross go
let totalRnumber;//total number appera on Dice
let player_1_pic;//pic for player 1
let player_2_pic;//pic for player 2
let player_1_pos = 0;//current player 1 position
let player_2_pos = 0;//current player 2 position 
let suiteList;//array of all suites(sections)
let timer;//timer for animation
let currentpos_Player1 = 0;//for storing current player 1 position and use as counter
let currentpos_Player2 = 0;//for storing current player 2 position and use as counter

let TotalMoney_P1 = 3000;//initial total money for P1
let TotalMoney_P2 = 3000;//nitial total money for P2


let bgColor_P1;//background color for P1
let bgColor_P2;//background color for P2


let RollDice_Btn;//roll dice button

//array need to store property hold by players and use it as for 
//increasing rent as number of times player land opn it
let Player1_rent_Holder=new Array();
let Player2_rent_Holder=new Array();

//array for displaying message to user when lend on comunity chest or chance
const takeAChanceText = ["second Place in Beauty Contest: $10", "Bank Pays You Dividend of $50",
    "Repair your Properties. You owe $250", "Speding Fine: $15",
    "Holiday Fund Matures: Receive $100", "Pay Hospital Fees: $100"];

//array for money to user when lend on comunity chest or chance
const takeAChanceMoney = [10, 50, -250, -15, 100, -100];


//window on load function
window.onload = function () {


    //preloading all images and text when page loads
    PreLoad();

    //initial position of players on load
    PlayerPosition();


    //creating border on load for first player
    document.querySelector("#picplayer1").setAttribute("style", "border: 4px red dotted;");


    /*this method will change dice pic as well as player border as well as further calls method to perform money calculations*/
    this.document.querySelector("#RollDice").onclick = GenerateAndChange;

}

/*------------------------------------------------------------------------------------------------------------------------*/
/*--------------------------------function to genrate random number and change image and border-----------------------------------*/

function GenerateAndChange() {

    //if player 1 has no money
    if(TotalMoney_P1<=0)
    {
        alert('Player 1 Lost the game !!');
        RollDice_Btn.disabled=true;

    }

    //if player 2 has no money
    if(TotalMoney_P2<=0)
    {
        alert('Player 2 Lost the game !!');
        RollDice_Btn.disabled=true;
        
    }

    //genrating random number from 2 to 12
    //because 0,1 are not in combination of 2 dice
    let Rnumber1 = (Math.floor(Math.random() * 6) + 1);
    let Rnumber2 = (Math.floor(Math.random() * 6) + 1);

     totalRnumber = Rnumber1 + Rnumber2;

    //always moving player when rolling dice
    MovePlayer(totalRnumber);


    //if random numbers are not same mean
    //if dice has no doubles
    if (Rnumber1 != Rnumber2) {
        count++;//incrementing count

    }



    /*------------------------------------------------------------------------------------------------------------------------*/
    //now changing image according to random number generated  for two dice
    ChangeDicePic(Rnumber1, Rnumber2);//changing dice pic

    /*------------------------------------------------------------------------------------------------------------------------*/
}


function BorderChange() {
    /*------------------------------------------------------------------------------------------------------------------------*/
    //now changing border of player

    let player1 = document.querySelector("#picplayer1");
    let player2 = document.querySelector("#picplayer2");

    //if both dice value are not same then only change border
    if ((count % 2) == 1) {

        player2.setAttribute("style", "border: 4px red dotted;");
        player1.removeAttribute("style");
        
    }
    if ((count % 2) == 0) {
        player1.setAttribute("style", "border: 4px red dotted;");
        player2.removeAttribute("style");
        

    }
    /*------------------------------------------------------------------------------------------------------------------------*/
}

//function to change pic of dice
function ChangeDicePic(dice1, dice2) {
    let img1 = document.querySelector(".die1");
    let img2 = document.querySelector(".die2");


    img1.src = "./images/dice" + dice1 + ".PNG";//1
    img2.src = "./images/dice" + dice2 + ".PNG";//1

}

//preloading all stuff on page load
function PreLoad() {

    //creating picture element for 'midlle of board' 
    let player1Img = document.createElement("img");
    player1Img.src = "./images/p1.png";
    player1Img.setAttribute("id", "picplayer1");

    let player2Img = document.createElement("img");
    player2Img.src = "./images/p2.png";
    player2Img.setAttribute("id", "picplayer2");

    bgColor_P1 = window.getComputedStyle(document.querySelector("#player1div")).getPropertyValue("background-color");
    bgColor_P2 = window.getComputedStyle(document.querySelector("#player2div")).getPropertyValue("background-color");

    //pictures of player for middle of board
    document.querySelector("#player1div").appendChild(player1Img);
    document.querySelector("#player2div").appendChild(player2Img);

    RollDice_Btn= document.getElementById("RollDice");

    /*now adding prices of all suites through java script*/
    let elem = document.createElement("label");
    suiteList = document.querySelectorAll("section");

    //iterating through loop and putting price of each value in suites
    for (let count = 0; count < suiteList.length; count++) {
        let texttodisplay = suiteList[count].getAttribute("val");

        let textNode = document.createTextNode(texttodisplay);
        elem.appendChild(textNode);

        if (texttodisplay > 0) {
            suiteList[count].innerHTML += "<label id='mylabels' style='grid-column: 2/3;grid-row:1'>$" + texttodisplay + "</label>";
        }


    }

    
    
    
}


function PlayerPosition() {
    //player position in each suites when dice rolls
    player_1_pic = document.createElement("img");
    player_1_pic.src = "./images/p1.png";
    player_1_pic.setAttribute("style", "height:42px;grid-column:2/-1;")
    player_1_pic.setAttribute("id", "fitcontent")

    player_2_pic = document.createElement("img");
    player_2_pic.src = "./images/p2.png";
    player_2_pic.setAttribute("style", "height:42px;grid-column:2/3")
    player_2_pic.setAttribute("id", "fitcontent")

    suiteList = document.querySelectorAll("section");

    //for initial boar 'Go'
    suiteList[0].appendChild(player_1_pic);
    suiteList[0].appendChild(player_2_pic);




}

//moving player as dice rolls
//parameter- total steps that will require to move player

function MovePlayer(totalsteps) {
    //if player 1 roll dice
    if ((count % 2) == 0) {
        RollDice_Btn.disabled=true;//disable button untill animation completed
        currentpos_Player1 = totalsteps;

        //everytime player passes go suite than increment count
        if (player_1_pos + currentpos_Player1 > 40) {
            count2++;
        }
        
        
        timer = setInterval(() => {

            if (player_1_pos < (player_1_pos + currentpos_Player1)) {


                player_1_pos = (player_1_pos + 1) % suiteList.length;
                suiteList[player_1_pos].appendChild(player_1_pic);

                currentpos_Player1--;

                if (currentpos_Player1 == 0) {

                    clearInterval(timer);
                    timer = setInterval(() => {
                        BorderChange();//changing border or of player
                        clearInterval(timer);
                          
                    if (currentpos_Player1 == 0) {
                        Player1_TotalMoney();
                        RollDice_Btn.disabled=false;//enabling again
                    }

                    }, 100)

                  
                }
            }
        }, 300);





    }


    if ((count % 2) == 1) {

        RollDice_Btn.disabled=true;//disable button untill animation completed
        currentpos_Player2 = totalsteps;
        //everytime player passes go suite than increment count
        if (player_2_pos + currentpos_Player2 > 40) {
            count2++;
        }

        

        timer = setInterval(() => {

            if (player_2_pos < (player_2_pos + currentpos_Player2)) {

                player_2_pos = (player_2_pos + 1) % suiteList.length;
                suiteList[player_2_pos].appendChild(player_2_pic);

                currentpos_Player2--;

                if (currentpos_Player2 == 0) {
                    clearInterval(timer);

                    timer = setInterval(() => {
                        BorderChange();//changing border or of player
                        clearInterval(timer);

                            
                
                    Player2_TotalMoney();
                    RollDice_Btn.disabled=false;//disable button untill animation completed
                
                    }, 100)
                
                }
               
            }
        }, 300);
    }
}


function Player1_TotalMoney() {

    let SuiteColor = new Array();
    let value_of_Suite= new Array();
    let str=suiteList[player_1_pos].getAttribute( "class").substring(0,3);
    let str2=suiteList[player_1_pos].getAttribute( "class");//for tax class
    let rail_road=suiteList[player_1_pos].getAttribute( "class").substring(4,6);
    let rent_position=suiteList[player_1_pos].getAttribute("suite").substring(0,5);
    let count_for_P1_property=0;
    
    
    for (let i = 0; i < suiteList.length; i++) {
        
        SuiteColor[i] = window.getComputedStyle(suiteList[i]).getPropertyValue("background-color");
        value_of_Suite[i]=parseInt(suiteList[i].getAttribute("val")) ;


    }
   
    
        if (SuiteColor[player_1_pos] != bgColor_P1 && SuiteColor[player_1_pos] != bgColor_P2 &&str=="reg"&&value_of_Suite[player_1_pos]>0&&str2!="reg tax" ) {
            suiteList[player_1_pos].style.setProperty("background-color", bgColor_P1);
        }

    
        if(player_1_pos==30)
        {
            suiteList[player_1_pos].removeChild(player_1_pic);
            player_1_pos=10;
           
            suiteList[player_1_pos].appendChild(player_1_pic);
            

            
        }
        //if player passes go 
    if (count > 3) {
        if (player_1_pos >= 0 && count2 >= 1) {
            TotalMoney_P1 = parseInt(TotalMoney_P1) + parseInt(200);
            count2 = 0;
        }
    }



   if(suiteList[player_1_pos].getAttribute("val")==(-1))
   {
    
    let Rnumber = (Math.floor(Math.random() * 5) );
    alert(takeAChanceText[Rnumber]);
    TotalMoney_P1=TotalMoney_P1+takeAChanceMoney[Rnumber];
   }



   if(suiteList[player_1_pos].getAttribute("val")>0)
   {
    

     //if property was not buy by anyone before
     if(SuiteColor[player_1_pos] != bgColor_P1&&SuiteColor[player_1_pos] != bgColor_P2)
     {
        if(player_1_pos==10)
        {
            alert("$50 to get out of jail");
        }
        TotalMoney_P1=TotalMoney_P1-parseInt(suiteList[player_1_pos].getAttribute("val")) ;
     }
       //ifproperty was already buy and you have to pay utilities
       if(SuiteColor[player_1_pos] == bgColor_P1)
       {
           alert(`Utility Rent is : $${5*totalRnumber} is due`)
           TotalMoney_P1=TotalMoney_P1-(5*totalRnumber);
           
       }

       if(SuiteColor[player_1_pos]==bgColor_P2)
       {
        
       

            if(rail_road=="rr")
            {
                alert(`Rail Road rent $ 25`)
                TotalMoney_P1=TotalMoney_P1-25;
            }
            //for rent increase by 20%
            else
            {
                Player1_rent_Holder.push(rent_position);  
                
                let property_price=parseInt(suiteList[player_1_pos].getAttribute("val"));

                for(let i=0;i<Player1_rent_Holder.length;i++)
                {
                    if(Player1_rent_Holder[i]==rent_position)
                    {
                        count_for_P1_property++;
                    }
                }
                
                if(count_for_P1_property==1)
                {
                    property_price=property_price*0.10;
                }
                else
                {
                    property_price=property_price*0.10;
                    for(let i=1;i<count_for_P1_property;i++)
                    {
                        property_price=Math.round((property_price*0.20)+property_price);
                    }
                }
                alert(`Pay Rent of $${property_price}`);
                TotalMoney_P1=TotalMoney_P1-parseInt(property_price) ;
            }
            
        
       }
   }

    document.querySelector("#player1amt").innerHTML = `$${TotalMoney_P1}`;
}

function Player2_TotalMoney() {

    let SuiteColor = new Array();
    let value_of_Suite= new Array();
    let str=suiteList[player_2_pos].getAttribute( "class").substring(0,3);
    let str2=suiteList[player_2_pos].getAttribute( "class");//for tax class
    
    
    let rail_road=suiteList[player_2_pos].getAttribute( "class").substring(4,6);
    let rent_position=suiteList[player_2_pos].getAttribute("suite").substring(0,5);
    let count_for_P2_property=0;
   

    
    for (let i = 0; i < suiteList.length; i++) {
        
        SuiteColor[i] = window.getComputedStyle(suiteList[i]).getPropertyValue("background-color");
        value_of_Suite[i]=parseInt(suiteList[i].getAttribute("val")) ;

    }
   
    
        if (SuiteColor[player_2_pos] != bgColor_P1 && SuiteColor[player_2_pos] != bgColor_P2&&str=="reg"&&value_of_Suite[player_2_pos]>0&&str2!="reg tax") {
            suiteList[player_2_pos].style.setProperty("background-color", bgColor_P2);
        }

       

        if(player_2_pos==30)
        {
            suiteList[player_2_pos].removeChild(player_2_pic);
            player_2_pos=10;
            
            suiteList[player_2_pos].appendChild(player_2_pic);
            
            
        }
    if (count > 3) {
        if (player_2_pos >= 0 && count2 >= 1) {
            TotalMoney_P2 = parseInt(TotalMoney_P2) + parseInt(200);
            count2 = 0;
        }
    }
        if(suiteList[player_2_pos].getAttribute("val")==(-1))
        {
         let Rnumber = (Math.floor(Math.random() * 5) );
         alert(takeAChanceText[Rnumber]);
         TotalMoney_P2=TotalMoney_P2+takeAChanceMoney[Rnumber];
        }
    
        if(suiteList[player_2_pos].getAttribute("val")>0)
        {   
            if(SuiteColor[player_2_pos] == bgColor_P1)
            {

                if(rail_road=="rr")
                {
                    alert(`Rail Road rent $ 25`)
                    TotalMoney_P2=TotalMoney_P2-25;
                }
                //for rent increase by 20%
                else
                {
                    Player2_rent_Holder.push(rent_position); 
                    
                    let property_price=parseInt(suiteList[player_2_pos].getAttribute("val"));

                    for(let i=0;i<Player2_rent_Holder.length;i++)
                    {
                        if(Player2_rent_Holder[i]==rent_position)
                        {
                            count_for_P2_property++;
                        }
                    }

                    if(count_for_P2_property==1)
                    {
                        property_price=property_price*0.10;
                    }
                    else
                    {
                        property_price=property_price*0.10;
                        for(let i=1;i<count_for_P2_property;i++)
                        {
                            property_price=Math.round((property_price*0.20)+property_price);
                        }
                    }
                    alert(`Pay Rent of $${property_price}`);
                    TotalMoney_P2=TotalMoney_P2-parseInt(property_price) ;
                }
                
            }
            
            //if property was not buy by anyone before
            if(SuiteColor[player_2_pos] != bgColor_P1&&SuiteColor[player_2_pos] != bgColor_P2)
            {
                if(player_2_pos==10)
                {
                    alert("$50 to get out of jail");
                }
                TotalMoney_P2=TotalMoney_P2-parseInt(suiteList[player_2_pos].getAttribute("val")) ;
            }

            //ifproperty was already buy and you have to pay utilities
            if(SuiteColor[player_2_pos] == bgColor_P2)
            {
                alert(`Utility Rent is : $${5*totalRnumber} is due`)
                TotalMoney_P2=TotalMoney_P2-(5*totalRnumber);
            }
            
            
            
         
        }
  
        

        
        
    document.querySelector("#player2amt").innerHTML = `$${TotalMoney_P2}`;
}











