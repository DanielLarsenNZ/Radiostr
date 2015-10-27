

    HTTPS GET api.rdostr.com/librarian/track/{artist}/{title}/[{duration}]?[{album}]&[{year}]

```javascript
{ "track": {
    "artist": "Massive Attack",
    "title": "Protection",
    "duration_s": 205,
    "album": "Protection",
    "year": 1994,
    "average_bpm": 78,
    "key": "Dm",
    "assets": {
      "beatgrid": "https://api.serato.com/analysis/track/37872983782" // based on preferred analysis service
    },
    "streams": [{ 
      "uri": "file://xyz/music/massive-attack/protection/protection.mp3", // knows where to find local music
      "content-type": "audio/mp3",
      "bitrate_kbps": 320,
      "is_local": true,
      "priority": 1,
      "checksum": "173892639",
      "filehash": "ab7e879d73f937a948e090d738e22",
      "duration_ms": 205050
    }]
    
    
  }
}
```
