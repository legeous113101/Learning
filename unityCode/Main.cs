using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    ObjectPool mPool;
    public Object prefab;
    private List<GameObject> mLoadedObjects;
    void Awake()
    {
        mPool = new ObjectPool();
        mPool.InitData1(prefab, 100);
        mLoadedObjects = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject go = mPool.LoadData1();
            go.SetActive(true);
            go.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            mLoadedObjects.Add(go);
        }

        if (Input.GetMouseButtonDown(1))
        {
            int iCount = mLoadedObjects.Count;
            if (iCount > 0)
            {
                int id = Random.Range(0, iCount);
                Debug.Log("id " + id);
                GameObject go = mLoadedObjects[id];
                mPool.UnLoadData1(go);
                mLoadedObjects.RemoveAt(id);
            }
        }
    }
}
