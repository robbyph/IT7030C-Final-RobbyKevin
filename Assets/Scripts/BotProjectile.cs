using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotProjectile : MonoBehaviour
{
    public float projSpeed = 3.0f;
    public float projLifeTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, projLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * projSpeed);
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         collision.gameObject.GetComponent<PlayerMove>().life -= 1;
    //     }
    // }
}
