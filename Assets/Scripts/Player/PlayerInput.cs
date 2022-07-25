using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _powerAttack = KeyCode.Mouse1;
    [SerializeField] private KeyCode _block = KeyCode.Q;
    [SerializeField] private KeyCode _dash = KeyCode.LeftShift;
    [SerializeField] private KeyCode _ultimate = KeyCode.R;

    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetKey(_moveLeft))
        {
            Debug.Log("left");
            _character.Move(Vector2.left);
            _character.FlipSpriteX(true);
        }
        else if (Input.GetKey(_moveRight))
        {
            _character.Move(Vector2.right);
            _character.FlipSpriteX(false);
        }
        else
        {
            _character.StopMove();
        }

        if (Input.GetKeyDown(_jump))
        {
            _character.Jump();
        }

        if (Input.GetKeyDown(_dash))
        {
            _character.Dash();
        }

        if (Input.GetKeyDown(_attack))
        {
            _character.Attack();
        }

        if (Input.GetKeyDown(_powerAttack))
        {
            _character.PowerAttack();
        }
    }
}
