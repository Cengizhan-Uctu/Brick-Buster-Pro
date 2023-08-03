using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float totalFireTime;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject gunObjLeft;
    [SerializeField] private GameObject gunObjRight;
    private IObjectPoolBullet objPool;
    private bool isFire = false;

    [Inject]
    public void SetGameController(IObjectPoolBullet objPool)
    {
        this.objPool = objPool;
    }
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
