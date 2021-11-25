using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoader : MonoBehaviour
{
    ObjectPool npcPool;
    [SerializeField]
    int npcMaxCount = 10;

    [SerializeField]
    Transform spawnPointTrans;
    public Transform SpawnPointTrans => spawnPointTrans;

    public event Action OnMouseLeftClick;
    public event Action OnMouseRightClick;
    private void Awake()
    {
        OnMouseLeftClick += Spawn;
        OnMouseRightClick += UnLoad;
    }
    private void Start()
    {
        npcPool = new ObjectPool(npcMaxCount, spawnPointTrans);
    }

    void Spawn()
    {
        npcPool.Load();
    }

    public void UnLoad()
    {
        var target = GameObject.FindGameObjectWithTag("NPC");
        npcPool.UnLoad(target);
    }

    public void UnLoad(GameObject target)
    {
        npcPool.UnLoad(target);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseLeftClick.Invoke();
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnMouseRightClick.Invoke();
        }
    }
}
