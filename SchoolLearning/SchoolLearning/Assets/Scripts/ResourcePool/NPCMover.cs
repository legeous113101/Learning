using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    PathPoint[] path;


    [SerializeField]
    float speed = 6f;
    int moveIndex = 0;

    Vector3 respawnPoint;

    int MoveIndex
    {
        get => moveIndex;
        set
        {
            if (value < 0 || value > path.Length - 1)
            {
                moveIndex = path.Length - 1;
                return;
            }
            moveIndex = value;
        }
    }

    private void Start()
    {
        path = FindObjectOfType<PathPointCollector>().path;
        respawnPoint = FindObjectOfType<ObjectLoader>().SpawnPointTrans.position;
    }


    public void SetPositionToStart()
    {
        transform.position = respawnPoint;
        MoveIndex = 0;
    }

    void MoveTo(Vector3 destination)
    {
        transform.forward = (destination - transform.position).normalized;
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2f);
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, path[MoveIndex].transform.position) < 1f)
            MoveIndex++;

        //暫時解決來回震盪
        if (Vector3.Distance(transform.position, path[path.Length - 1].transform.position) < 1f)
            return; 
        MoveTo(path[MoveIndex].transform.position);
    }

    private void Update()
    {
        Move();
    }
}
