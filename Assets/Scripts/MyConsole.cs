using UnityEngine;
using System.Collections.Generic;

public static class MyConsole
{
    private static string _text = "";
    public static List<string> ConsoleLines = new List<string>();

    public static bool ShowConsole = false;

    public static void WriteToConsole(string text)
    {
      //  Debug.Log(text);

        _text = text;
        ConsoleLines.Add(_text);

        if (ConsoleLines.Count > 5)
            ConsoleLines.RemoveAt(0);
    }
}
