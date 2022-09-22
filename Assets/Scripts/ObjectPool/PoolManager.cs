using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPool
    {
        public GameObject prefab;
        public int maximumInstances;
        public Pools.Types poolType;
        
        [HideInInspector]
        public Dictionary<int, GameObject> passiveObjectsDictionary;

        [HideInInspector]
        public GameObject pool;
        public void InitializePool()
        {
            passiveObjectsDictionary = new Dictionary<int, GameObject>();
            pool = new GameObject("[" + poolType + "]");

            GameObject clone;

            for (int i = 0; i < maximumInstances; i++)
            {
                clone = Instantiate(prefab);
                
                clone.SetActive(false);
                clone.transform.SetParent(pool.transform);

                passiveObjectsDictionary.Add(clone.GetInstanceID(), clone);
            }
        }
        
        GameObject tempObject;
        public GameObject GetNextObject()
        {
            if (passiveObjectsDictionary.Count > 0)
            {
                tempObject = passiveObjectsDictionary.Values.ElementAt(0);
                passiveObjectsDictionary.Remove(passiveObjectsDictionary.Keys.ElementAt(0));
                return tempObject;
            }
            else
            {
                GameObject clone; 
                clone = Instantiate(prefab);
                clone.SetActive(false);
                clone.transform.SetParent(pool.transform);
                passiveObjectsDictionary.Add(clone.GetInstanceID(), clone);

                tempObject = passiveObjectsDictionary.Values.ElementAt(0);
                passiveObjectsDictionary.Remove(passiveObjectsDictionary.Keys.ElementAt(0));
                return tempObject;
            }
        }
        
        public Pools.Types PoolType { get { return poolType; } set { poolType = value; } }
    }
    
    public List<ObjectPool> pools;

    public static PoolManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        for (int i = 0; i < pools.Count; i++)
        {
            pools[i].InitializePool();
        }
    }
    
    public GameObject Spawn(Pools.Types poolType, Vector3? position, Quaternion? rotation, Transform parent = null)
    {
        ObjectPool pool = GetObjectPool(poolType);

        if (pool == null)
        {
            return null;
        }
        
        GameObject clone = pool.GetNextObject();

        if (clone == null)
        {
            return null;
        }

        if (parent != null)
        {
            clone.transform.SetParent(parent);
        }

        if (position != null)
        {
            clone.transform.position = (Vector3)position;
        }

        if (rotation != null)
        {
            clone.transform.rotation = (Quaternion)rotation;
        }
        
        clone.SetActive(true);
        return clone;
    }
    
    public void Despawn(Pools.Types poolType, GameObject obj)
    {
        ObjectPool poolObject = GetObjectPool(poolType);

        obj.transform.SetParent(poolObject.pool.transform);
        

        if (!poolObject.passiveObjectsDictionary.ContainsKey(obj.GetInstanceID()))
        {
            poolObject.passiveObjectsDictionary.Add(obj.GetInstanceID(), obj);
        }

        obj.SetActive(false);
    }

    public ObjectPool GetObjectPool(Pools.Types poolType)
    {
        string poolName = Pools.GetTypeStr(poolType);
        for (int i = 0; i < pools.Count; i++)
        {
            if (pools[i].PoolType == poolType)
            {
                return pools[i];
            }
        }
        return null;  
    } 

}
