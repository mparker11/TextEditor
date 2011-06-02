*********README*********

The sample code given is a simple text editor. This application allows the user to load, 
edit and save files. You will notice a few methods in conjunction with the event handlers.
Instead of using only event handlers, I created the methods for easier debugging, 
organization and simplifying redundancy. The application (for now) will accept .txt 
and .doc files and will only save to those types as well. In the saveFile() method, I use 
saveIntoSet(), which I created to use a hashset. The hashset is used to help speed up 
the process for bigger files, instead of using a list. 