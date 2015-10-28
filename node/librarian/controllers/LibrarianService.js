'use strict';

exports.librarianTrackArtistTitleGet = function(artist, title, album, duration, year) {

  var examples = {};
  
  examples['application/json'] = [ {
  "duration" : 123,
  "artist" : "aeiou",
  "year" : 123,
  "album" : "aeiou",
  "title" : "aeiou",
  "bpm_avg" : 123,
  "key" : "aeiou"
} ];
  

  
  if(Object.keys(examples).length > 0)
    return examples[Object.keys(examples)[0]];
  
}
