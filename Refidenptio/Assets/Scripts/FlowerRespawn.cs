using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerRespawn : MonoBehaviour
{
    public float respawnTime;
    public float currentRespawnTime;

    public GameObject respawnObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        RespawnObj();
    }

    public void Timer()
    {
        if(currentRespawnTime <= respawnTime)
        {
            currentRespawnTime += Time.deltaTime;
        }
    }

    public void RespawnObj()
    {
        if (currentRespawnTime >= respawnTime)
        {
            currentRespawnTime = 0;
            Instantiate(respawnObj, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
