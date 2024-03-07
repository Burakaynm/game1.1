using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [Serializable]
    public struct Pool
    {
        public List<GameObject> poolObjs;
        public GameObject objPrefab;
        public int poolSize;
    }

    //private List<GameObject> pooledObjs = new List<GameObject>();
    //private int poolSize = 10;

    [SerializeField] public Pool[] pools = null;


    //[SerializeField] private GameObject projectilePrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].poolObjs = new List<GameObject>();


            for (int j = 0; j < pools[i].poolSize; j++)
            {
                GameObject obj = Instantiate(pools[i].objPrefab);
                obj.SetActive(false);
                pools[i].poolObjs.Add(obj);
            }
        }
    }

    public GameObject GetPooledObj(int objType)
    {
        for (int i = 0; i < pools[objType].poolObjs.Count; i++)
        {
            if (!pools[objType].poolObjs[i].gameObject.activeInHierarchy)
            {
                return pools[objType].poolObjs[i];
            }
        }

        return null;
    }
}


