using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public string objectName;
    public float minTimeToSpawn, maxTimeToSpawn;
    internal float timeToSpawn;
    public Color flashColor;
    public MapGeneraotor map;

    private void Start()
    {
        timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        InvokeRepeating("SpawnObject", timeToSpawn, timeToSpawn);
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
        float spawntime = 5;

        while (spawnTimer < spawntime)
        {
            tileMat.color = Color.Lerp(initalColor, flashColor, Mathf.PingPong(spawnTimer * tileFlashSpeed, 1));
            spawnTimer += Time.deltaTime;
            yield return null;
        }
        tileMat.color = initalColor;
        ObjectPooling.instance.InstantiateAPS(objectName, randomTile.position + Vector3.up, Quaternion.identity);
        timeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);

    }
}
