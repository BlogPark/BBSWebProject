(function () {
    var parent = window.parent;
    //dialog对象
    dialog = parent.$EDITORUI[window.frameElement.id.replace(/_iframe$/, '')];
    //当前打开dialog的编辑器实例
    editor = dialog.editor;

    UE = parent.UE;

    domUtils = UE.dom.domUtils;

    utils = UE.utils;

    browser = UE.browser;

    ajax = UE.ajax;

    $G = function (id) {
        return document.getElementById(id)
    };
    //focus元素
    $focus = function (node) {
        setTimeout(function () {
            if (browser.ie) {
                var r = node.createTextRange();
                r.collapse(false);
                r.select();
            } else {
                node.focus()
            }
        }, 0)
    };
    //自定义图片域名数组
    var filesdomian = filesdomian || [];
    /*
    filesdomian.push("http://img1.yufu.cn");
    filesdomian.push("http://img1.yufu.cn");
    filesdomian.push("http://img2.yufu.cn");
    filesdomian.push("http://img2.yufu.cn");
    filesdomian.push("http://img3.yufu.cn");
    filesdomian.push("http://img3.yufu.cn");
    filesdomian.push("http://img4.yufu.cn");
    filesdomian.push("http://img4.yufu.cn");
    */
    filesdomian.push(editor.options.imageManagerPath);
    filesdomian.push(editor.options.imageManagerPath);
    filesdomian.push(editor.options.imageManagerPath);
    filesdomian.push(editor.options.imageManagerPath);

    /**
    *自定义读取图片域名(根据浏览器并发规则，最好同一个域名成对出现或者三个为一组)
    */
    $getswitchdomian = function () {
        var curr = filesdomian[0].toString();
        filesdomian.shift();
        filesdomian.push(curr);
        return curr;
    };

    utils.loadFile(document, {
        href: editor.options.themePath + editor.options.theme + "/dialogbase.css?cache=" + Math.random(),
        tag: "link",
        type: "text/css",
        rel: "stylesheet"
    });
    lang = editor.getLang(dialog.className.split("-")[2]);
    if (lang) {
        domUtils.on(window, 'load', function () {

            var langImgPath = editor.options.langPath + editor.options.lang + "/images/";
            //针对静态资源
            for (var i in lang["static"]) {
                var dom = $G(i);
                if (!dom) continue;
                var tagName = dom.tagName,
                    content = lang["static"][i];
                if (content.src) {
                    //clone
                    content = utils.extend({}, content, false);
                    content.src = langImgPath + content.src;
                }
                if (content.style) {
                    content = utils.extend({}, content, false);
                    content.style = content.style.replace(/url\s*\(/g, "url(" + langImgPath)
                }
                switch (tagName.toLowerCase()) {
                    case "var":
                        dom.parentNode.replaceChild(document.createTextNode(content), dom);
                        break;
                    case "select":
                        var ops = dom.options;
                        for (var j = 0, oj; oj = ops[j]; ) {
                            oj.innerHTML = content.options[j++];
                        }
                        for (var p in content) {
                            p != "options" && dom.setAttribute(p, content[p]);
                        }
                        break;
                    default:
                        domUtils.setAttributes(dom, content);
                }
            }
        });
    }

})();

