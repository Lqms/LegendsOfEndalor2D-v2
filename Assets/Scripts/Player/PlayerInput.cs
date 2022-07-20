using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Direction { get; private set; }

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        Direction = new Vector2(inputHorizontal, 0);
    }
}
