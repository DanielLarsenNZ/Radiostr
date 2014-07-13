Radiost*r
=========
A transmission system and protocol for music playlist data.


Setup
-----
* Run "Create Radiostr DB.sql" to create LocalDB.
* Rename "TwitterOAuthSettings - example.config" -> "TwitterOAuthSettings.config" and enter Twitter API details, or, comment out the app.UseTwitterAuthentication call in Startup.Auth.cs.
* Create your own appSettings.config file to store private settings, e.g.

```
<?xml version="1.0"?>
<appSettings>
  <add key="SpotifyApiClientId" value="abc123..."/>
  <add key="SpotifyApiClientSecret" value="abc123..."/>
</appSettings>
```

OAuth
-----
Follow the steps in http://stackoverflow.com/questions/21065648/asp-net-web-api-2-how-to-login-with-external-authentication-services
