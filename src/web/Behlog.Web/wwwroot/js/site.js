// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//-----------------------Ajax forms
function dataAjaxBegin(element, text) {
    waiting(element, 'show', text);
    return true;
}

function dataAjaxSuccess(data, status, xhr) {
    notification('success', 'عملیات درخواستی با موفقیت انجام شد.');
}

function dataAjaxFailure(xhr, status, error) {
    if (isNullOrEmpty(xhr)) {
        waiting('body', 'hide', '');
        setTimeout(function () { waiting('body', 'destroy', ''); }, 600);
        //notification('error', 'عملیات درخواستی با خطا مواجه شد.');
        return;
    }

    if (xhr.status === 401) {
        waiting('body', 'hide', '');
        setTimeout(function () { waiting('body', 'destroy', ''); }, 600);
        window.location.href = xhr.getResponseHeader('Location');
        return;
    }

    if (xhr.status === 403) {
        waiting('body', 'hide', '');
        setTimeout(function () { waiting('body', 'destroy', ''); }, 600);
        notification('error', 'شما مجوز انجام عملیات درخواستی را ندارید.');
        return;
    }

    if (isNullOrEmpty(xhr.responseText)) {
        waiting('body', 'hide', '');
        setTimeout(function () { waiting('body', 'destroy', ''); }, 600);
        notification('error', 'عملیات درخواستی با خطا مواجه شد.');
        return;
    }

    waiting('body', 'hide', '');
    setTimeout(function () { waiting('body', 'destroy', ''); }, 600);
    notification('error', xhr.responseText);
}

function dataAjaxDone(element, text) {
    waiting(element, 'hide', '');
    setTimeout(function () { waiting(element, 'destroy', ''); }, 600);
    if (isNullOrEmpty(text)) {
        text = 'عملیات با موفقیت انجام شد.';
    }
    notification('success', text);
}

function dataAjaxComplete(xhr, status) {
    waiting('body', 'hide', '');
}

function linkAjaxBegin(xhr, settings) {
    var token = $('input[name=__RequestVerificationToken]').val();
    settings.data = settings.data + '&__RequestVerificationToken=' + token;
}

function linkAjaxBegin_02(xhr, settings, element) {
    var token = $('input[name=__RequestVerificationToken]').val();
    settings.data = settings.data + '&__RequestVerificationToken=' + token;
    waiting(element, 'show', '');
}

function generateAntiForgeryToken(xhr, settings) {
    var token = $('input[name=__RequestVerificationToken]').val();
    settings.data = settings.data + '&__RequestVerificationToken=' + token;
}
//-----------------------Ajax forms

//--------------------- Set dir rtl
function checkRTL(s) {
    var ltrChars = 'A-Za-z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u02B8\u0300-\u0590\u0800-\u1FFF' + '\u2C00-\uFB1C\uFDFE-\uFE6F\uFEFD-\uFFFF',
        rtlChars = '\u0591-\u07FF\uFB1D-\uFDFD\uFE70-\uFEFC',
        rtlDirCheck = new RegExp('^[^' + ltrChars + ']*[' + rtlChars + ']');
    return rtlDirCheck.test(s);
}
function setDirection(selector) {
    var string = selector.val();
    for (var i = 0; i < string.length; i++) {
        var isRtl = checkRTL(string[i]);
        var dir = isRtl ? 'RTL' : 'LTR';
        if (dir === 'RTL') var finalDirection = 'RTL';
        if (finalDirection == 'RTL') dir = 'RTL';
    }
    if (dir === 'LTR') {
        selector.css("direction", "ltr");
    } else {
        selector.css("direction", "rtl");
    }
}
// Change Input Direction Depend on Language
$(document).ready(function () {
    $('input[type="text"]').keyup(function () {
        setDirection($(this));
    });
    var searchInput = document.getElementById("searchBox");
    if (searchInput !== null)
        searchInput.addEventListener("keyup", function (event) {
            event.preventDefault();
            if (event.keyCode === 13) {
                document.getElementById("btnSearch").click();
            }
        });
});
//---------------------

