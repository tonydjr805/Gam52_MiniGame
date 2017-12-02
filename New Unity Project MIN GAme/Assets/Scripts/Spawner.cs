using UnityEngine;
using System.Collections;


[System.Serializable]
public class ObjectToSpawn
{
    public string objectName;
    public float minTimeToSpawn, maxTimeToSpawn;
    internal float timeToSpawn;
    public Color flashColor;
}
public class Spawner : MonoBehaviour {

    public ObjectToSpawn[] objectToSpawn;
    int index;
    public MapGeneraotor map;

    private void Start()
    {
        objectToSpawn[index].timeToSpawn = Random.Range(objectToSpawn[index].minTimeToSpawn, objectToSpawn[index].maxTimeToSpawn);
        InvokeRepeating("SpawnObject", objectToSpawn[index].timeToSpawn, objectToSpawn[index].timeToSpawn);
    }

    void SpawnObject()
    {
        StartCoroutine(SpawnCo());
    }

    IEnumerator SpawnCo()
    {
        float tileFlashSpeed = 4;
        Transform randomTile = map.GetRandomOpenTile();
        Material tileMat = randomTile.GetComponent<MeshRenderer>().material;
        Color initalColor = tileMat.color;
        float spawnTimer = 0;


        while (spawnTimer < objectToSpawn[index].timeToSpawn)
        {
            tileMat.color = Color.Lerp(initalColor, objectToSpawn[index].flashColor, Mathf.PingPong(spawnTimer * tileFlashSpeed, 1));
            spawnTimer += Time.deltaTime;
            yield return null;
        }
        tileMat.color = initalColor;
        ObjectPooling.instance.InstantiateAPS(objectToSpawn[index].objectName, randomTile.position + Vector3.up, Quaternion.identity);
        objectToSpawn[index].timeToSpawn = Random.Range(objectToSpawn[index].minTimeToSpawn, objectToSpawn[index].maxTimeToSpawn);
        index++;

        if (index == objectToSpawn.Length)
            index = 0;
        

    }
}
