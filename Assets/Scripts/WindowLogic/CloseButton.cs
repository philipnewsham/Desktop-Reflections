using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject _parent;

    private void OnMouseUpAsButton()
    {
        _parent.SetActive(false);
    }
}
