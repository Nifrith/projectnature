using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    public List<GameObject> Enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Debug.Log(Enemies.Count + " Enemies Left");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Enemies.Count);
        OpenGate(Enemies);
    }

    void OpenGate(List<GameObject> list)
    {
       if(list.Count == 0){
           gameObject.SetActive(false);
       }
    }

    public void DeleteEnemy(GameObject gameObject)
    {
       Enemies.Remove(gameObject);
    }
}
