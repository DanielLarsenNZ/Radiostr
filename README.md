Radiost*r
=========
A transmission system and protocol for music playlist data.


Setup
-----
Run "Create Radiostr DB.sql" to create LocalDB.



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
