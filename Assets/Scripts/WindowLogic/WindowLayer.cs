using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLayer : MonoBehaviour
{
    [SerializeField] private LineRenderer[] _lineRenderers;
    [SerializeField] private SpriteRenderer[] _spriteRenderers;
    [SerializeField] private Transform _playArea;
    [SerializeField] private Canvas _windowCanvas;

    public void SetWindowLayer(string layer)
    {
        for (int i = 0; i < _lineRenderers.Length; i++)
        {
            _lineRenderers[i].sortingLayerName = layer;
        }

        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _spriteRenderers[i].sortingLayerName = layer;
        }

        for (int i = 0; i < _playArea.childCount; i++)
        {
            if (!_playArea.GetChild(i).GetComponent<SpriteRenderer>())
            {
                continue;
            }

            _playArea.GetChild(i).GetComponent<SpriteRenderer>().sortingLayerName = layer;
        }

        _windowCanvas.sortingLayerName = layer;
    }
}
