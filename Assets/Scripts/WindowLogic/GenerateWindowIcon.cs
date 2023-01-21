using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWindowIcon : MonoBehaviour
{
    [SerializeField] private Window _windowPrefab;
    [SerializeField] private LayerWindows _layerWindows;
    [SerializeField] private AudioSource _audioSource;
    private Window _generatedWindowPrefab;
    private bool _allowGeneration = true;

    private void OnEnable()
    {
        SpawnPlayer.OnStartLevel += OnStartLevel;
        SpawnPlayer.OnStopLevel += OnStopLevel;
    }

    private void OnStartLevel()
    {
        _allowGeneration = false;
    }

    private void OnStopLevel()
    {
        _allowGeneration = true;
    }

    private void OnMouseUpAsButton()
    {
        if (!_allowGeneration)
        {
            return;
        }

        if(_generatedWindowPrefab == null)
        {
            _generatedWindowPrefab = Instantiate(_windowPrefab, transform.parent);
            LevelWindows.AddWindow(_generatedWindowPrefab);
            _layerWindows.Layer(_generatedWindowPrefab);
        }

        _audioSource.Play();

        if (_generatedWindowPrefab.gameObject.activeInHierarchy)
        {
            return;
        }

        _generatedWindowPrefab.transform.position = Vector3.zero;
        _generatedWindowPrefab.gameObject.SetActive(true);
    }
}
