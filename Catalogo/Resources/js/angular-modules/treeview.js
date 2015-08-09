
angular.module('CatalogoApp')
    .controller('TreeviewController', function ($timeout) {
        this.data = [];

        function isLeafOf(leaf) {
            return (leaf.PadreId == this);
        }

        function fillTree(jsonResponse, tree, root) {
            jsonResponse.filter(isLeafOf, root.id).forEach(function (elem) {
                root.children.push({
                    id: elem.Id,
                    label: elem.Nombre,
                    templateUrl: ((elem.Url == undefined || elem.Url == '') ? undefined : elem.Url + '?ajax=1'),
                    children: []
                });
            });

            if (root.children == 0) {
                return root;
            }

            root.children.forEach(function (branch) {
                branch = fillTree(jsonResponse, [], branch);
            });
            tree.push(root);
        }

        function getPrograms() {
            return $.ajax({
                type: 'POST',
                url: 'Programa/GetItems',
                async: false
            });
        }

        this.selectedBranch = null;

        this.handleClick = function (tabctrl) {
            var self = this;
            $timeout(function () {
                tabctrl.addTab(self.selectedBranch.label, self.selectedBranch.templateUrl);
            }, 0);
        };

        var my_tree = [];

        var progs = getPrograms().responseJSON;

        progs
        .filter(function (p) { 
            return p.PadreId == undefined
        })
        .forEach(function (s) {
            fillTree(
            progs,
            my_tree, {
                id: s.Id,
                label: s.Nombre,
                children: []
            })
        });

        this.data = my_tree;
    });
