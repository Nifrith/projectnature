using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{ 
    public static EnemyManager instance;

    public GameObject enemiesLeftText;
    public static TextMeshProUGUI questText;

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
        questText = enemiesLeftText.GetComponent<TextMeshProUGUI>();
        questText.text = "Derrota a los enemigos para llegar al jefe // Queda/n "+Enemies.Count+" enemigo/s"; 
    }

    public static void KilledEnemy(GameObject Enemy)
    {
       
        Enemies.Remove(Enemy);

        Debug.Log(Enemies.Count + " Enemies Left");
         questText.text = "Derrota a los enemigos para llegar al jefe // Queda/n "+Enemies.Count+" enemigo/s"; 

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
            questText.text = "Todos los enemigos han sido derrotados, ya puedes pelear contra el jefe ";
        }


    }

    public void OpenDoor()
    {
        Exit.SetActive(false);
    }

}
