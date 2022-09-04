module.exports =  function (context, req) {
    const axios = require('axios')
    const GITHUB_AUTH_ACCESSTOKEN_URL = 'https://github.com/login/oauth/access_token'
    const CLIENT_ID = '{{your_secret}}'
    const CLIENT_SECRET = '{{your_secret}}'
    const CODE = req.query.gitcode

    axios.post(GITHUB_AUTH_ACCESSTOKEN_URL, {
        client_id: CLIENT_ID,
        client_secret: CLIENT_SECRET,
        code: CODE
    }, {headers: {'Accept': 'application/json'}})
        .then(function (response) {
            console.log(response.data)
            context.res = {
                // status: 200, /* Defaults to 200 */
                body: response.data
            };
            context.done();
        })
        .catch(function (error) {
            context.res = {
                status: 500,
                body: error.message
            };
            context.done();
        })

}