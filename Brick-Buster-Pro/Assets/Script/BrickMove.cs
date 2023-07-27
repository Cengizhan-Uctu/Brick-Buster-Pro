using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BrickMove : MonoBehaviour
{
    [SerializeField] Vector3 fistPos;
    public Vector3 endPoint;
    private void Start()
    {
        transform.position = fistPos;
    }

    public void brickMove()
    {
        transform.DOMove(endPoint, 1).OnComplete(()=>MoveEndFreeChild());
    }
    void MoveEndFreeChild()
    {
        while ( transform.childCount>=1)
        {
           transform.GetChild(0).gameObject.transform.parent=null;
        }
    }
}
