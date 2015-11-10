# Jacob-URL-Shortener
Simple codes to generate short url.

The core of this system is URLShortener.DAL (data access layer). You can modify RepoHelper class to use any database available.

Main driver is in URLShortener.BL.Helper class. View Test project or WEB project for samples.

The idea is to link short codes to long url.

URLShortener.DAL relies on NuGet packages 'System.Data.SQLite', first time users will need to do a NuGet pull.