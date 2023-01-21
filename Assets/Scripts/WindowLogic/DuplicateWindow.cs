using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateWindow : MonoBehaviour
{
    [SerializeField] private Window _windowPrefab;
    private Window _spawnedWindowPrefab;
    [SerializeField] private bool _flipHorizontally;
    [SerializeField] private bool _flipVertically;
    [SerializeField] private BoxCollider2D _windowArea;
    [SerializeField] private Vector2 offset;
    [SerializeField] private AudioSource audioSource;

    private void OnMouseUpAsButton()
    {
        audioSource.Play();

        if (_spawnedWindowPrefab == null)
        {
            _spawnedWindowPrefab = Instantiate(_windowPrefab, _windowPrefab.transform.parent);
            LevelWindows.AddWindow(_spawnedWindowPrefab);
            _spawnedWindowPrefab.HideDuplicateButtons();
        }

        _spawnedWindowPrefab.gameObject.SetActive(true);
        _spawnedWindowPrefab.transform.localScale = new Vector2(_flipHorizontally ? -1 : 1, _flipVertically ? -1 : 1);
        _spawnedWindowPrefab.transform.position = transform.parent.position + new Vector3(_flipHorizontally ? _windowArea.size.x + offset.x : 0.0f, _flipVertically ? _windowArea.size.y + offset.y : 0.0f);
    }
}
