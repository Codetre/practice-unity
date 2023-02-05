using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestnutBurrController : MonoBehaviour
{
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void Start()
    {
        // Shoot(new Vector3(0, 200, 2000));
    }

    void Update()
    {
        

    }

    void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }

    // 4. 지면에 떨어진 밤송이는 없앤다.
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Terrain")
        {
            Destroy(gameObject);
        }
    }
}
