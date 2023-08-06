using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private GameObject prefabObj;
    private IObjectPool objPool;
    
    [Inject]
    public void SetGameController(IObjectPool objPool)
    {
        this.objPool = objPool;
    }

    private void Update()
    {

        Vector3 movement = new Vector3(0f, speed * Time.deltaTime, 0f);
        transform.Translate(movement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        objPool.ReturnObjectToPool(prefabObj,gameObject);
    }
}
