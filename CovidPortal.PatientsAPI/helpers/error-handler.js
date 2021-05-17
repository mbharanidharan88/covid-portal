module.exports = errorHandler;
function errorHandler(err, req, res, next) {
    console.error(err.stack);
    console.log(err);
    return res.status(err.status).json({ Error: err.message });
}
//# sourceMappingURL=error-handler.js.map