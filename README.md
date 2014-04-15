Radiost*r
=========
A transmission system and protocol for music playlist data.


Setup
-----
Run "Create Radiostr DB.sql" to create LocalDB.
Rename "TwitterOAuthSettings - example.config" -> 
    "TwitterOAuthSettings.config" and enter Twitter API details, or, 
    comment out the app.UseTwitterAuthentication call in Startup.Auth.cs.

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
