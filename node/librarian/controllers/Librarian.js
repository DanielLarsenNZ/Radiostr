'use strict';

var url = require('url');


var Librarian = require('./LibrarianService');


module.exports.librarianTrackArtistTitleGet = function librarianTrackArtistTitleGet (req, res, next) {
  var artist = req.swagger.params['artist'].value;
  var title = req.swagger.params['title'].value;
  var album = req.swagger.params['album'].value;
  var duration = req.swagger.params['duration'].value;
  var year = req.swagger.params['year'].value;
  

  var result = Librarian.librarianTrackArtistTitleGet(artist, title, album, duration, year);

  if(typeof result !== 'undefined') {
    res.setHeader('Content-Type', 'application/json');
    res.end(JSON.stringify(result || {}, null, 2));
  }
  else
    res.end();
};
