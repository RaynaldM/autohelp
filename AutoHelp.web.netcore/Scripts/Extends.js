/**
 *  Ce fichier vient d'un package Nuget r-framework-web
 * 
 * Toutes corrections apportées ici doit être reporté dans le projet
 *  R-Framework-Web
 * 
 * Les modifications non reporté seront éffacés par la prochaine mise à jour
 * 
 *  Bonne pratique : Créez un fichier App-Extend.js pour vos propres extensions
 */


// Array Extension
if (![].fill) {
    Array.prototype.fill = function (valeur) {

        // Steps 1-2.
        var O = Object(this);

        // Steps 3-5.
        var len = parseInt(O.length);

        // Steps 6-7.
        var debut = arguments[1];
        var debutRelatif = parseInt(debut) || 0;

        // Step 8.
        var k = debutRelatif < 0
            ? Math.max(len + debutRelatif, 0)
            : Math.min(debutRelatif, len);

        // Steps 9-10.
        var fin = arguments[2];
        var finRelative = fin === undefined
            ? len
            : (parseInt(fin) || 0);

        // Step 11.
        var final = finRelative < 0
            ? Math.max(len + finRelative, 0)
            : Math.min(finRelative, len);

        // Step 12.
        for (; k < final; k++) {
            O[k] = valeur;
        }

        // Step 13.
        return O;
    };
}

Array.prototype.distinct = function () {
    var o = {}, i, l = this.length, r = [];
    for (i = 0; i < l; i += 1) o[this[i]] = this[i];
    for (i in o) r.push(o[i]);
    return r;
}

// String extension
String.prototype.format = function () {
    var formatted = this;
    for (var i = 0; i < arguments.length; i++) {
        var regexp = new RegExp('\\{' + i + '\\}', 'gi');
        formatted = formatted.replace(regexp, arguments[i]);
    }
    return formatted;
};

String.prototype.contains = function (it) { return this.indexOf(it) !== -1; };

String.prototype.trim = function () { return this.replace(/^\s+/g, '').replace(/\s+$/g, ''); };

String.prototype.toDate = function () { return new Date(this); }

// Date Extension
Date.prototype.addDay = function (gap) {
    this.setDate(this.getDate() + gap);
    return this;
};

Date.prototype.toISOZeroTime = function () {
    var result = this.toISOString().substring(0, 10);
    return result + "T00:00:00.000Z";
}

Date.prototype.DatePart = function () {
    var newDate = new Date(this);
    return new Date(newDate.setHours(0, 0, 0, 0));
}

Date.prototype.dateDiff = function (date) {
    return this.getTime() - date.getTime();
}

Date.prototype.isBetween = function (from, to) {
    var t = this.getTime();
    return (t <= to.GetTime() && t >= from.getTime());
}

// JQuery
jQuery.fn.extend({
    bootstrapShow: function () {
        return this.removeClass("hidden").addClass("show");
    },
    bootstrapHide: function () {
        return this.removeClass("show").addClass("hidden");
    },
    bootstrapFadeShow: function () {
        return this.fadeIn(200,
            function () {
                return $(this).removeClass("hidden").addClass("show");
            });
    },
    bootstrapFadeHide: function () {
        return this.fadeOut(300,
            function () {
                return $(this).removeClass("show").addClass("hidden");
            });
    }
});

// HandleBars
Handlebars.registerHelper('ifModulo', function (v1, v2, modValue, options) {
    return v1 % v2 === modValue ? options.fn(this) : options.inverse(this);
});
Handlebars.registerHelper('ifCond', function (v1, operator, v2, options) {

    switch (operator) {
        case "==":
            // ReSharper disable once CoercedEqualsUsing
            return (v1 == v2) ? options.fn(this) : options.inverse(this);
        case "===":
            return (v1 === v2) ? options.fn(this) : options.inverse(this);
        case '<':
            return (v1 < v2) ? options.fn(this) : options.inverse(this);
        case '<=':
            return (v1 <= v2) ? options.fn(this) : options.inverse(this);
        case '>':
            return (v1 > v2) ? options.fn(this) : options.inverse(this);
        case '>=':
            return (v1 >= v2) ? options.fn(this) : options.inverse(this);
        case '&&':
            return (v1 && v2) ? options.fn(this) : options.inverse(this);
        case '||':
            return (v1 || v2) ? options.fn(this) : options.inverse(this);
        default:
            return options.inverse(this);
    }
});
Handlebars.registerHelper('for', function (from, to, incr, block) {
    var accum = '';
    for (var i = from; i < to; i += incr)
        accum += block.fn(i);
    return accum;
});
Handlebars.registerHelper('reduce', function (term, length) {
    if (term && term.length > 0 && term.length > length) {
        return term.substr(0, length - 3) + "...";
    }
    return term;
});
Handlebars.registerHelper('rootUrl', function (term) {
    if (term && term.length > 0) {
        var index = term.indexOf("/");
        index = term.indexOf("/", index + 2);
        return term.substr(0, index);
    }
    return term;
});
Handlebars.registerHelper('ratio', function (numerator, denominator, symbol) {
    if (symbol === void 0) symbol = true;
    if (denominator === 0) return "N/A";
    var ratio = numerator / denominator;
    ratio *= 100;
    var result = Math.round(ratio) + (symbol ? "%" : "");

    return result;
});
Handlebars.registerHelper('JsonDateToLocaleDateString', function (jdate) {
    var term = "";
    if (jdate && jdate.length > 0) {
        var date = new Date(jdate);
        term = date.toLocaleDateString();
    }
    return term;
});
Handlebars.registerHelper('JsonDateToLocaleString', function (jdate) {
    var term = "";
    if (jdate && jdate.length > 0) {
        var date = new Date(jdate);
        term = date.toLocaleString();
    }
    return term;
});
Handlebars.registerHelper('JsonDateToLocaleTimeString', function (jdate) {
    var term = "";
    if (jdate && jdate.length > 0) {
        var date = new Date(jdate);
        term = date.toLocaleTimeString();
    }
    return term;
});
Handlebars.registerHelper('JsonDateSince', function (jdate) {
    var term = "";
    if (jdate && jdate.length > 0) {
        var date = moment(jdate).local();
        term = date.fromNow();
    }
    return term;
});
//Handlebars.registerHelper('gravatar', (mail: string,
//    classImg?: string, size?: number,
//    defaultImg?: string, altText?: string) => {
//    return BaseHelpers.GravatarImage(mail, classImg, size, defaultImg, altText);
//});


// Divers
if (navigator.userAgent.match(/IEMobile\/10\.0/)) {
    var msViewportStyle = document.createElement("style");
    msViewportStyle.appendChild(
        document.createTextNode(
            "@-ms-viewport{width:auto!important}"
        )
    );
    document.getElementsByTagName("head")[0].
        appendChild(msViewportStyle);
}