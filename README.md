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
