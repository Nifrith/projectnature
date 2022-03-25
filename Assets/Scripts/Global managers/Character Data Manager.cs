using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataManager : MonoBehaviour
{
    private static Vector3 lastPlayerPosition;
    private static GameObject character;
    private static Transform _transform;
    private void Awake()
    {
         DontDestroyOnLoad(transform.gameObject);
         _transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         character = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Save player position when entering battle
    public static void saveCharacterPosition()
    {
         lastPlayerPosition = _transform.position;
    }
 
    public void loadCharacterPosition()
    {
        character.transform.position = lastPlayerPosition;
    }

}
