Radiost*r
=========
A transmission system and protocol for music playlist data.


Setup
-----
Run "Create Radiostr DB.sql" to create LocalDB.
Rename "TwitterOAuthSettings - example.config" -> 
    "TwitterOAuthSettings.config" and enter Twitter API details, or, 
    comment out the app.UseTwitterAuthentication call in Startup.Auth.cs.

OAuth
-----
Follow the steps in http://stackoverflow.com/questions/21065648/asp-net-web-api-2-how-to-login-with-external-authentication-services

Stories
-------
* As a user, I want to submit a Track to my library with a URI and a tag.

{
    StationId: 123,
    LibraryId: 456,
    Tracks: []
    {
        Title: "Title",
        Artist: "Artist",
        Duration: "3:30",
        Uri: "http://spotify.com/track/tr67uw783y",
        Tags: "reggae, dub"
    }
}

API (WIP)
---------
+ LibraryAdd()
+ PlayerHub()
    + .Play()
    + .GetNext(playlist)
    + .GetNext(library)

Model (WIP)
-----------

*User*
+ Entity
+ Mutable

*Station*
+ Entity
+ Mutable

*Library*
+ Entity
+ Mutable

*LibraryTrack*
+ Value
+ Immutable

*Track*
+ Value
+ Immutable

*Playlist*
+ Value
+ Immutable

*PlaylistTrack*
+ Value
+ Immutable
