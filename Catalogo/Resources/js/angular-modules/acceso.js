﻿angular.module('CatalogoApp')
    .controller('AccesoController', function () {
        self = this;

        function getAccessByProgram(id) {
            return $.ajax({
                type: 'POST',
                url: 'Acceso/GetAccessByProgram/?id=' + id,
                async: false
            });
        }

        function getUsuarios() {
            return $.ajax({
                type: 'POST',
                url: 'Usuario/GetUsuarios',
                async: false
            })
        }

        this.save = function (acc) {
            return $.ajax({
                type: 'POST',
                url: 'Acceso/Create/?programaId=' + acc.ProgramaId + '&usuarioId=' + acc.UsuarioId,
                async: false
            }).responseJSON;
        }

        this.update = function (acc) {
            return $.ajax({
                type: 'POST',
                url: 'Acceso/Update',
                data: acc,
                async: false
            }).responseJSON;
        }

        this.remove = function (acc) {
            return $.ajax({
                type: 'POST',
                url: 'Acceso/Remove/?programaId=' + acc.ProgramaId + '&usuarioId=' + acc.UsuarioId,
                async: false
            })
        }

        function removeItemFromArray(item, array) {
            var index = array.indexOf(item);
            if (index >= 0) {
                array.splice(index, 1);
            }
        }

        this.addToAccess = function (user, program) {
            var acc = { Usuario: user, UsuarioId: user.Id, Programa: program, ProgramaId: program.Id };
            if (self.items == undefined) {
                self.items = [acc];
                return;
            }

            self.items.push(acc);
            removeItemFromArray(user, self.usuarios);

            self.response = self.save(acc).responseJSON;
        }

        this.removeFromAccess = function (acc) {
            if (self.usuarios == undefined) {
                self.usuarios = [acc.Usuario];
                return;
            }

            self.usuarios.push(acc.Usuario);
            removeItemFromArray(acc, self.items);

            self.response = self.remove(acc).responseJSON;
        }

        this.goBack = function (tab, programaId) {
            tab.templateUrl = 'Programa/Detail/?id=' + programaId +'&ajax=1&_=' + Date.now();
        }

        this.init = function (prog) {
            self.items = getAccessByProgram(prog.Id).responseJSON;

            self.usuarios = getUsuarios().responseJSON;

            self.items.forEach(function (acc) {

                var users = self.usuarios.filter(function (item) {
                    return item.Id == acc.Usuario.Id
                });

                users.forEach(function (user) {
                    removeItemFromArray(user, self.usuarios);
                });
            });
            return prog;
        }
    });