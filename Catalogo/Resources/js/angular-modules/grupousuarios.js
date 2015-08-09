angular.module('CatalogoApp')
    .controller('GrupoUsuariosController', function () {
        self = this;

        function getUsersByGroup(id) {
            return $.ajax({
                type: 'POST',
                url: 'UsuarioGrupo/GetUsersByGroup/?id=' + id,
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
                url: 'UsuarioGrupo/Create/?usuarioId=' + acc.UsuarioId + '&grupoId=' + acc.GrupoId,
                async: false
            }).responseJSON;
        }

        this.remove = function (acc) {
            return $.ajax({
                type: 'POST',
                url: 'UsuarioGrupo/Remove/?usuarioId=' + acc.UsuarioId + '&grupoId=' + acc.GrupoId,
                async: false
            })
        }

        function removeItemFromArray(item, array) {
            var index = array.indexOf(item);
            if (index >= 0) {
                array.splice(index, 1);
            }
        }

        this.addUserToGroup = function (user, group) {
            var usugru = { Usuario: user, UsuarioId: user.Id, Grupo: group, GrupoId: group.Id };
            if (self.items == undefined) {
                self.items = [usugru];
            }
            else {
                self.items.push(usugru);
            }

            removeItemFromArray(user, self.usuarios);

            self.response = self.save(usugru).responseJSON;
        }

        this.removeUserFromGroup = function (usugru) {
            if (self.usuarios == undefined) {
                self.usuarios = [usugru.Grupo];
            }
            else {
                self.usuarios.push(usugru.Usuario);

            }

            removeItemFromArray(usugru, self.items);

            self.response = self.remove(usugru).responseJSON;
        }

        this.goBack = function (tab, grupoId) {
            tab.templateUrl = 'Grupo/Detail/?id=' + grupoId + '&ajax=1&_=' + Date.now();
        }

        this.init = function (group) {
            self.items = getUsersByGroup(group.Id).responseJSON;

            self.usuarios = getUsuarios().responseJSON;

            console.log('USUARIOS', self.usuarios);
            self.items.forEach(function (usugru) {

                var users = self.usuarios.filter(function (item) {
                    return item.Id == usugru.Usuario.Id
                });

                users.forEach(function (user) {
                    removeItemFromArray(user, self.usuarios);
                });
            });
            return group;
        }
    });