if (!String.prototype.supplant) {
    String.prototype.supplant = function (o) {
        return this.replace(/{([^{}]*)}/g,
            function (a, b) {
                var r = o[b];
                return typeof r === 'string' || typeof r === 'number' ? r : a;
            }
        );
    };
}

$(function () {

    var ticker = $.connection.InformationHub, $infoTable = $('#infoTable'), rowTemplate = '<tr data-symbol="{Name}"><td>{ID}</td><td>{Name}</td><td>{Running}</td></tr>';
    $infoTableBody = $infoTable.find('tbody');

    function formatInfo(info) {
        return $.extend(info, {
            Name: info.Name,
            Running: info.Running_Job,
            ID: info.AgentID,
        });
    }

    function init() {
        ticker.server.getAllInformation().done(function (infos) {
            $infoTableBody.empty();
            $.each(infos, function () {
                var info = formatInfo(this);
                $infoTableBody.append(rowTemplate.supplant(info));
            })
        });
    }

    ticker.client.updateRunning = function (name) {
        var $therow = $infoTableBody.find('tr[data-symbol=' + name + ']');
        $therow[0].style.backgroundColor = '#00FF00';
    }

    ticker.client.updateIdle = function (name) {
        var $therow = $infoTableBody.find('tr[data-symbol=' + name + ']');
        $therow[0].style.backgroundColor = '#FFFFFF';
    }

    ticker.client.updateInformation = function (info) {
        var displayInfo = formatInfo(info),
            $row = $(rowTemplate.supplant(displayInfo));
        var $therow = $infoTableBody.find('tr[data-symbol=' + info.Name + ']');
        if ($therow[0] == null) {
            $infoTableBody.append(rowTemplate.supplant(info));
        }
    }

    $.connection.hub.start().done(init);
});