using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    GameObject[] positionRanges;
    [SerializeField] int maxYRotation = 5;
    [SerializeField] int maxZRotation = 5;
    private float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        positionRanges = GameObject.FindGameObjectsWithTag("WallSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        counter += Time.deltaTime;
        Debug.Log(counter);
        if (counter >= 2f)
        {
            ChangeLocation();
        }
    }
    

    void OnTriggerExit()
    {
        counter = 0;
    }

    void ChangeLocation()
    {
        int index = Random.Range(0, positionRanges.Length);
        transform.position = positionRanges[index].transform.position;
        float zRotation = Random.Range(-maxZRotation, maxZRotation);
        float yRotation = Random.Range(-maxYRotation, maxYRotation);
        transform.Rotate(new Vector3(0, yRotation, zRotation));
        counter = 0;
    }
}