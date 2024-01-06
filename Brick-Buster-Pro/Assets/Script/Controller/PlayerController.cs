using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float totalFireTime;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject gunObjLeft;
    [SerializeField] private GameObject gunObjRight;
    [SerializeField] private GameObject poolPrefab;
    
    private bool isFire = false;

  
    public void ActiveGun()
    {
        
        gunObjLeft.transform.DOLocalMoveY(.7f, .2f);
        gunObjRight.transform.DOLocalMoveY(.7f, .2f).OnComplete(() => StartCoroutine(GunFireTimer()));
    }
    IEnumerator GunFireTimer()
    {

        isFire = true;
        StartCoroutine(GunFire());
        yield return new WaitForSeconds(totalFireTime);
        isFire = false;
    }
    IEnumerator GunFire()
    {
       
        while (isFire == true)
        {
            GameObject bulletLeft = ObjectPool.Instance.GetObjectFromPool(poolPrefab);
            GameObject bulletRight = ObjectPool.Instance.GetObjectFromPool(poolPrefab);
            bulletLeft.transform.position = gunObjLeft.transform.position;
            bulletRight.transform.position = gunObjRight.transform.position;
            yield return new WaitForSeconds(fireRate);
        }

    }
}
