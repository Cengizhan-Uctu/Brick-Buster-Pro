using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameController 
{
    public float GetBallForce();
    public void SetBallForce();
    public List<GameObject> GetBallList();
    public void RemoveBrick(GameObject brick);
    public void CollisionCounter(int bouncaStrong);
}
