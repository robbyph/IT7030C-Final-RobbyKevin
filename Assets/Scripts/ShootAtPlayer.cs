using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPlayer : MonoBehaviour
{
    public GameObject projPrefab;
    public GameObject projSpawnLoc;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootCoRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootCoRoutine()
    {
        while(true)
        {
             yield return new WaitForSeconds(2);

            //spawn bullet
            GameObject projObject = Instantiate(projPrefab);
            
            //what direction should the bullet go?
            Vector2 enemyPos = this.transform.position;
            Vector2 direction = enemyPos - (Vector2)player.transform.position;
            projObject.transform.right = -direction;
            //spawn bulllet where?
            projObject.transform.position = projSpawnLoc.transform.position;
        }
    }
}
