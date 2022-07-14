using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class CharacterCreator : MonoBehaviour, ISceneLoadHandler<Classes>
{
    [SerializeField] private GameObject[] _characterPrefabs;

    public void OnSceneLoaded(Classes argument)
    {
        Instantiate(_characterPrefabs[(int)argument], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
