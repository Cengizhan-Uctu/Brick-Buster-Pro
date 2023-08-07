using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ActiveWallControler : MonoBehaviour
{
    [SerializeField] float activeTime;
    public void StartActiveWall()
    {
        gameObject.SetActive(true);
        StartCoroutine(ActiveWallTimer());
    }
    IEnumerator ActiveWallTimer()
    {
        gameObject.SetActive(true);
        gameObject.transform.DOScaleX(9.5f, .2f).SetEase(Ease.InElastic);
        yield return new WaitForSeconds(activeTime);
        gameObject.transform.DOScaleX(.5f, .2f).SetEase(Ease.InElastic).OnComplete(() => gameObject.SetActive(false));
      
    }

}
