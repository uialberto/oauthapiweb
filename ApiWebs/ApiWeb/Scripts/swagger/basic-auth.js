(function () {
    $(function () {

        var basicAuthUi =
            '<div class="input"><input placeholder="uid" id="input_username" name="username" type="text" /></div>' +
            '<div class="input"><input placeholder="key" id="input_password" name="password" type="password" /></div>';

        if (!($('#input_username').length || $('#input_password').length)) {
            $(basicAuthUi).insertBefore('#api_selector div.input:last-child');
        } 

        $("#input_apiKey").hide();

        $("#input_username").change(addAuthorization);
        $("#input_password").change(addAuthorization);

    });

    function addAuthorization() {
        var username = $("#input_username").val();
        var password = $("#input_password").val();
        if (username && username.trim() != "" && password && password.trim() != "") {
            var basicAuth = new SwaggerClient.PasswordAuthorization("Basic", username, password);
            window.swaggerUi.api.clientAuthorizations.add("basicAuth", basicAuth);
        }
    }
})();