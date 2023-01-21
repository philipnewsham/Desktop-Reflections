using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerWindows : MonoBehaviour
{
    private Window _currentTopWindow;

    private void OnEnable()
    {
        Window.OnWindowSelected += Layer;
    }

    public void Layer(Window topWindow)
    {   
        if(_currentTopWindow != null && _currentTopWindow != topWindow)
        {
            ResetPreviousTopWindowLayer(_currentTopWindow);
        }

        SetTopWindowLayer(topWindow);
    }

    void SetTopWindowLayer(Window window)
    {
        SetWindowLayer(window, "TopWindow");
        _currentTopWindow = window;
    }

    void ResetPreviousTopWindowLayer(Window window)
    {
        SetWindowLayer(window, "Window");
    }

    void SetWindowLayer(Window window, string layer)
    {
        window.SetWindowLayer(layer);
    }

    private void OnDisable()
    {
        Window.OnWindowSelected -= Layer;
    }
}
