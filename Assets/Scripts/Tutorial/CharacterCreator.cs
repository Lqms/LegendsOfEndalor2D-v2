using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using Cinemachine;

public class CharacterCreateHandler : MonoBehaviour, ISceneLoadHandler<Classes>
{
    [SerializeField] private GameObject[] _characterPrefabs;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [Header("For tests")]
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private bool _isTest;

    public void OnSceneLoaded(Classes argument)
    {
        GameObject character = Instantiate(_characterPrefabs[(int)argument], transform.position, Quaternion.identity);     
        _virtualCamera.Follow = character.transform;
        Destroy(gameObject);
    }

    private void Start()
    {
        if (_isTest)
        {
            GameObject character = Instantiate(_characterPrefab, transform.position, Quaternion.identity);
            _virtualCamera.Follow = character.transform;
            Destroy(gameObject);
        }
    }
}
