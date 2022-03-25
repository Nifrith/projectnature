using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static int inventorySize = 20;
    public static ItemManager instance;
    public static GameObject[] inventory = new GameObject[inventorySize];

      private void Awake()
    {
        if(ItemManager.instance == null){
            
          ItemManager.instance = this;
          DontDestroyOnLoad(gameObject);

        } else {

            Destroy(gameObject);

        }
         
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void addItem(GameObject item){
        
        int lenght = inventory.Length;

        for (int i = 0; i < lenght; i++)
        {
            inventory[i] = item;
        }

    }

    public static void removeItem(GameObject item){
        
            inventory = inventory.Where(val => val != item).ToArray();
    }

    public static int inventoryLeft(){

        return inventorySize - inventory.Length;


    }



}
