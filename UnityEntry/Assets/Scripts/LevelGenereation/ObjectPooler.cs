using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private Transform player;
    public enum PoolTag
    {
        Trees,
        Barrels,
        Stones,
        Platforms
    }
    [System.Serializable]
    public class Pool
    {
        public PoolTag tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<PoolTag, Queue<GameObject>> poolDictionary;
    void Start()
    {
        GetRandomObstaclePoolTag();
        poolDictionary = new Dictionary<PoolTag, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public PoolTag GetRandomObstaclePoolTag()
    {
        Type t = typeof(PoolTag);
        Array fields = t.GetEnumValues();
        List<PoolTag> tags = new List<PoolTag>();
        foreach (var f in fields)
        {
            PoolTag poolTag = (PoolTag)Enum.Parse(typeof(PoolTag), f.ToString(), true);
            if (poolTag != PoolTag.Platforms)
            {
                tags.Add(poolTag);
            }
        }
        int randomIndex = UnityEngine.Random.Range(0, tags.Count);
        return tags[randomIndex];
    }
    private Pool FindPoolWithTag(PoolTag tag)
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if (pools[i].tag == tag)
            {
                return pools[i];
            }
        }
        return null;
    }
    public GameObject SpawnFromPool(PoolTag tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        if (!InBounds.IsInBounds(objectToSpawn.transform.position) && objectToSpawn.transform.position.z < player.position.z)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            poolDictionary[tag].Enqueue(objectToSpawn);
        }
        else if (InBounds.IsInBounds(objectToSpawn.transform.position))
        {
            objectToSpawn = Instantiate(FindPoolWithTag(tag).prefab);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            poolDictionary[tag].Enqueue(objectToSpawn);
            FindPoolWithTag(tag).size++;
        }
        return objectToSpawn;
    }
}
