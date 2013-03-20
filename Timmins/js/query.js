enquire.register("screen and (max-width:470px)", {
    match: function () {
        $('#side-nav').insertAfter('#featured-news-container');
    },
    unmatch: function () {
        $('#featured-news-container').insertBefore('#side-nav');
    }
}).listen();