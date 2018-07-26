const cheerio = require('cheerio')
const html = require('./html')

const $ = cheerio.load(html)
const table = $('.content table');
let elements = [];

let obj = {
    title: 'Title here',
    description: 'Description'
}

// table.each(function(i, e){
//     elements.push($(e).text());
// })

// Read the announcement title
$('.TTHeadergrey:first-child')
    .each(function() { 
        const parent = $(this).parent();
        const obj = {
            title: $(this).text(),
            announcement: parent.next().next().text(),
            pdf: parent.find('.tablebluelink[href$="pdf"]').first().attr('href')
        }
        elements.push(obj);
    });


elements.forEach(function (v) {
    console.log(v)
})



// .announceheader Date (single)
// .TTHeadergrey (multiple)


