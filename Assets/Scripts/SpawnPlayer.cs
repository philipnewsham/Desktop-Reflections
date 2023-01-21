using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab;
    private Player _generatedPlayerPrefab;
    private bool _isLevelPlaying = false;
    [SerializeField] private Sprite _startPlayingLevelSprite;
    [SerializeField] private Sprite _stopPlayingLevelSprite;
    [SerializeField] private SpriteRenderer _levelStatusSpriteRenderer;
    [SerializeField] private AudioSource _audioSource;

    public static event Action OnStartLevel;
    public static event Action OnStopLevel;

    private void OnMouseUpAsButton()
    {
        _audioSource.Play();

        if (!_isLevelPlaying)
        {
            StartLevel();
            return;
        }

        StopLevel();
    }

    private void StartLevel()
    {
        _isLevelPlaying = true;
        GeneratePlayer();
        LevelWindows.EnableDragWindows(false);
        _levelStatusSpriteRenderer.sprite = _stopPlayingLevelSprite;
        OnStartLevel?.Invoke();
    }

    private void GeneratePlayer()
    {
        if (_generatedPlayerPrefab == null)
        {
            _generatedPlayerPrefab = Instantiate(_playerPrefab, null);
        }

        _generatedPlayerPrefab.gameObject.SetActive(true);
        _generatedPlayerPrefab.transform.position = transform.position;
    }

    public void StopLevel()
    {
        _isLevelPlaying = false;
        _generatedPlayerPrefab.gameObject.SetActive(false);
        LevelWindows.EnableDragWindows(true);
        _levelStatusSpriteRenderer.sprite = _startPlayingLevelSprite;
        OnStopLevel?.Invoke();
    }

}
