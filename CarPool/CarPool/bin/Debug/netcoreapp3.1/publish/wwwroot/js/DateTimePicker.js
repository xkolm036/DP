



//date time picker
$(function () {
    $('.dateinput').datetimepicker({
        icons: {
            time: 'fa fa-clock',
            date: 'fa fa-calendar',
            up: 'fa fa-chevron-up',
            down: 'fa fa-chevron-down',
            previous: 'fa fa-chevron-left',
            next: 'fa fa-chevron-right',
            today: 'fa fa-crosshairs',
            clear: 'fa fa-trash-o',
            close: 'fa fa-times'
        },
        useCurrent: true,
        collapse: true,
        format: 'DD.MM.YYYY'
    });

});

$(function () {
    $('.timeinput').datetimepicker({
        icons: {
            up: 'fa fa-chevron-up',
            down: 'fa fa-chevron-down'
        },

        useCurrent: true,
        collapse: true,

        format: 'HH:mm'
    });

});

