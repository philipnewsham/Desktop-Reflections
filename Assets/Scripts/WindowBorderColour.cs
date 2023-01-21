using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBorderColour : MonoBehaviour
{
    [SerializeField] private LineRenderer[] _lineRenderers;
    [SerializeField] private Color _enableColour;
    [SerializeField] private Color _disableColour;

    public void SetLineRendererColour(bool enable)
    {
        SetLineRendererColour(enable ? _enableColour : _disableColour);
    }

    public void SetLineRendererColour(Color color)
    {
        for (int i = 0; i < _lineRenderers.Length; i++)
        {
            _lineRenderers[i].startColor = color;
            _lineRenderers[i].endColor = color;
        }
    }
}
