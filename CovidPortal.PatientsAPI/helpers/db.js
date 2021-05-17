require('rootpath')();
var config = require('myconfig.json');
var mongoose = require('mongoose');
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
};
console.info(config);
console.info(config.DBHost);
//MongoLab Connection
var host = "mongodb://" + config.DBHost + "/CovidPortalPatientAppData?retryWrites=true";
var conn = mongoose.connect(host, options).then(function (mongoInstance) {
    console.log("Connected to DB");
    console.log(connDB);
    connDB = mongoInstance;
}, function (err) { console.log("Error Connecting to DB:" + err); });
//mongodb+srv://admin:<password>@mymongodbcluster-teakz.mongodb.net/test?retryWrites=true
module.exports = {
    //Connection:
    connDB: connDB,
    //core
    //Result: require('models/core/result.model.ts'),
    //User: require('models/user.model.ts'),
    //Role: require('models/role.model.ts'),
    //Client: require('models/client.model.ts'),
    //Site: require('models/site.model.ts'),
    //Module: require('models/mod.model.ts'),
    //JobCategory: require('models/job-category.model.ts'),
    //JobSystem: require('models/job-system.model.ts'),
    //DispatchStatus: require('models/dispatch-status.model.ts')
};
//# sourceMappingURL=db.js.map