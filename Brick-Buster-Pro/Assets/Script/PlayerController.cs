using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float totalFireTime;
    [SerializeField] float fireRate;
    [SerializeField] GameObject gunObjLeft;
    [SerializeField] GameObject gunObjRight;
    [SerializeField] BulletObjectPool objPool;
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
            GameObject bulletLeft = objPool.GetObjectFromPool();
            GameObject bulletRight = objPool.GetObjectFromPool();
            bulletLeft.transform.position = gunObjLeft.transform.position;
            bulletRight.transform.position = gunObjRight.transform.position;
            yield return new WaitForSeconds(fireRate);
        }

    }
}
