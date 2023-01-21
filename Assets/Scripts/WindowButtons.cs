using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowButtons : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttons;
    private List<GameObject> _activeButtons = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i].activeSelf)
            {
                _activeButtons.Add(_buttons[i]);
            }
        }
    }

    public void EnableButtons(bool enable)
    {
        for (int i = 0; i < _activeButtons.Count; i++)
        {
            _activeButtons[i].SetActive(enable);
        }
    }
}
