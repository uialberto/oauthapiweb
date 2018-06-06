(function () {
    $(function () {
        $('#input_apiKey').attr('placeholder', 'authentication bearer token');
        $('#input_apiKey').off();
        $('#input_apiKey').on('change', addAuthorization);
    });
    function addAuthorization() {
        var key = this.value;        
        if (key && key.trim() !== '') {
            var bearerAuth = new SwaggerClient.ApiKeyAuthorization('Authorization', "Bearer " + key, "header");
            window.swaggerUi.api.clientAuthorizations.add("key", bearerAuth);
        }
    }
})();


