using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class CharacterCreator : MonoBehaviour, ISceneLoadHandler<Classes>
{     
    public void OnSceneLoaded(Classes argument)
    {
        switch (argument)
        {
            case Classes.Warrior:
                Debug.Log("Warrior");
                break;

            case Classes.Archer:
                Debug.Log("Archer");
                break;

            case Classes.Mage:
                Debug.Log("Mage");
                break;
        }
    }
}
