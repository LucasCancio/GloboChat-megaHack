var request = require('request');

/* var headers = {
    'Sec-Fetch-Mode': 'no-cors',
    'Referer': 'https://www.net.com.br/tv-por-assinatura/programacao/grade',
    'User-Agent': 'Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36'
}; */

var options = {
    url: 'http://services.sapo.pt/EPG/GetChannelByDateInterval?channelSigla=RTP2&startDate=2009-03-08+20%3A00%3A00&endDate=2009-03-08+21%3A00%3A00'
};

function callback(error, response, body) {
    if (!error && response.statusCode == 200) {
        console.log('\n\n' + body);
    }
}

request(options, callback);

