using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using Cinemachine;

public class CharacterCreator : MonoBehaviour, ISceneLoadHandler<Classes>
{
    [SerializeField] private GameObject[] _characterPrefabs;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    public void OnSceneLoaded(Classes argument)
    {
        GameObject character = Instantiate(_characterPrefabs[(int)argument], transform.position, Quaternion.identity);
        _virtualCamera.Follow = character.transform;
        Destroy(gameObject);
    }
}
