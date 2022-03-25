using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{ 
    public static EnemyManager instance;


    public GameObject Exit;

    public static List<GameObject> Enemies = new List<GameObject>();

    private void Awake()
    {
        if(EnemyManager.instance == null){
            
          EnemyManager.instance = this;
          DontDestroyOnLoad(gameObject);

        } else {

            Destroy(gameObject);

        }
         
    }
 


    // Start is called before the first frame update
    void Start()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Debug.Log(Enemies.Count + " Enemies Left");
    }

    public static void KilledEnemy(GameObject Enemy)
    {
       
        Enemies.Remove(Enemy);

        Debug.Log(Enemies.Count + " Enemies Left");

    }


    public bool AreOpponentsDead()
    {
        if (Enemies.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        AreOpponentsDead();
        if (AreOpponentsDead() == true)
        {
            OpenDoor();
            Debug.Log("All Enemies defeated");
        }


    }

    public void OpenDoor()
    {
        Exit.SetActive(false);
    }

}
