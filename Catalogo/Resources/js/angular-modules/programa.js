angular.module('CatalogoApp')
    .controller('ProgramaController', function () {
        self = this;

        function getPrograms() {
            return $.ajax({
                type: 'POST',
                url: 'Programa/GetItems',
                async: false
            });
        }

        function getTipoPrograms() {
            return $.ajax({
                type: 'POST',
                url: 'Parametro/GetTipoProgramas',
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

        function getAccessByProgram(id){
            return $.ajax({
                type: 'POST',
                url: 'Acceso/GetAccessByProgram/?id=' + id,
                async: false
            });
        }

        this.index = function (tab) {
            tab.templateUrl = 'Programa/?ajax=1&_=' + Date.now();
        }

        this.create = function (tab) {
            tab.templateUrl = 'Programa/Create/?ajax=1&_=' + Date.now();
        }

        this.edit = function (tab, id) {
            tab.templateUrl = 'Programa/Edit/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.delete = function (tab, id) {
            tab.templateUrl = 'Programa/Delete/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.detail = function (tab, id) {
            tab.templateUrl = 'Programa/Detail/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.access = function (tab, id){
            tab.templateUrl = 'Programa/Access/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.accessgroup = function (tab, id) {
            tab.templateUrl = 'Programa/AccessGroup/?id=' + id + '&ajax=1&_=' + Date.now();
        }

        this.save = function (tab, data) {
            self.response = $.ajax({
                type: 'POST',
                url: 'Programa/Create',
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
                url: 'Programa/Edit',
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
                url: 'Programa/Remove/?id=' + id,
                async: false
            }).responseJSON;

            if (self.response.result) {
                tab.templateUrl = self.response.value + '/?ajax=1&_=' + Date.now();
            }
        }

        

        this.items = getPrograms().responseJSON;
        this.padres = getPrograms().responseJSON;
        this.padres.push(undefined);
        this.tipos = getTipoPrograms().responseJSON;
        this.estados = getEstados().responseJSON;

        this.loadAccess = function (item){
            return item;
        }

        
    });