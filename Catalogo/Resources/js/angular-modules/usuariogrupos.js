angular.module('CatalogoApp')
    .controller('UsuarioGruposController', function () {
        self = this;

        function getGroupsByUser(id) {
            return $.ajax({
                type: 'POST',
                url: 'UsuarioGrupo/GetGroupsByUser/?id=' + id,
                async: false
            });
        }

        function getGrupos() {
            return $.ajax({
                type: 'POST',
                url: 'Grupo/GetGrupos',
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

        this.addGroupToUser = function (user, group) {
            var usugru = { Usuario: user, UsuarioId: user.Id, Grupo: group, GrupoId: group.Id };
            if (self.items == undefined) {
                self.items = [usugru];
            }
            else {
                self.items.push(usugru);
            }

            removeItemFromArray(group, self.grupos);

            self.response = self.save(usugru).responseJSON;
        }

        this.removeGroupFromUser = function (usugru) {
            if (self.grupos == undefined) {
                self.grupos = [usugru.Grupo];
            }
            else {
                self.grupos.push(usugru.Grupo);

            }

            removeItemFromArray(usugru, self.items);

            self.response = self.remove(usugru).responseJSON;
        }

        this.goBack = function (tab, usuarioId) {
            tab.templateUrl = 'Usuario/Detail/?id=' + usuarioId + '&ajax=1&_=' + Date.now();
        }

        this.init = function (user) {
            self.items = getGroupsByUser(user.Id).responseJSON;

            self.grupos = getGrupos().responseJSON;

            self.items.forEach(function (usugru) {

                var groups = self.grupos.filter(function (item) {
                    return item.Id == usugru.Grupo.Id
                });

                groups.forEach(function (group) {
                    removeItemFromArray(group, self.grupos);
                });
            });
            return user;
        }
    });