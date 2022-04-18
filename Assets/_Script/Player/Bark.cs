using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public ParticleSystem BarkParticle;
    public GameObject Player;
    public Vector3 DirectionToSheep;
    public float BarkAngle;
    public float BarkRange;
    public LayerMask SheepLayer;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindGameObjectWithTag("BarkTrigger") == null)
        {
            BarkParticle.Play();
            BarkCheck();
        }
        Debug.DrawRay(transform.position, transform.forward + new Vector3(40,0,0), Color.red);
    }

    private void BarkCheck()
    {
        Collider[] CollidersInRange = Physics.OverlapSphere(transform.position, BarkRange, SheepLayer);

        if (CollidersInRange.Length != 0)
        {
            for (int i = 0; i < CollidersInRange.Length; i++)
            {
                DirectionToSheep = (CollidersInRange[i].transform.position - transform.position).normalized;
                
                if (Vector3.Angle(transform.forward, DirectionToSheep) < BarkAngle / 2)
                {
                    PushSheep(CollidersInRange[i].gameObject);
                }
            }
        }
    }

    void PushSheep(GameObject Sheep)
    {
        Sheep.gameObject.GetComponent<SheepManager>().BarkedAt = true;
        Sheep.gameObject.GetComponent<SheepManager>().barkMove = true;
    }
}
