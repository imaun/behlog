var input = document.querySelectorAll(".js-date-mask")[0];

var dateInputMask = function dateInputMask(elm) {
    elm.addEventListener("keypress", function (e) {
        if ((e.keyCode < 47 || e.keyCode > 57) || e.keyCode === 32) {
            e.preventDefault();
        }

        var len = elm.value.length;

        // If we're at a particular place, let the user type the slash
        // i.e., 12/12/1212
        if (len !== 1 || len !== 3) {
            if (e.keyCode === 47) {
                e.preventDefault();
            }
        }

        // If they don't add the slash, do it for them...
        if (len === 2) {
            elm.value += "/";
        }

        // If they don't add the slash, do it for them...
        if (len === 5) {
            elm.value += "/";
        }

        if(len === 11) {
            elm.value += ":";
        }
    });
};

dateInputMask(input);