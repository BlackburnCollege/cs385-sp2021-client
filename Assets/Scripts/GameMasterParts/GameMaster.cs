using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject camera;
    public List<LevelMaster> levels = new List<LevelMaster>();
    private LevelMaster curLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        curLevel = levels[0];
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var level in levels)
        {
            if(level == curLevel)
            {
                break;
            }else if (!level.levelCompleted)
            {
                curLevel = level;
                camera.transform.position = level.CameraPos.transform.position;
                camera.transform.rotation = level.CameraPos.transform.rotation;
                break;
            }
        }
    }
}
