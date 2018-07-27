const cheerio = require('cheerio')

module.exports = function (callback, html) {

    const $ = cheerio.load(html)
    let announcements = [];
    // Read the announcement title
    $('.TTHeadergrey:first-child')
        .each(function() { 
            const parent = $(this).parent();
            const obj = {
                Title: $(this).text(),
                Body: parent.next().next().text(),
                PDF: parent.find('.tablebluelink[href$="pdf"]').first().attr('href')
            }
            announcements.push(obj);
        });
    
    callback(/* error */ null, announcements);
};
