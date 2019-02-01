*** Step 1 - Create Cross Pltform Xamarin Blank App

*** Step 2 - Download SQLite nuget pack
SQLite - local DB
In NuGet manager download sqlite-net-pcl

*** Step 3 - Organize project structure
In Common (cross-pltform) solution create folders Data, Views, Models

*** Step 4 - Create in folder  Models OBJECT which will be a table in DB. 
There will be 3 fileds to show information about current task.
Dat class should be inherited from Entity class, where unque guid field ID creates. This field
contains uniwue id of note, and generates for each object of this class

 
*** Step 5 - Create class with methods to work with DB
 Create DatabaseController.cs in Controllers folder
 Check it to see list of methods to work with DB


*** Step 6 - Work with ToDoCP/App.cs
