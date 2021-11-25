using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool
{
    //Todo:  Init() , Load(), Unload
    List<SpawnObject> objects;
    public int ObjectsCount { get; private set;}

    [SerializeField]
    string targetObjectPath = "WalkingObject";

    Transform spawnPointTrans;
    public ObjectPool(int maxObject, Transform spawnPointTrans)
    {
        objects = new List<SpawnObject>();
        ObjectsCount = maxObject;
        this.spawnPointTrans = spawnPointTrans;
        InitObjectPool(maxObject);
    }

    void InitObjectPool(int maxObject)
    {
        for (int i = 0; i < ObjectsCount; i++)
        {
            var target = Resources.Load(targetObjectPath);
            var newObject = new SpawnObject();
            newObject.gameObject = target as GameObject;
            newObject.isUsing = false;
            newObject.gameObject.SetActive(false);
            newObject.gameObject = GameObject.Instantiate(newObject.gameObject, spawnPointTrans);
            objects.Add(newObject);
        }
    }

    public SpawnObject Load()
    {
        var activeAmount = objects.Where(o => o.isUsing == true).Count();
        if (activeAmount >= ObjectsCount) return null;
        var rt = objects.First(o => o.isUsing == false);
        if (rt == null)
        {
            Debug.Log("Objects amount is max.");
            return null;
        }
        rt.isUsing = true;
        rt.gameObject.SetActive(true);
        return rt;
    }
    
    public void UnLoad(GameObject target)
    {
        var unLoadtarget = objects.Find(o => o.gameObject == target && o.isUsing == true);
        if(unLoadtarget == null)
        {
            Debug.Log("Object unload error.");
            return;
        }
        unLoadtarget.gameObject.SetActive(false);
        unLoadtarget.isUsing = false;
        unLoadtarget.gameObject.GetComponent<NPCMover>().SetPositionToStart();
    }
}

public class SpawnObject
{
    public GameObject gameObject;
    public bool isUsing = false;
}
