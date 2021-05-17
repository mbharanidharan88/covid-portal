const jwt = require("express-jwt"),
    jwksClient = require("jwks-rsa");

const issuer = 'https://localhost:44363';

const auth = jwt({
    secret: jwksClient.expressJwtSecret({
        cache: true, // see https://github.com/auth0/node-jwks-rsa#caching
        rateLimit: true, // see https://github.com/auth0/node-jwks-rsa#rate-limiting
        jwksRequestsPerMinute: 2,
        jwksUri: `${issuer}/.well-known/openid-configuration/jwks`,
    }),

    audience: "patientAPI", // <---- its your api resource.
    issuer: issuer, // <----- address of identityserver4.
    algorithms: ["RS256"], //<----- its needed algorithm to handle secret.
})

module.exports = auth;