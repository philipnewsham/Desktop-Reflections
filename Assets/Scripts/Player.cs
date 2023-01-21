using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _movementSpeed = 5.0f;
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private AudioSource _audioSource;
    private int _layerMask;

    [SerializeField] private float _walkingAngleAmount = 15.0f;
    [SerializeField] private float _walkingSpeed = 5.0f;

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Block");
    }

    void Update()
    {
        Vector3 m_direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f) * _movementSpeed * Time.deltaTime;
        transform.position += m_direction;

        if (m_direction.x != 0.0f)
        {
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, Mathf.Lerp(-_walkingAngleAmount, _walkingAngleAmount, (Mathf.Sin(Time.realtimeSinceStartup * _walkingSpeed) + 1) / 2.0f));
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (IsPlayerGrounded())
            {
                _audioSource.Play();
                _rigidbody.AddForce(Vector2.up * _jumpForce);
                _isGrounded = false;
                return;
            }
        }
    }

    private bool IsPlayerGrounded()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, _layerMask, 0.0f, 0.0f);
        return _isGrounded;
    }

    public void FreezePlayer(bool isFrozen)
    {
        _rigidbody.isKinematic = isFrozen;
        _rigidbody.velocity = Vector2.zero;
        enabled = !isFrozen;
    }
}
