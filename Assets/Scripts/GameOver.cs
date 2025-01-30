using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gO;

    // Start is called before the first frame update
    void Start()
    {
        gO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    

    }
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("GameObject collided with " + collision.name);
        gO.SetActive(true);
    }
}
