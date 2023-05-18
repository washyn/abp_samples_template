(function(){
    abp.event.on('abp.configurationInitialized', function (){
        abp.ajax({
            type: 'GET',
            url: '/api/abp/application-user-configuration'
        }).then(function(result){
            abp.currentUser.id = result.userId;
        });
    });
})();

var abp = abp || {};
(function ($) {
    abp.auth = abp.auth || {};
    abp.auth.roles = abp.auth.roles || {};
    // abp.auth.roles["Administrador"] = "Administrador";
    // abp.auth.roles["Usuario"] = "Usuario";

    abp.event.on('abp.configurationInitialized', function () {
        // abp.auth.isAdminOrDirector = function (){
        //     return abp.currentUser.roles.includes(abp.auth.roles.admin) || abp.currentUser.roles.includes(abp.auth.roles.Director);
        // }
        // abp.auth.isAdmin = function(){
        //     return abp.currentUser.roles.includes(abp.auth.roles.Administrador);
        // }
        // abp.auth.isUser = function(){
        //     return abp.currentUser.roles.includes(abp.auth.roles.Usuario);
        // }
    });
    
})(jQuery);