using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(PlayerSound))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _jump = KeyCode.Space;
    [SerializeField] private KeyCode _dash = KeyCode.LeftShift;

    [SerializeField] private KeyCode _attack = KeyCode.Mouse0;
    [SerializeField] private KeyCode _strike = KeyCode.Mouse1;
    [SerializeField] private KeyCode _block = KeyCode.Q;
    [SerializeField] private KeyCode _ultimate = KeyCode.R;

    private Character _character;
    private PlayerSound _playerSound;

    private void Start()
    {
        _character = GetComponent<Character>();
        _playerSound = GetComponent<PlayerSound>();
    }

    private void Update()
    {
        if (Input.GetKey(_moveLeft))
        {
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
            _playerSound.PlayJumpClip();
        }

        if (Input.GetKeyDown(_dash))
        {
            _character.Dash();
            _playerSound.PlayDashClip();
        }

        if (Input.GetKeyDown(_attack))
        {
            _character.Attack();
            _playerSound.PlayAttackClip();
        }

        if (Input.GetKeyDown(_strike))
        {
            _character.Strike();
            _playerSound.PlayStrikeClip();
        }

        if (Input.GetKeyDown(_block))
        {
            _character.Block(true);
            _playerSound.PlayBlockClip();
        }
        else if (Input.GetKeyUp(_block))
        {
            _character.Block(false);
        }
    }
}
