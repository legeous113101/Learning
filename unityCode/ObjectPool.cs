using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public class cObjectData
    {
        public GameObject go;
        public bool bUsing;
    }
    private static ObjectPool mInstance;
    public static ObjectPool Instance() { return mInstance; }

    private List<cObjectData> mData1Container;

    public ObjectPool()
    {
        mInstance = this;
    }

    public void InitData1(Object prefab, int iCount)
    {
        mData1Container = new List<cObjectData>();
        for(int i = 0; i < iCount; i++)
        {
            GameObject go = GameObject.Instantiate(prefab) as GameObject;
            go.SetActive(false);
            cObjectData data = new cObjectData();
            data.bUsing = false;
            data.go = go;
            mData1Container.Add(data);
        }
    }

    public GameObject LoadData1()
    {
        int iCount = mData1Container.Count;
        GameObject rgo = null;
        for (int i = 0; i < iCount; i++)
        {
            if(mData1Container[i].bUsing == false)
            {
                rgo = mData1Container[i].go;
                mData1Container[i].bUsing = true;
                break;
            }
        }
        return rgo;
    }

    public void UnLoadData1(GameObject go)
    {
        int iCount = mData1Container.Count;
        GameObject rgo = null;
        for (int i = 0; i < iCount; i++)
        {
            if (mData1Container[i].go == go)
            {
                mData1Container[i].go.SetActive(false);
                mData1Container[i].bUsing = false;
                break;
            }
        }
    }
}
