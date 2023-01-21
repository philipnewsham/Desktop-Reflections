using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelWindows
{
    private static List<Window> _windows = new List<Window>();

    public static void AddWindow(Window window)
    {
        if (_windows.Contains(window))
        {
            return;
        }

        _windows.Add(window);
    }

    public static void ClearWindows()
    {
        _windows.Clear();
    }

    public static void EnableDragWindows(bool enable)
    {
        for (int i = 0; i < _windows.Count; i++)
        {
            _windows[i].EnableDragWindow(enable);
        }
    }
}
