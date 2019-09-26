using UnityEngine;
using System.Runtime.InteropServices;
using System;
public class SaveLoadWrapper
{
    static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\IA1-100662175\\";
    [DllImport("IndividualAssignment1.dll")]
    private static extern bool save(string path, string filename, float x, float y, float z);

    [DllImport("IndividualAssignment1.dll")]
    private static extern bool load(string path, string filename, ref float x, ref float y, ref float z);

    [DllImport("IndividualAssignment1.dll")]
    public static extern int getError();

    public static void savePositionFile(string filename, Vector3 position)
    {
        Console.WriteLine("Saving...");
        bool ok = save(path, filename, position.x, position.y, position.z);
        if (!ok)
        {
            //Console.WriteLine("[SaveLoadWrapper] Failed to save file!");
        }
    }

    public static Vector3 loadPositionFile(string filename)
    {
        Vector3 temp = new Vector3();
        bool ok = load(path, filename, ref temp.x, ref temp.y, ref temp.z);
        if (!ok)
        {
            //Console.WriteLine("[SaveLoadWrapper] Unable to open save file!");
        }
        return temp;
    }
}
