using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorViewChanger : MonoBehaviour
{
    public static CursorViewChanger Instance;

    [SerializeField] private bool _isCursorActiveOnScene;
    [SerializeField] private Texture2D _mouseTexture;
    [SerializeField] private Vector2 _mouseOffset;

    private void OnEnable()
    {
        if (Instance != null)
            Destroy(this);

        if (Instance == null)
            Instance = this;

        Cursor.SetCursor(_mouseTexture, _mouseOffset, CursorMode.ForceSoftware);

        if (_isCursorActiveOnScene == false)
            Cursor.visible = false;
    }

    private void OnDisable()
    {
        if (Instance == this)
            Instance = null;
    }

    public void SetCursorVisible(bool isVisible)
    {
        Cursor.visible = isVisible;

        if (_isCursorActiveOnScene)
            Cursor.visible = true;
    }
}
