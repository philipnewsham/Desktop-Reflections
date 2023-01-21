using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWindowView : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _windowArea;
    [SerializeField] private LineRenderer _windowBorder;
    [SerializeField] private LineRenderer _windowHeader;
    [SerializeField] private Transform _closeButtonTransform;
    [SerializeField] private Transform _flipButtonHorizontalTransform;
    [SerializeField] private Transform _flipButtonVerticalTransform;
    [SerializeField] private Transform _flipButtonVerticalAndHorizontalTransform;
    [SerializeField] private Transform _windowTitleCanvasTransform;
    [SerializeField] private BoxCollider2D _windowHeaderBoxCollider;
    [SerializeField] private Transform _backgroundTransform;

    [ContextMenu("Update Window")]
    public void UpdateWindow()
    {
        ResetOffset(_windowArea.offset);

        Vector2 m_windowOffset = _windowArea.offset;
        Vector2 m_windowSize = _windowArea.size;

        _windowBorder.SetPosition(0, new Vector2(m_windowOffset.x - m_windowSize.x / 2.0f, m_windowOffset.y + m_windowSize.y / 2.0f));
        _windowBorder.SetPosition(1, new Vector2(m_windowOffset.x - m_windowSize.x / 2.0f, m_windowOffset.y - m_windowSize.y / 2.0f));
        _windowBorder.SetPosition(2, new Vector2(m_windowOffset.x + m_windowSize.x / 2.0f, m_windowOffset.y - m_windowSize.y / 2.0f));
        _windowBorder.SetPosition(3, new Vector2(m_windowOffset.x + m_windowSize.x / 2.0f, m_windowOffset.y + m_windowSize.y / 2.0f));

        _windowHeader.SetPosition(0, new Vector2(m_windowOffset.x - (m_windowSize.x / 2.0f) - 0.05f, m_windowOffset.y + (m_windowSize.y / 2.0f) + 0.25f));
        _windowHeader.SetPosition(1, new Vector2(m_windowOffset.x + (m_windowSize.x / 2.0f) + 0.05f, m_windowOffset.y + (m_windowSize.y / 2.0f) + 0.25f));

        _closeButtonTransform.position = new Vector2(m_windowOffset.x + (m_windowSize.x / 2.0f) - 0.25f, m_windowOffset.y + (m_windowSize.y / 2.0f) + 0.25f);
        _flipButtonHorizontalTransform.position = new Vector2(m_windowOffset.x + (m_windowSize.x / 2.0f) - 0.75f, m_windowOffset.y + (m_windowSize.y / 2.0f) + 0.25f);
        _flipButtonVerticalTransform.position = new Vector2(m_windowOffset.x + (m_windowSize.x / 2.0f) - 1.25f, m_windowOffset.y + (m_windowSize.y / 2.0f) + 0.25f);
        _flipButtonVerticalAndHorizontalTransform.position = new Vector2(m_windowOffset.x + (m_windowSize.x / 2.0f) - 1.75f, m_windowOffset.y + (m_windowSize.y / 2.0f) + 0.25f);

        _windowTitleCanvasTransform.position = new Vector2(m_windowOffset.x - (m_windowSize.x / 2.0f) + 0.75f, m_windowOffset.y + (m_windowSize.y / 2.0f) + 0.25f);

        _windowHeaderBoxCollider.size = new Vector2(m_windowSize.x, 0.6f);
        _windowHeaderBoxCollider.offset = new Vector2(m_windowOffset.x, (m_windowSize.y / 2.0f) + 0.2f);

        _backgroundTransform.localPosition = m_windowOffset;
        _backgroundTransform.localScale = m_windowSize;
    }

    private void ResetOffset(Vector3 offset)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position -= offset;
        }

        _windowArea.offset = Vector2.zero;
    }

    public void HideDuplicateButtons()
    {
        _flipButtonHorizontalTransform.gameObject.SetActive(false);
        _flipButtonVerticalTransform.gameObject.SetActive(false);
        _flipButtonVerticalAndHorizontalTransform.gameObject.SetActive(false);
    }
}
