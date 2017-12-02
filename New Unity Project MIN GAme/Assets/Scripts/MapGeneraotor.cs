using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGeneraotor : MonoBehaviour {

    public Map[] maps;
    public int mapIndex;

    public Transform tile;
    public Transform Obstacle;
    public Transform navMeshFloor;
    public Transform navMeshMask;
    public Vector2 maxMapSize;
    [Range(0, 1)]
    public float outLinePercent;

    [Range(2, 10)]
    public float tileSize;

    List<Coord> allTileCoords;
    Queue<Coord> shuffleTileCoords;
    Queue<Coord> shuffleOpenTileCoords;
    Map currentMap;
    Transform[,] tileMap;

    private void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        currentMap = maps[mapIndex];
        tileMap = new Transform[currentMap.mapSize.x, currentMap.mapSize.y];
        System.Random prng = new System.Random(currentMap.seed);
        currentMap.seed = Random.Range(10,100);
        GetComponent<BoxCollider>().size = new Vector3(currentMap.mapSize.x * tileSize, 0.5f, currentMap.mapSize.y * tileSize);

        //CreateCoords
        allTileCoords = new List<Coord>();
        for (int x = 0; x < currentMap.mapSize.x; x++)
        {
            for (int y = 0; y < currentMap.mapSize.y; y++)
            {
                allTileCoords.Add(new Coord(x, y));
            }
        }

        shuffleTileCoords = new Queue<Coord>(Utulity.ShuffleArray(allTileCoords.ToArray(), currentMap.seed));
        //Create MapHolder
        string holderName = "GeneratedMap";
        if (transform.FindChild(holderName))
        {
            DestroyImmediate(transform.FindChild(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.SetParent(transform);

        //SpawnTiles
        for (int x = 0; x < currentMap.mapSize.x; x++)
        {
            for (int y = 0; y < currentMap.mapSize.y; y++)
            {
                Vector3 tilePos = CoordToPos(x, y);
                Transform newTile = Instantiate(tile, tilePos, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - outLinePercent) * tileSize;
                newTile.SetParent(mapHolder);
                tileMap[x, y] = newTile;
            }
        }

        bool[,] obstacleMap = new bool[(int)currentMap.mapSize.x, (int)currentMap.mapSize.y];

        int obstacleCount = (int)(currentMap.mapSize.x * currentMap.mapSize.y * currentMap.obstaclePercent);
        int currentObstacleCount = 0;
        List<Coord> allOpenCoords = new List<Coord>(allTileCoords);

        for (int i = 0; i < obstacleCount; i++)
        {
            Coord randomCoord = GetRandomCoord();
            obstacleMap[randomCoord.x, randomCoord.y] = true;
            currentObstacleCount++;

            if(randomCoord != currentMap.mapCenter && MapIsFullyAccessible(obstacleMap, currentObstacleCount))
            {
                float obstacleHeight = Mathf.Lerp(currentMap.minObstacleHeight, currentMap.maxObstacleHeight, (float)prng.NextDouble());
                Vector3 obstaclePos = CoordToPos(randomCoord.x, randomCoord.y);
                Transform newObstacle = Instantiate(Obstacle, obstaclePos + Vector3.up, Quaternion.identity) as Transform;
                newObstacle.SetParent(mapHolder.transform);
                newObstacle.localScale = new Vector3((1 - outLinePercent) * tileSize, obstacleHeight, (1 - outLinePercent) * tileSize);
                MeshRenderer obstacleRenderer = newObstacle.GetComponent<MeshRenderer>();
                Material obstacleMat = new Material(obstacleRenderer.sharedMaterial);
                float colorPercent = randomCoord.y / (float)currentMap.mapSize.y;
                obstacleMat.color = Color.Lerp(currentMap.foregroundColor, currentMap.backGroundColor, colorPercent);
                obstacleRenderer.sharedMaterial = obstacleMat;
                allOpenCoords.Remove(randomCoord);
            }
            else
            {
                obstacleMap[randomCoord.x, randomCoord.y] = false;
                currentObstacleCount--;
            }
           
        }

        shuffleOpenTileCoords = new Queue<Coord>(Utulity.ShuffleArray(allOpenCoords.ToArray(), currentMap.seed));

        Transform maskLeft = Instantiate(navMeshMask, new Vector3(-1 * (currentMap.mapSize.x + maxMapSize.x) / 4f * tileSize, 0.5f ,0), Quaternion.identity) as Transform;
        maskLeft.SetParent(mapHolder);
        maskLeft.localScale = new Vector3((maxMapSize.x - currentMap.mapSize.x) / 2f, 1, currentMap.mapSize.y) * tileSize;

        Transform maskRight = Instantiate(navMeshMask, new Vector3(1 * (currentMap.mapSize.x + maxMapSize.x) / 4f * tileSize, 0.5f, 0), Quaternion.identity) as Transform;
        maskRight.SetParent(mapHolder);
        maskRight.localScale = new Vector3((maxMapSize.x - currentMap.mapSize.x) / 2f, 1, currentMap.mapSize.y) * tileSize;

        Transform maskTop = Instantiate(navMeshMask, new Vector3(0, 0.5f, 1 * (currentMap.mapSize.x + maxMapSize.x) / 4f * tileSize), Quaternion.identity) as Transform;
        maskTop.SetParent(mapHolder);
        maskTop.localScale = new Vector3(maxMapSize.x, 1,(maxMapSize.y - currentMap.mapSize.y) / 2f) * tileSize;

        Transform maskButtom = Instantiate(navMeshMask, new Vector3(0, 0.5f, -1 * (currentMap.mapSize.x + maxMapSize.x) / 4f * tileSize), Quaternion.identity) as Transform;
        maskButtom.SetParent(mapHolder);
        maskButtom.localScale = new Vector3(maxMapSize.x, 1, (maxMapSize.y - currentMap.mapSize.y) / 2f) * tileSize;

        maxMapSize = new Vector2(currentMap.mapSize.x + 2, currentMap.mapSize.y + 2);

        navMeshFloor.localScale = new Vector3(maxMapSize.x, maxMapSize.y) * tileSize;
    }

    bool MapIsFullyAccessible(bool[,] obstacleMap, int currentObstacleCount)
    {
        bool[,] mapFlags = new bool[obstacleMap.GetLength(0), obstacleMap.GetLength(1)];
        Queue<Coord> queue = new Queue<Coord>();
        queue.Enqueue(currentMap.mapCenter);
        mapFlags[currentMap.mapCenter.x, currentMap.mapCenter.y] = true;
        int accessibleTileCount = 1;


        while(queue.Count > 0)
        {
            Coord tile = queue.Dequeue();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int neighbourX = tile.x + x;
                    int neighbourY = tile.y + y;
                    if(x == 0 || y == 0)
                    {
                        if(neighbourX >= 0 && neighbourX < obstacleMap.GetLength(0) && neighbourY >=0 && neighbourY < obstacleMap.GetLength(1))
                        {
                            if(!mapFlags[neighbourX,neighbourY] && !obstacleMap[neighbourX, neighbourY])
                            {
                                mapFlags[neighbourX, neighbourY] = true;
                                queue.Enqueue(new Coord(neighbourX, neighbourY));
                                accessibleTileCount++;
                            }
                        }
                    }
                }
            }
        }

        int targetAccessibleTileCount = (int)(currentMap.mapSize.x * currentMap.mapSize.y - currentObstacleCount);
        return targetAccessibleTileCount == accessibleTileCount;
    }

    Vector3 CoordToPos(int x, int y)
    {
        return new Vector3(-currentMap.mapSize.x / 2f + 0.5f + x, 0, -currentMap.mapSize.y / 2f + 0.5f + y) * tileSize;
    }

    public Coord GetRandomCoord()
    {
        Coord randomCoord = shuffleTileCoords.Dequeue();
        shuffleTileCoords.Enqueue(randomCoord);
        return randomCoord;
    }

    public Transform GetRandomOpenTile()
    {
        Coord randomCoord = shuffleOpenTileCoords.Dequeue();
        shuffleOpenTileCoords.Enqueue(randomCoord);
        return tileMap[randomCoord.x, randomCoord.y];
    }

    [System.Serializable]
    public struct Coord
    {
        public int x;
        public int y;


        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static bool operator == (Coord c1, Coord c2)
        {
            return c1.x == c2.x && c1.y == c2.y;
        }

        public static bool operator !=(Coord c1, Coord c2)
        {
            return !(c1 == c2);
        }
    }

    [System.Serializable]
    public class Map
    {
        public Coord mapSize;
        [Range(0,1)]
        public float obstaclePercent;
        public int seed;
        public float minObstacleHeight;
        public float maxObstacleHeight;
        public Color foregroundColor;
        public Color backGroundColor;

        public Coord mapCenter {
            get
            {
                return new Coord(mapSize.x / 2, mapSize.y / 2);
            }
        }

    }
}
