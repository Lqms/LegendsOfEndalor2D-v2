using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBlock : MonoBehaviour
{
    [SerializeField] private GameObject _magicBarrier;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _magicBarrier.SetActive(true);
            GetComponent<Animator>().SetBool("isBlocking", true);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _magicBarrier.SetActive(false);
            GetComponent<Animator>().SetBool("isBlocking", false);
        }
    }
}
