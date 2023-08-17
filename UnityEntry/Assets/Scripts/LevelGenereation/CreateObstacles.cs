using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    private ObjectPooler pooler;
    private float[] Xpositions = new float[3];
    [SerializeField] private float gap;
    [SerializeField] private Transform platformGenerator;
    void Start()
    {
        pooler = GetComponent<ObjectPooler>();
        MakeInitialGap();
    }
    private void Update()
    {
        if (InBounds.IsInBounds(new Vector3(Xpositions[0], transform.position.y, transform.position.z)))
        {
            CreatePositions();
            float[] pos = PickTwoRandomPositions();
            SpawnObstacles(pos);
            MakeGap();
        }
        if (InBounds.IsInBounds(platformGenerator.position))
        {
            SpawnPlatform();
        }
    }
    private void MakeInitialGap()
    {
        for (int i = 0; i < 5; i++)
        {
            MakeGap();
        }
    }
    private void CreatePositions()
    {
        int j = 0;
        for (int i = -2; i < Xpositions.Length; i += 2)
        {
            Xpositions[j] = i;
            j++;
        }
    }
    private float[] PickTwoRandomPositions()
    {
        float[] positions = new float[2];
        int randomIndex = Random.Range(0, Xpositions.Length);
        int j = 0;
        for (int i = 0; i < Xpositions.Length; i++)
        {
            if (i != randomIndex)
            {
                positions[j] = Xpositions[i];
                j++;
            }
        }
        return positions;
    }
    private void SpawnObstacles(float[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Vector3 pos = new Vector3(positions[i], transform.position.y, transform.position.z);
            pooler.SpawnFromPool(pooler.GetRandomObstaclePoolTag(), pos, transform.rotation);
        }
    }
    private void SpawnPlatform()
    {
        GameObject platform = pooler.SpawnFromPool(ObjectPooler.PoolTag.Platforms, platformGenerator.position, platformGenerator.rotation);
        float z = platformGenerator.position.z + platform.GetComponent<Collider>().bounds.extents.z * 2;
        platformGenerator.position = new Vector3(platformGenerator.position.x, platformGenerator.position.y, z);
    }
    private void MakeGap()
    {
        transform.position += new Vector3(0, 0, gap);
    }
    public float[] GetLanes()
    {
        return Xpositions;
    }
}
