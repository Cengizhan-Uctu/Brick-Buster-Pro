using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        
        Vector3 movement = new Vector3(0f, speed * Time.deltaTime, 0f);
        transform.Translate(movement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        // poola geri döndür singleton yap
    }
}
