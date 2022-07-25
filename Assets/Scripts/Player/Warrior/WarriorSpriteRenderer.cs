using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WarriorSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSPriteX(bool isFlipped)
    {
        _spriteRenderer.flipX = isFlipped;
    }
}
