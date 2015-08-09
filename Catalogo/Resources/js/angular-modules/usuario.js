angular.module('CatalogoApp')
    .controller('UsuarioController', function () {
        self = this;

        function getUsuarios() {
            return $.ajax({
                type: 'POST',
                url: 'Usuario/GetUsuarios',
                async: false
            });
        }

        this.index = function (tab) {
            tab.templateUrl = 'Usuario/?ajax=1&_=' + Date.now();
        }

        this.create = function (tab) {
            tab.templateUrl = 'Usuario/Create/?ajax=1&_=' + Date.now();
        }

        this.edit = function (tab, id) {
            tab.templateUrl = 'Usuario/Edit/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.deleteUser = function (tab, id) {
            tab.templateUrl = 'Usuario/Delete/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.detail = function (tab, id) {
            tab.templateUrl = 'Usuario/Detail/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.groups = function (tab, id) {
            tab.templateUrl = 'Usuario/Groups/?id=' + id + '&ajax=1&_=' + Date.now();
        }


        this.save = function (tab, data) {
            self.response = $.ajax({
                type: 'POST',
                url: 'Usuario/Create',
                data: data,
                async: false
            }).responseJSON;

            if (self.response.result) {
                tab.templateUrl = self.response.value + '/?ajax=1&_=' + Date.now();
            }
        }

        this.update = function (tab, data) {
            self.response = $.ajax({
                type: 'POST',
                url: 'Usuario/Edit',
                data: data,
                async: false
            }).responseJSON;

            if (self.response.result) {
                tab.templateUrl = self.response.value + '/?ajax=1&_=' + Date.now();
            }
        }

        this.remove = function (tab, id) {
            self.response = $.ajax({
                type: 'POST',
                url: 'Usuario/Remove/?id=' + id,
                async: false
            }).responseJSON;

            if (self.response.result) {
                tab.templateUrl = self.response.value + '/?ajax=1&_=' + Date.now();
            }
        }

        this.items = getUsuarios().responseJSON;
    });