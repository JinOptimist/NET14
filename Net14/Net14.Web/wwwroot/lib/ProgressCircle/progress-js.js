﻿/*!
 * Circle Progress - v0.2.4 - 2022-05-16
 * https://tigrr.github.io/circle-progress/
 * Copyright (c) Tigran Sargsyan
 * Licensed MIT
 */

"use strict"; function ownKeys(e, t) { var i, n = Object.keys(e); return Object.getOwnPropertySymbols && (i = Object.getOwnPropertySymbols(e), t && (i = i.filter(function (t) { return Object.getOwnPropertyDescriptor(e, t).enumerable })), n.push.apply(n, i)), n } function _objectSpread(e) { for (var t = 1; t < arguments.length; t++) { var i = null != arguments[t] ? arguments[t] : {}; t % 2 ? ownKeys(Object(i), !0).forEach(function (t) { _defineProperty(e, t, i[t]) }) : Object.getOwnPropertyDescriptors ? Object.defineProperties(e, Object.getOwnPropertyDescriptors(i)) : ownKeys(Object(i)).forEach(function (t) { Object.defineProperty(e, t, Object.getOwnPropertyDescriptor(i, t)) }) } return e } function _defineProperty(t, e, i) { return e in t ? Object.defineProperty(t, e, { value: i, enumerable: !0, configurable: !0, writable: !0 }) : t[e] = i, t } function _classCallCheck(t, e) { if (!(t instanceof e)) throw new TypeError("Cannot call a class as a function") } function _defineProperties(t, e) { for (var i = 0; i < e.length; i++) { var n = e[i]; n.enumerable = n.enumerable || !1, n.configurable = !0, "value" in n && (n.writable = !0), Object.defineProperty(t, n.key, n) } } function _createClass(t, e, i) { return e && _defineProperties(t.prototype, e), i && _defineProperties(t, i), t } function _typeof(t) { return (_typeof = "function" == typeof Symbol && "symbol" == typeof Symbol.iterator ? function (t) { return typeof t } : function (t) { return t && "function" == typeof Symbol && t.constructor === Symbol && t !== Symbol.prototype ? "symbol" : typeof t })(t) } !function (i) { "function" == typeof define && define.amd ? define(["jquery"], i) : "object" === ("undefined" == typeof module ? "undefined" : _typeof(module)) && module.exports ? module.exports = function (t, e) { return void 0 === e && (e = "undefined" != typeof window ? require("jquery") : require("jquery")(t)), i(e), e } : i(jQuery) }(function (t) { !function () { try { if ("undefined" == typeof SVGElement || Boolean(SVGElement.prototype.innerHTML)) return } catch (t) { return } function i(t) { switch (t.nodeType) { case 1: return function (t) { var e = ""; e += "<" + t.tagName, t.hasAttributes() && [].forEach.call(t.attributes, function (t) { e += " " + t.name + '="' + t.value + '"' }); e += ">", t.hasChildNodes() && [].forEach.call(t.childNodes, function (t) { e += i(t) }); return e += "</" + t.tagName + ">" }(t); case 3: return t.textContent.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;"); case 8: return "\x3c!--" + t.nodeValue + "--\x3e" } } Object.defineProperty(SVGElement.prototype, "innerHTML", { get: function () { var e = ""; return [].forEach.call(this.childNodes, function (t) { e += i(t) }), e }, set: function (t) { for (; this.firstChild;)this.removeChild(this.firstChild); try { var e = new DOMParser; e.async = !1; var i = "<svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'>" + t + "</svg>", n = e.parseFromString(i, "text/xml").documentElement;[].forEach.call(n.childNodes, function (t) { this.appendChild(this.ownerDocument.importNode(t, !0)) }.bind(this)) } catch (t) { throw new Error("Error parsing markup string") } } }), Object.defineProperty(SVGElement.prototype, "innerSVG", { get: function () { return this.innerHTML }, set: function (t) { this.innerHTML = t } }) }(); function h(t, n, r, a, s) { var o, u = "string" == typeof t ? h.easings[t] : t; requestAnimationFrame(function t(e) { e -= o = o || e, e = Math.min(e, a); var i = u(e, n, r, a); s(i), e < a ? requestAnimationFrame(t) : s(n + r) }) } var e, s, a, o, r = (e = function (t, e, i, n) { var r, a; if (n = n || document, a = Object.create(s), "string" == typeof t && (t = n.querySelector(t)), t) return (r = n.createElementNS("http://www.w3.org/2000/svg", "svg")).setAttribute("version", "1.1"), e && r.setAttribute("width", e), i && r.setAttribute("height", i), e && i && r.setAttribute("viewBox", "0 0 " + e + " " + i), t.appendChild(r), a.svg = r, a }, s = { element: function (t, e, i, n) { var r = a(this, t, e, n); return i && (r.el.innerHTML = i), r } }, a = function (t, e, i, n, r) { var a; return r = r || document, (a = Object.create(o)).el = r.createElementNS("http://www.w3.org/2000/svg", e), a.attr(i), (n ? n.el || n : t.svg).appendChild(a.el), a }, o = { attr: function (t, e) { if (void 0 === t) return this; if ("object" !== _typeof(t)) return void 0 === e ? this.el.getAttributeNS(null, t) : (this.el.setAttribute(t, e), this); for (var i in t) this.attr(i, t[i]); return this }, content: function (t) { return this.el.innerHTML = t, this } }, e); h.easings = { linear: function (t, e, i, n) { return i * t / n + e }, easeInQuad: function (t, e, i, n) { return i * (t /= n) * t + e }, easeOutQuad: function (t, e, i, n) { return -i * (t /= n) * (t - 2) + e }, easeInOutQuad: function (t, e, i, n) { return (t /= n / 2) < 1 ? i / 2 * t * t + e : -i / 2 * (--t * (t - 2) - 1) + e }, easeInCubic: function (t, e, i, n) { return i * (t /= n) * t * t + e }, easeOutCubic: function (t, e, i, n) { return t /= n, i * (--t * t * t + 1) + e }, easeInOutCubic: function (t, e, i, n) { return (t /= n / 2) < 1 ? i / 2 * t * t * t + e : i / 2 * ((t -= 2) * t * t + 2) + e }, easeInQuart: function (t, e, i, n) { return i * (t /= n) * t * t * t + e }, easeOutQuart: function (t, e, i, n) { return t /= n, -i * (--t * t * t * t - 1) + e }, easeInOutQuart: function (t, e, i, n) { return (t /= n / 2) < 1 ? i / 2 * t * t * t * t + e : -i / 2 * ((t -= 2) * t * t * t - 2) + e }, easeInQuint: function (t, e, i, n) { return i * (t /= n) * t * t * t * t + e }, easeOutQuint: function (t, e, i, n) { return t /= n, i * (--t * t * t * t * t + 1) + e }, easeInOutQuint: function (t, e, i, n) { return (t /= n / 2) < 1 ? i / 2 * t * t * t * t * t + e : i / 2 * ((t -= 2) * t * t * t * t + 2) + e }, easeInSine: function (t, e, i, n) { return -i * Math.cos(t / n * (Math.PI / 2)) + i + e }, easeOutSine: function (t, e, i, n) { return i * Math.sin(t / n * (Math.PI / 2)) + e }, easeInOutSine: function (t, e, i, n) { return -i / 2 * (Math.cos(Math.PI * t / n) - 1) + e }, easeInExpo: function (t, e, i, n) { return i * Math.pow(2, 10 * (t / n - 1)) + e }, easeOutExpo: function (t, e, i, n) { return i * (1 - Math.pow(2, -10 * t / n)) + e }, easeInOutExpo: function (t, e, i, n) { return (t /= n / 2) < 1 ? i / 2 * Math.pow(2, 10 * (t - 1)) + e : (t--, i / 2 * (2 - Math.pow(2, -10 * t)) + e) }, easeInCirc: function (t, e, i, n) { return t /= n, -i * (Math.sqrt(1 - t * t) - 1) + e }, easeOutCirc: function (t, e, i, n) { return t /= n, t--, i * Math.sqrt(1 - t * t) + e }, easeInOutCirc: function (t, e, i, n) { return (t /= n / 2) < 1 ? -i / 2 * (Math.sqrt(1 - t * t) - 1) + e : (t -= 2, i / 2 * (Math.sqrt(1 - t * t) + 1) + e) } }; var l, i, n, u = (l = { polarToCartesian: function (t, e) { return { x: t * Math.cos(e * Math.PI / 180), y: t * Math.sin(e * Math.PI / 180) } } }, (i = function () { function s(t) { var e, i = 1 < arguments.length && void 0 !== arguments[1] ? arguments[1] : {}, n = 2 < arguments.length && void 0 !== arguments[2] ? arguments[2] : document; if (_classCallCheck(this, s), "string" == typeof t && (t = n.querySelector(t)), !t) throw new Error("CircleProgress: you must pass the container element as the first argument"); if (t.circleProgress) return t.circleProgress; (t.circleProgress = this).doc = n, t.setAttribute("role", "progressbar"), this.el = t, i = _objectSpread(_objectSpread({}, s.defaults), i), Object.defineProperty(this, "_attrs", { value: {}, enumerable: !1 }), e = "valueOnCircle" === i.textFormat ? 16 : 8, this.graph = { paper: r(t, 100, 100), value: 0 }, this.graph.paper.svg.setAttribute("class", "circle-progress"), this.graph.circle = this.graph.paper.element("circle").attr({ class: "circle-progress-circle", cx: 50, cy: 50, r: 50 - e / 2, fill: "none", stroke: "#ddd", "stroke-width": e }), this.graph.sector = this.graph.paper.element("path").attr({ d: s._makeSectorPath(50, 50, 50 - e / 2, 0, 0), class: "circle-progress-value", fill: "none", stroke: "#00E699", "stroke-width": e }), this.graph.text = this.graph.paper.element("text", { class: "circle-progress-text", x: 50, y: 50, font: "16px Arial, sans-serif", "text-anchor": "middle", fill: "#999" }), this._initText(), this.attr(["indeterminateText", "textFormat", "startAngle", "clockwise", "animation", "animationDuration", "constrain", "min", "max", "value"].filter(function (t) { return t in i }).map(function (t) { return [t, i[t]] })) } return _createClass(s, [{ key: "value", get: function () { return this._attrs.value }, set: function (t) { this.attr("value", t) } }, { key: "min", get: function () { return this._attrs.min }, set: function (t) { this.attr("min", t) } }, { key: "max", get: function () { return this._attrs.max }, set: function (t) { this.attr("max", t) } }, { key: "startAngle", get: function () { return this._attrs.startAngle }, set: function (t) { this.attr("startAngle", t) } }, { key: "clockwise", get: function () { return this._attrs.clockwise }, set: function (t) { this.attr("clockwise", t) } }, { key: "constrain", get: function () { return this._attrs.constrain }, set: function (t) { this.attr("constrain", t) } }, { key: "indeterminateText", get: function () { return this._attrs.indeterminateText }, set: function (t) { this.attr("indeterminateText", t) } }, { key: "textFormat", get: function () { return this._attrs.textFormat }, set: function (t) { this.attr("textFormat", t) } }, { key: "animation", get: function () { return this._attrs.animation }, set: function (t) { this.attr("animation", t) } }, { key: "animationDuration", get: function () { return this._attrs.animationDuration }, set: function (t) { this.attr("animationDuration", t) } }]), _createClass(s, [{ key: "attr", value: function (e, t) { var i = this; if ("string" == typeof e) return 1 === arguments.length ? this._attrs[e] : (this._set(arguments[0], t), this._updateGraph(), this); if ("object" !== _typeof(e)) throw new TypeError('Wrong argument passed to attr. Expected object, got "'.concat(_typeof(e), '"')); return Array.isArray(e) || (e = Object.keys(e).map(function (t) { return [t, e[t]] })), e.forEach(function (t) { return i._set(t[0], t[1]) }), this._updateGraph(), this } }, { key: "_set", value: function (t, e) { var i, n = { value: "aria-valuenow", min: "aria-valuemin", max: "aria-valuemax" }; if (void 0 === (e = this._formatValue(t, e))) throw new TypeError("Failed to set the ".concat(t, " property on CircleProgress: The provided value is non-finite.")); this._attrs[t] !== e && ("min" === t && e >= this.max || "max" === t && e <= this.min || ("value" === t && void 0 !== e && this.constrain && (null != this.min && e < this.min && (e = this.min), null != this.max && e > this.max && (e = this.max)), this._attrs[t] = e, t in n && (void 0 !== e ? this.el.setAttribute(n[t], e) : this.el.removeAttribute(n[t])), -1 !== ["min", "max", "constrain"].indexOf(t) && (this.value > this.max || this.value < this.min) && (this.value = Math.min(this.max, Math.max(this.min, this.value))), "textFormat" === t && (this._initText(), i = "valueOnCircle" === e ? 16 : 8, this.graph.sector.attr("stroke-width", i), this.graph.circle.attr("stroke-width", i)))) } }, { key: "_formatValue", value: function (t, e) { switch (t) { case "value": case "min": case "max": e = parseFloat(e), isFinite(e) || (e = void 0); break; case "startAngle": e = parseFloat(e), e = isFinite(e) ? Math.max(0, Math.min(360, e)) : void 0; break; case "clockwise": case "constrain": e = !!e; break; case "indeterminateText": e = "" + e; break; case "textFormat": if ("function" != typeof e && -1 === ["valueOnCircle", "horizontal", "vertical", "percent", "value", "none"].indexOf(e)) throw new Error('Failed to set the "textFormat" property on CircleProgress: the provided value "'.concat(e, '" is not a legal textFormat identifier.')); break; case "animation": if ("string" != typeof e && "function" != typeof e) throw new TypeError('Failed to set "animation" property on CircleProgress: the value must be either string or function, '.concat(_typeof(e), " passed.")); if ("string" == typeof e && "none" !== e && !h.easings[e]) throw new Error('Failed to set "animation" on CircleProgress: the provided value '.concat(e, " is not a legal easing function name.")) }return e } }, { key: "_valueToAngle", value: function (t) { var e = 0 < arguments.length && void 0 !== t ? t : this.value; return Math.min(360, Math.max(0, (e - this.min) / (this.max - this.min) * 360)) } }, { key: "_isIndeterminate", value: function () { return !("number" == typeof this.value && "number" == typeof this.max && "number" == typeof this.min) } }, { key: "_positionValueText", value: function (t, e) { var i = l.polarToCartesian(e, t); this.graph.textVal.attr({ x: 50 + i.x, y: 50 + i.y }) } }, { key: "_initText", value: function () { switch (this.graph.text.content(""), this.textFormat) { case "valueOnCircle": this.graph.textVal = this.graph.paper.element("tspan", { x: 0, y: 0, dy: "0.4em", class: "circle-progress-text-value", "font-size": "12", fill: "valueOnCircle" === this.textFormat ? "#fff" : "#888" }, "", this.graph.text), this.graph.textMax = this.graph.paper.element("tspan", { x: 50, y: 50, class: "circle-progress-text-max", "font-size": "22", "font-weight": "bold", fill: "#ddd" }, "", this.graph.text), this.graph.text.el.hasAttribute("dominant-baseline") || this.graph.textMax.attr("dy", "0.4em"); break; case "horizontal": this.graph.textVal = this.graph.paper.element("tspan", { class: "circle-progress-text-value" }, "", this.graph.text), this.graph.textSeparator = this.graph.paper.element("tspan", { class: "circle-progress-text-separator" }, "/", this.graph.text), this.graph.textMax = this.graph.paper.element("tspan", { class: "circle-progress-text-max" }, "", this.graph.text); break; case "vertical": this.graph.text.el.hasAttribute("dominant-baseline") && this.graph.text.attr("dominant-baseline", "text-after-edge"), this.graph.textVal = this.graph.paper.element("tspan", { class: "circle-progress-text-value", x: 50, dy: "-0.2em" }, "", this.graph.text), this.graph.textSeparator = this.graph.paper.element("tspan", { class: "circle-progress-text-separator", x: 50, dy: "0.1em", "font-family": "Arial, sans-serif" }, "___", this.graph.text), this.graph.textMax = this.graph.paper.element("tspan", { class: "circle-progress-text-max", x: 50, dy: "1.2em" }, "", this.graph.text) }"vertical" !== this.textFormat && (this.graph.text.el.hasAttribute("dominant-baseline") ? this.graph.text.attr("dominant-baseline", "central") : this.graph.text.attr("dy", "0.4em")) } }, { key: "_updateGraph", value: function () { var e, i, n = this, r = this.startAngle - 90, a = this._getRadius(); this._isIndeterminate() ? this._updateText(this.value, r, a) : (e = this.clockwise, i = this._valueToAngle(), this.graph.circle.attr("r", a), "none" !== this.animation && this.value !== this.graph.value ? h(this.animation, this.graph.value, this.value - this.graph.value, this.animationDuration, function (t) { n._updateText(Math.round(t), (2 * r + i) / 2, a), i = n._valueToAngle(t), n.graph.sector.attr("d", s._makeSectorPath(50, 50, a, r, i, e)) }) : (this.graph.sector.attr("d", s._makeSectorPath(50, 50, a, r, i, e)), this._updateText(this.value, (2 * r + i) / 2, a)), this.graph.value = this.value) } }, { key: "_updateText", value: function (t, e, i) { "function" == typeof this.textFormat ? this.graph.text.content(this.textFormat(t, this.max)) : "value" === this.textFormat ? this.graph.text.el.textContent = void 0 !== t ? t : this.indeterminateText : "percent" === this.textFormat ? this.graph.text.el.textContent = (void 0 !== t && null != this.max ? Math.round(t / this.max * 100) : this.indeterminateText) + "%" : "none" === this.textFormat ? this.graph.text.el.textContent = "" : (this.graph.textVal.el.textContent = void 0 !== t ? t : this.indeterminateText, this.graph.textMax.el.textContent = void 0 !== this.max ? this.max : this.indeterminateText), "valueOnCircle" === this.textFormat && this._positionValueText(e, i) } }, { key: "_getRadius", value: function () { return 50 - Math.max(parseFloat(this.doc.defaultView.getComputedStyle(this.graph.circle.el, null)["stroke-width"]), parseFloat(this.doc.defaultView.getComputedStyle(this.graph.sector.el, null)["stroke-width"])) / 2 } }], [{ key: "_makeSectorPath", value: function (t, e, i, n, r, a) { 0 < r && r < .3 ? r = 0 : 359.999 < r && (r = 359.999); var s = n + r * (2 * (a = !!a) - 1), o = l.polarToCartesian(i, n), u = l.polarToCartesian(i, s), h = t + o.x, c = t + u.x; return ["M", h, e + o.y, "A", i, i, 0, +(180 < r), +a, c, e + u.y].join(" ") } }]), s }()).defaults = { startAngle: 0, min: 0, max: 1, constrain: !0, indeterminateText: "?", clockwise: !0, textFormat: "horizontal", animation: "easeInOutCubic", animationDuration: 600 }, i); n = function (c) { var r, i = 0, o = Array.prototype.slice; c.cleanData = (r = c.cleanData, function (t) { for (var e, i, n = 0; null != (i = t[n]); n++)try { (e = c._data(i, "events")) && e.remove && c(i).triggerHandler("remove") } catch (t) { } r(t) }), c.widget = function (t, i, e) { var n, r, a, s, o = {}, u = t.split(".")[0]; return t = t.split(".")[1], n = u + "-" + t, e || (e = i, i = c.Widget), c.expr[":"][n.toLowerCase()] = function (t) { return !!c.data(t, n) }, c[u] = c[u] || {}, r = c[u][t], a = c[u][t] = function (t, e) { if (!this._createWidget) return new a(t, e); arguments.length && this._createWidget(t, e) }, c.extend(a, r, { version: e.version, _proto: c.extend({}, e), _childConstructors: [] }), (s = new i).options = c.widget.extend({}, s.options), c.each(e, function (e, n) { function r() { return i.prototype[e].apply(this, arguments) } function a(t) { return i.prototype[e].apply(this, t) } c.isFunction(n) ? o[e] = function () { var t, e = this._super, i = this._superApply; return this._super = r, this._superApply = a, t = n.apply(this, arguments), this._super = e, this._superApply = i, t } : o[e] = n }), a.prototype = c.widget.extend(s, { widgetEventPrefix: r && s.widgetEventPrefix || t }, o, { constructor: a, namespace: u, widgetName: t, widgetFullName: n }), r ? (c.each(r._childConstructors, function (t, e) { var i = e.prototype; c.widget(i.namespace + "." + i.widgetName, a, e._proto) }), delete r._childConstructors) : i._childConstructors.push(a), c.widget.bridge(t, a), a }, c.widget.extend = function (t) { for (var e, i, n = o.call(arguments, 1), r = 0, a = n.length; r < a; r++)for (e in n[r]) i = n[r][e], n[r].hasOwnProperty(e) && void 0 !== i && (c.isPlainObject(i) ? t[e] = c.isPlainObject(t[e]) ? c.widget.extend({}, t[e], i) : c.widget.extend({}, i) : t[e] = i); return t }, c.widget.bridge = function (a, e) { var s = e.prototype.widgetFullName || a; c.fn[a] = function (i) { var t = "string" == typeof i, n = o.call(arguments, 1), r = this; return t ? this.each(function () { var t, e = c.data(this, s); return "instance" === i ? (r = e, !1) : e ? c.isFunction(e[i]) && "_" !== i.charAt(0) ? (t = e[i].apply(e, n)) !== e && void 0 !== t ? (r = t && t.jquery ? r.pushStack(t.get()) : t, !1) : void 0 : c.error("no such method '" + i + "' for " + a + " widget instance") : c.error("cannot call methods on " + a + " prior to initialization; attempted to call method '" + i + "'") }) : (n.length && (i = c.widget.extend.apply(null, [i].concat(n))), this.each(function () { var t = c.data(this, s); t ? (t.option(i || {}), t._init && t._init()) : c.data(this, s, new e(i, this)) })), r } }, c.Widget = function () { }, c.Widget._childConstructors = [], c.Widget.prototype = { widgetName: "widget", widgetEventPrefix: "", defaultElement: "<div>", options: { disabled: !1, create: null }, _createWidget: function (t, e) { e = c(e || this.defaultElement || this)[0], this.element = c(e), this.uuid = i++, this.eventNamespace = "." + this.widgetName + this.uuid, this.bindings = c(), this.hoverable = c(), this.focusable = c(), e !== this && (c.data(e, this.widgetFullName, this), this._on(!0, this.element, { remove: function (t) { t.target === e && this.destroy() } }), this.document = c(e.style ? e.ownerDocument : e.document || e), this.window = c(this.document[0].defaultView || this.document[0].parentWindow)), this.options = c.widget.extend({}, this.options, this._getCreateOptions(), t), this._create(), this._trigger("create", null, this._getCreateEventData()), this._init() }, _getCreateOptions: c.noop, _getCreateEventData: c.noop, _create: c.noop, _init: c.noop, destroy: function () { this._destroy(), this.element.unbind(this.eventNamespace).removeData(this.widgetFullName).removeData(c.camelCase(this.widgetFullName)), this.widget().unbind(this.eventNamespace).removeAttr("aria-disabled").removeClass(this.widgetFullName + "-disabled ui-state-disabled"), this.bindings.unbind(this.eventNamespace), this.hoverable.removeClass("ui-state-hover"), this.focusable.removeClass("ui-state-focus") }, _destroy: c.noop, widget: function () { return this.element }, option: function (t, e) { var i, n, r, a = t; if (0 === arguments.length) return c.widget.extend({}, this.options); if ("string" == typeof t) if (a = {}, t = (i = t.split(".")).shift(), i.length) { for (n = a[t] = c.widget.extend({}, this.options[t]), r = 0; r < i.length - 1; r++)n[i[r]] = n[i[r]] || {}, n = n[i[r]]; if (t = i.pop(), 1 === arguments.length) return void 0 === n[t] ? null : n[t]; n[t] = e } else { if (1 === arguments.length) return void 0 === this.options[t] ? null : this.options[t]; a[t] = e } return this._setOptions(a), this }, _setOptions: function (t) { var e; for (e in t) this._setOption(e, t[e]); return this }, _setOption: function (t, e) { return this.options[t] = e, "disabled" === t && (this.widget().toggleClass(this.widgetFullName + "-disabled", !!e), e && (this.hoverable.removeClass("ui-state-hover"), this.focusable.removeClass("ui-state-focus"))), this }, enable: function () { return this._setOptions({ disabled: !1 }) }, disable: function () { return this._setOptions({ disabled: !0 }) }, _on: function (s, o, t) { var u, h = this; "boolean" != typeof s && (t = o, o = s, s = !1), t ? (o = u = c(o), this.bindings = this.bindings.add(o)) : (t = o, o = this.element, u = this.widget()), c.each(t, function (t, e) { function i() { if (s || !0 !== h.options.disabled && !c(this).hasClass("ui-state-disabled")) return ("string" == typeof e ? h[e] : e).apply(h, arguments) } "string" != typeof e && (i.guid = e.guid = e.guid || i.guid || c.guid++); var n = t.match(/^([\w:-]*)\s*(.*)$/), r = n[1] + h.eventNamespace, a = n[2]; a ? u.delegate(a, r, i) : o.bind(r, i) }) }, _off: function (t, e) { e = (e || "").split(" ").join(this.eventNamespace + " ") + this.eventNamespace, t.unbind(e).undelegate(e), this.bindings = c(this.bindings.not(t).get()), this.focusable = c(this.focusable.not(t).get()), this.hoverable = c(this.hoverable.not(t).get()) }, _delay: function (t, e) { var i = this; return setTimeout(function () { return ("string" == typeof t ? i[t] : t).apply(i, arguments) }, e || 0) }, _hoverable: function (t) { this.hoverable = this.hoverable.add(t), this._on(t, { mouseenter: function (t) { c(t.currentTarget).addClass("ui-state-hover") }, mouseleave: function (t) { c(t.currentTarget).removeClass("ui-state-hover") } }) }, _focusable: function (t) { this.focusable = this.focusable.add(t), this._on(t, { focusin: function (t) { c(t.currentTarget).addClass("ui-state-focus") }, focusout: function (t) { c(t.currentTarget).removeClass("ui-state-focus") } }) }, _trigger: function (t, e, i) { var n, r, a = this.options[t]; if (i = i || {}, (e = c.Event(e)).type = (t === this.widgetEventPrefix ? t : this.widgetEventPrefix + t).toLowerCase(), e.target = this.element[0], r = e.originalEvent) for (n in r) n in e || (e[n] = r[n]); return this.element.trigger(e, i), !(c.isFunction(a) && !1 === a.apply(this.element[0], [e].concat(i)) || e.isDefaultPrevented()) } }, c.each({ show: "fadeIn", hide: "fadeOut" }, function (a, s) { c.Widget.prototype["_" + a] = function (e, t, i) { "string" == typeof t && (t = { effect: t }); var n, r = t ? !0 !== t && "number" != typeof t && t.effect || s : a; "number" == typeof (t = t || {}) && (t = { duration: t }), n = !c.isEmptyObject(t), t.complete = i, t.delay && e.delay(t.delay), n && c.effects && c.effects.effect[r] ? e[a](t) : r !== a && e[r] ? e[r](t.duration, t.easing, i) : e.queue(function (t) { c(this)[a](), i && i.call(e[0]), t() }) } }); c.widget }, "function" == typeof define && define.amd ? define(["jquery"], n) : n(t), t.widget("tl.circleProgress", { options: t.extend({}, u.defaults), _create: function () { this.circleProgress = new u(this.element[0], this.options), this.options = this.circleProgress._attrs }, _destroy: function () { }, _setOptions: function (t) { this.circleProgress.attr(t) }, value: function (t) { if (void 0 === t) return this.options.value; this._setOptions({ value: t }) }, min: function (t) { if (void 0 === t) return this.options.min; this._setOptions({ min: t }) }, max: function (t) { if (void 0 === t) return this.options.max; this._setOptions({ max: t }) } }), t.fn.circleProgress.defaults = u.defaults });