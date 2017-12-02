using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public int Points;
    public Text pointText;
    public Slider healthSlider;
    MapGeneraotor map;
    CameraTopdown camController;
    Player player;

    private void Start()
    {
        instance = this;
        
        map = FindObjectOfType<MapGeneraotor>();
        pointText.text = "Honey " + Points;
        camController = Camera.main.GetComponent<CameraTopdown>();
        player = FindObjectOfType<Player>();
        camController.target = player.transform;
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
            Restart();
    }

    public void GivePoint()
    {
        Points++;
        pointText.text = "Honey " + Points;
    }

    public void Restart()
    {
        //player.Dead();
        player.transform.position = Vector3.up;
        ObjectPooling.instance.DestroyAllAPS();
        map.GenerateMap();
        player.gameObject.SetActive(true);
        Points = 0;
        pointText.text = "Honey " + Points;
        camController.target = player.transform;
    }
}
