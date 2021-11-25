using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    [SerializeField]
    bool isEndPoint = false;
    private void Awake()
    {
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            FindObjectOfType<ObjectLoader>().UnLoad(other.gameObject);
        }
    }


}
