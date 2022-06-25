using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorViewChanger : MonoBehaviour
{
    public static CursorViewChanger Instance;
    public bool IsCursorAtcive;

    [SerializeField] private Texture2D _mouseTexture;
    [SerializeField] private bool _isCursorActiveOnScene;

    void Awake()
    {
        Instance = GetComponent<CursorViewChanger>();
        Cursor.visible = false;
    }

    void OnGUI()
    {
        if (IsCursorAtcive || _isCursorActiveOnScene)
        {
            Vector2 mouse_pos = Event.current.mousePosition;
            GUI.depth = 0;
            GUI.Label(new Rect(mouse_pos.x - 18f, mouse_pos.y - 10f, _mouseTexture.width, _mouseTexture.height), _mouseTexture);
        }
    }
}
