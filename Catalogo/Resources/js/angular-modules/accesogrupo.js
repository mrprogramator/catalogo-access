angular.module('CatalogoApp')
    .controller('AccesoGrupoController', function () {
        self = this;

        function getAccessByProgram(id) {
            return $.ajax({
                type: 'POST',
                url: 'AccesoGrupo/GetAccessByProgram/?id=' + id,
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
                url: 'AccesoGrupo/Create/?programaId=' + acc.ProgramaId + '&grupoId=' + acc.GrupoId,
                async: false
            }).responseJSON;
        }

        this.update = function (acc) {
            return $.ajax({
                type: 'POST',
                url: 'AccesoGrupo/Update',
                data: acc,
                async: false
            }).responseJSON;
        }

        this.remove = function (acc) {
            return $.ajax({
                type: 'POST',
                url: 'AccesoGrupo/Remove/?programaId=' + acc.ProgramaId + '&grupoId=' + acc.GrupoId,
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
            var acc = { Grupo: user, GrupoId: user.Id, Programa: program, ProgramaId: program.Id };
            if (self.items == undefined) {
                self.items = [acc];
                return;
            }

            self.items.push(acc);
            removeItemFromArray(user, self.grupos);

            self.response = self.save(acc).responseJSON;
        }

        this.removeFromAccess = function (acc) {
            if (self.grupos == undefined) {
                self.grupos = [acc.Grupo];
                return;
            }

            self.grupos.push(acc.Grupo);
            removeItemFromArray(acc, self.items);

            self.response = self.remove(acc).responseJSON;
        }

        this.goBack = function (tab, programaId) {
            tab.templateUrl = 'Programa/Detail/?id=' + programaId + '&ajax=1&_=' + Date.now();
        }

        this.init = function (prog) {
            self.items = getAccessByProgram(prog.Id).responseJSON;

            self.grupos = getGrupos().responseJSON;

            console.log('GRUPOS',self.grupos);
            self.items.forEach(function (acc) {

                var groups = self.grupos.filter(function (item) {
                    return item.Id == acc.Grupo.Id
                });

                groups.forEach(function (group) {
                    removeItemFromArray(group, self.grupos);
                });
            });
            return prog;
        }
    });