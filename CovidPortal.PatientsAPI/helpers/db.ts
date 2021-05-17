require('rootpath')()

const config = require('myconfig.json')
const mongoose = require('mongoose')
// const createdByPlugin = require('helpers/plugins/created-by-plugin.ts')
// const createdDatePlugin = require('helpers/plugins/created-date-plugin.ts')
var connDB;

//Add default properties
// mongoose.plugin(createdByPlugin)
// mongoose.plugin(createdDatePlugin)

//Index
mongoose.set('useCreateIndex', true);

var options = {
    // user: config.DBUser,
    // pass: config.DBPass,
    dbName: 'CovidPortalPatientAppData',
    useNewUrlParser: true
}

console.info(config);
console.info(config.DBHost);

//MongoLab Connection
var host = "mongodb://" + config.DBHost + "/CovidPortalPatientAppData?retryWrites=true"

var conn = mongoose.connect(host, options).then(
    (mongoInstance) => {
        console.log("Connected to DB")
        console.log(connDB)
        connDB = mongoInstance
    },
    err => { console.log("Error Connecting to DB:" + err) }
)
//mongodb+srv://admin:<password>@mymongodbcluster-teakz.mongodb.net/test?retryWrites=true

module.exports = {
    //Connection:
    connDB: connDB,
    //core
    Result: require('models/result.model.ts'),
    Patient: require('models/patient.model.ts'),
}