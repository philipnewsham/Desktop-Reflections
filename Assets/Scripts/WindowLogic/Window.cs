using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Window : MonoBehaviour
{
    [SerializeField] private WindowLayer _windowLayer;
    [SerializeField] private UpdateWindowView _updateWindowView;
    [SerializeField] private DragWindow _dragWindow;
    [SerializeField] private WindowBorderColour _windowBorderColour;
    [SerializeField] private WindowButtons _windowButtons;

    public static event Action<Window> OnWindowSelected;

    public void WindowSelected()
    {
        OnWindowSelected?.Invoke(this);
    }

    public void HideDuplicateButtons()
    {
        _updateWindowView.HideDuplicateButtons();
    }

    public void EnableDragWindow(bool enable)
    {
        _dragWindow.enabled = enable;
        _windowBorderColour.SetLineRendererColour(enable);
        _windowButtons.EnableButtons(enable);
    }

    public void SetWindowLayer(string layer)
    {
        _windowLayer.SetWindowLayer(layer);
    }
}
