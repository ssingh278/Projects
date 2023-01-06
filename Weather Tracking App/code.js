//Author : Sharry Singh
//Email: Singh21Sharry@gmail.com

const http = require('http');
const fs = require('fs');
const requests = require('requests');


const homeFile = fs.readFileSync("index.html", 'utf-8');

const replaceVal=(tempVal,orgVal)=>{

    let str=tempVal.replace("{%city%}",orgVal.name);
    str=str.replace("{%country%}",orgVal.sys.country);
    str=str.replace("{%tempval%}",(orgVal.main.temp- 273.15).toFixed(1));
    str=str.replace("{%tempmin%}",(orgVal.main.temp_min- 273.15).toFixed(1));
    str=str.replace("{%tempmax%}",(orgVal.main.temp_max- 273.15).toFixed(1));
    str=str.replace("{%tempstatus%}",orgVal.weather[0].main);


    return str;

    
};
//we are going to install request npm 
// npm i requests
const server = http.createServer((req, res) => {

    //if user enter correct link
    if (req.url == '/') {
        //we are goin to call our API
      const liveData=  requests('https://api.openweathermap.org/data/2.5/weather?q=Edmonton&appid=274e56a1391df30fb0d37501a1a0189a');

        //event for getting data
        liveData.on('data', (chunk) => {

            // console.log(chunk);

            //converting our JSON object to javascript object
            const objData=JSON.parse(chunk);

            //converting data into array
            const arrayData=[objData];

            //getting evrything on console to make sure that our data is correct
           /*  console.log(arrayData); */

            const realTimeData=arrayData.map( (value) => replaceVal(homeFile,value) ).join("");
            // console.log(realTimeData);

            res.write(realTimeData);
            res.end();

            // /*Celsius = (Kelvin – 273.15) */
            // let tempCelcius=(arrayData[0].main.temp - 273.15).toFixed(1);
            // console.log(tempCelcius);
        });

        //event if data ends
        liveData.on('end', (err) => {
            if (err) 
            return console.log('connection closed due to errors', err);

            console.log('end');
        });
    }
});


const port = 8008;
const localHost = "192.168.1.65";

server.listen(port, localHost, (error) => {
    if (error) {
        console.log(error);
    }

    else {
        console.log(`Listening to port number ${port} at local host ${localHost}`);
    }
})

