using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _changeColorTime = 0.2f;
    [SerializeField] private AudioClip _damageTakenClip;
    [SerializeField] private AudioClip _dyingClip;

    private SpriteRenderer _spriteRenderer;
    private Color _normalColor;
    private Color _damagedColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _normalColor = _spriteRenderer.color;
        _damagedColor = new Color(1, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Attacker attacker))
        {
            _health -= attacker.Damage;

            if (_health <= 0)
            {
                AudioManager.Instance.PlaySound(_dyingClip);
                Destroy(gameObject);
            }
            else
            {
                AudioManager.Instance.PlaySound(_damageTakenClip);
                StartCoroutine(ChangingColor());
            }
        }
    }

    private IEnumerator ChangingColor()
    {
        _spriteRenderer.color = _damagedColor;
        yield return new WaitForSeconds(_changeColorTime);
        _spriteRenderer.color = _normalColor;
    }
}
