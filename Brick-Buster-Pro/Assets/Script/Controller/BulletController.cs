using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private GameObject prefabObj;
   
    
  

    private void Update()
    {

        Vector3 movement = new Vector3(0f, speed * Time.deltaTime, 0f);
        transform.Translate(movement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BrickCollision brickCollision)) { brickCollision.BrickDecrease(1); }
        ObjectPool.Instance.ReturnObjectToPool(prefabObj,gameObject);
       
    }
}