function waiting(element, mode, text) {
    if (isNullOrEmpty(element)) {
        element = 'body';
    }
    if (isNullOrEmpty(text)) {
        text = 'منتظر بمانید...';
    }

    var time = 0;
    var delay = function (ms) { return new Promise(function (r) { setTimeout(r, ms); }) };
    if (mode == 'show') {
        time = 1;
        delay(time).then(function () {
            $(element).loadingModal({
                position: 'auto',
                text: text,
                color: '#fff',
                opacity: '0.7',
                backgroundColor: 'rgb(0,0,0)',
                animation: 'cubeGrid'
            });

            return delay(time);
        });
    }
    else if (mode == 'hide') {
        time = 600;
        delay(time)
            .then(function () { $(element).loadingModal(mode); return delay(time); })
            .then(function () { $(element).loadingModal('destroy'); });
    } else {
        $(element).loadingModal(mode);
    }
    //if (isNullOrEmpty(element)) {
    //    element = 'body';
    //}
    //if (isNullOrEmpty(text)) {
    //    text = 'منتظر بمانید...';
    //}

    //if (mode == 'show') {
    //    $(element).loadingModal({
    //        position: 'auto',
    //        text: text,
    //        color: '#fff',
    //        opacity: '0.7',
    //        backgroundColor: 'rgb(0,0,0)',
    //        animation: 'cubeGrid'
    //    });
    //}
    //else {
    //    $(element).loadingModal(mode);
    //}
}

function disableBtn(element, value) {
    if (value === true) {
        $(element).attr("disabled", "disabled");
    } else {
        $(element).removeAttr("disabled");
    }
}

function checkForm(form) {
    var btn = document.getElementById("btnSubmitForm");
    alert(btn.name);
    btn.disabled = true;
    btn.val = "صبر کنید...";
    return true;
}

$("input[type=number]").bind({
    keydown: function (e) {
        if (e.shiftKey === true) {
            if (e.which == 9) {
                return true;
            }
            return false;
        }
        if (e.which > 57) {
            return false;
        }
        if (e.which == 32) {
            return false;
        }
        return true;
    }
});



function notification(mode, text, timeOut) {
    if (isNullOrEmpty(text)) {
        text = 'عملیات درخواستی با موفقیت انجام شد.';
    }

    if (isNullOrEmpty(timeOut)) {
        timeOut = "5000";
    }

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": timeOut,
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

    toastr[mode](text);
}

function isNullOrEmpty(value) {
    return (value == null || value === '' || value == ' ' || value == undefined);
}

function datepicker(element, showTimer) {
    $(element).persianDatepicker({
        "inline": false,
        "format": "YYYY/MM/DD",
        "viewMode": "day",
        "initialValue": false,
        "initialValueType": 'persian',
        //"minDate": 1526276213699,
        //"maxDate": 1527226613711,
        "autoClose": false,
        "position": "auto",
        "altFormat": "lll",
        "altField": "#altfieldExample",
        "onlyTimePicker": false,
        "onlySelectOnDate": false,
        "calendarType": "persian",
        "inputDelay": "800",
        "observer": false,
        "calendar": {
            "persian": {
                "locale": "fa",
                "showHint": true,
                "leapYearMode": "algorithmic"
            },
            "gregorian": {
                "locale": "en",
                "showHint": false
            }
        },
        "navigator": {
            "enabled": true,
            "scroll": {
                "enabled": true
            },
            "text": {
                "btnNextText": "<",
                "btnPrevText": ">"
            }
        },
        "toolbox": {
            "enabled": true,
            "calendarSwitch": {
                "enabled": false,
                "format": "MMMM"
            },
            "todayButton": {
                "enabled": true,
                "text": {
                    "fa": "امروز",
                    "en": "Today"
                }
            },
            "submitButton": {
                "enabled": true,
                "text": {
                    "fa": "تایید",
                    "en": "Submit"
                }
            },
            "text": {
                "btnToday": "امروز"
            }
        },
        "timePicker": {
            "enabled": showTimer,
            "step": "1",
            "hour": {
                "enabled": true,
                "step": ""
            },
            "minute": {
                "enabled": true,
                "step": null
            },
            "second": {
                "enabled": true,
                "step": null
            },
            "meridian": {
                "enabled": true
            }
        },
        "dayPicker": {
            "enabled": true,
            "titleFormat": "YYYY MMMM"
        },
        "monthPicker": {
            "enabled": true,
            "titleFormat": "YYYY"
        },
        "yearPicker": {
            "enabled": true,
            "titleFormat": "YYYY"
        },
        "responsive": false
    });
}