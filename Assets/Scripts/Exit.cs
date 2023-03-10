using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private LevelComplete _levelComplete; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _levelComplete.SetLevelComplete(collision.GetComponent<Player>());
        }
    }
}
