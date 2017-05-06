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

    var ticker = $.connection.InformationHub, $infoTable = $('#infoTable'), rowTemplate = '<tr data-symbol="{Name}" style="background-color:{Color}"><td>{ID}</td><td>{Name}</td><td>{Running}</td></tr>';
    $infoTableBody = $infoTable.find('tbody');

    function formatInfo(info) {
        var status = 'Idle';
        var color = '#ffffff';

        if (info.Is_Dead == 1) {
            status = 'Dead';
            color = '#ff0000';
        }
        else if (info.Running_Job == 1) {
            status = 'Running Job';
            color = '#00ff00';
        }
        else if (info.Running_Job == 0 && info.Sent_Job == 0 && info.job === null) {
            status = 'Idle';
            color = '#ffffff';
        }

        return $.extend(info, {
            Name: info.Name,
            Running: status,
            ID: info.AgentID,
            Color: color,
        });
    }

    function init() {
        $.getJSON('http://10.0.0.205:44444/api/agent/getallagents', function (data) {
            var obj = JSON.parse(data);
            $infoTableBody.empty();
            $.each(obj.Agents, function () {
                var info = formatInfo(this);
                var row = rowTemplate.supplant(info);
                switch (info.Color) {
                    case 'red':
                        row.style.backgroundColor = '#FF0000';
                        break;
                    case 'green':
                        row.style.backgroundColor = '#00FF00';
                }
                $infoTableBody.append(row);
            });
        });
    }

    ticker.client.updateRunning = function (name,job) {
        var $therow = $infoTableBody.find('tr[data-symbol=' + name + ']');
        $therow[0].style.backgroundColor = '#00FF00';
        $therow[0].cells[2].innerHTML = 'Running Job ' + job;
    }

    ticker.client.updateIdle = function (name) {
        var $therow = $infoTableBody.find('tr[data-symbol=' + name + ']');
        $therow[0].style.backgroundColor = '#FFFFFF';
        $therow[0].cells[2].innerHTML = 'Idle';
    }

    ticker.client.updateDead = function (name) {
        var $therow = $infoTableBody.find('tr[data-symbol=' + name + ']');
        $therow[0].style.backgroundColor = '#FF0000';
        $therow[0].cells[2].innerHTML = 'Dead';
    }

    ticker.client.updateInformation = function (info) {
        var displayInfo = formatInfo(info),
            $row = $(rowTemplate.supplant(displayInfo));
        var $therow = $infoTableBody.find('tr[data-symbol=' + info.Name + ']');
        if ($therow[0] == null) {
            $infoTableBody.append(rowTemplate.supplant(info));
        }
    }

    ticker.client.addMachine = function (info) {
        var displayInfo = formatInfo(info),
            $row = $(rowTemplate.supplant(displayInfo));
        var $therow = $infoTableBody.find('tr[data-symbol=' + info.Name + ']');
        if ($therow[0] == null) {
            $infoTableBody.append(rowTemplate.supplant(info));
        }
    }

    $.connection.hub.start().done(init);
});