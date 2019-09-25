# INFR3110U-IA1
Individual Assignment 1 - Game Engine Design
*Unity 2019.2.4*

### VSProject

Contains the visual studio project for the Unmanaged (Native) DLL.

The DLL exports 3 functions:
 - bool save(char* path, char* filename, float x, float y, float z)
   - Returns true on success. Saves a file in the format "\[x\],\[y\],\[z\]"
 - bool load(char* path, char* filename, float &x, float &y, float &z)
   - Returns true on success. Loads a file in the above format, and stores the data in x, y, and z.
 - int getError()
   - Basic debug function. Checks an error variable that is set to certain numbers when certain things happen.
  
### UnityProjects

Contains the Unity Project.

All file names are relative to `%appdata%\\IA1-100662175\\`

The unity project imports, and wraps the C/C++ functions with two new saving functions:
 - void savePositionFile(string filename, Vector3 position)
   - Saves the vector to a file.
 - Vector3 loadPositionFile(string filename)
   - Returns the vector stored in the file.
