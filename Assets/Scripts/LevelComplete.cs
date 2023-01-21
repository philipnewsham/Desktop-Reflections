using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private float _delayInSeconds = 1.0f;
    [SerializeField] private Transform _levelParent;
    [SerializeField] private SpawnPlayer _spawnPlayer;
    [SerializeField] private Text _levelText;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private int _currentLevel = 1;
    private int _levelCount;

    private void Start()
    {
        _levelCount = _levelParent.childCount;
        SetLevel(_currentLevel);
    }

    void SetLevel(int level)
    {
        _levelParent.GetChild(level - 1).gameObject.SetActive(true);
        _levelText.text = string.Format("Level {0}", _currentLevel);
    }

    void ResetLevel()
    {
        for (int i = 0; i < _levelCount; i++)
        {
            _levelParent.GetChild(i).gameObject.SetActive(false);
        }

        _spawnPlayer.StopLevel();
    }

    public void SetLevelComplete(Player player)
    {
        StartCoroutine(LevelCompleteCoroutine(player));
    }

    IEnumerator LevelCompleteCoroutine(Player player)
    {
        player.FreezePlayer(true);
        _audioSource.Play();
        yield return new WaitForSeconds(_delayInSeconds);

        _currentLevel++;

        player.FreezePlayer(false);
        ResetLevel();
        if (_currentLevel <= _levelCount)
        {
            SetLevel(_currentLevel);
            yield break;
        }

        _levelText.text = "Level -1";
    }
}
