angular.module('CatalogoApp')
    .controller('GrupoController', function () {
        self = this;

        function getGrupos() {
            return $.ajax({
                type: 'POST',
                url: 'Grupo/GetGrupos',
                async: false
            });
        }

        function getEstados() {
            return $.ajax({
                type: 'POST',
                url: 'Parametro/GetEstados',
                async: false
            });
        }

        this.index = function (tab) {
            tab.templateUrl = 'Grupo/?ajax=1&_=' + Date.now();
        }

        this.create = function (tab) {
            tab.templateUrl = 'Grupo/Create/?ajax=1&_=' + Date.now();
        }

        this.edit = function (tab, id) {
            tab.templateUrl = 'Grupo/Edit/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        self.delete = function (tab, id) {
            tab.templateUrl = 'Grupo/Delete/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.detail = function (tab, id) {
            tab.templateUrl = 'Grupo/Detail/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.users = function (tab, id) {
            tab.templateUrl = 'Grupo/Users/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.save = function (tab, data) {
            self.response = $.ajax({
                type: 'POST',
                url: 'Grupo/Create',
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
                url: 'Grupo/Edit',
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
                url: 'Grupo/Remove/?id=' + id,
                async: false
            }).responseJSON;

            if (self.response.result) {
                tab.templateUrl = self.response.value + '/?ajax=1&_=' + Date.now();
            }
        }

        this.items = getGrupos().responseJSON;
        this.estados = getEstados().responseJSON;
    });