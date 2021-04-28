using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject cameraView;
    public List<GameObject> levelsPrefab = new List<GameObject>();
    public List<LevelMaster> levels = new List<LevelMaster>();
    private LevelMaster curLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        curLevel = levels[0];
        curLevel.StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (curLevel.levelCompleted)
        {
            foreach (var level in levels)
            {
                if (!level.levelCompleted)
                {
                    curLevel = level;
                    //camera.transform.position = level.CameraPos.transform.position;
                    StartCoroutine(TransitionCamera(level.CameraPos.transform));
                    cameraView.transform.rotation = level.CameraPos.transform.rotation;

                    level.StartLevel();
                    break;
                }
            }
        }
    }

    IEnumerator TransitionCamera(Transform target)
    {
        while (cameraView.transform.position != target.position)
        {
            cameraView.transform.position = Vector3.MoveTowards(cameraView.transform.position, target.position, 5 * Time.deltaTime);
            yield return null;
        }
    }
}
