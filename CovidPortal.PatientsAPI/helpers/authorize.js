var jwt = require("express-jwt"), jwksClient = require("jwks-rsa");
var issuer = 'https://localhost:44363';
var auth = jwt({
    secret: jwksClient.expressJwtSecret({
        cache: true,
        rateLimit: true,
        jwksRequestsPerMinute: 2,
        jwksUri: issuer + "/.well-known/openid-configuration/jwks",
    }),
    audience: "patientAPI",
    issuer: issuer,
    algorithms: ["RS256"], //<----- its needed algorithm to handle secret.
});
module.exports = auth;
//# sourceMappingURL=authorize.js.map