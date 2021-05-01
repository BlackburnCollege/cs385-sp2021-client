using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject cameraView;
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
                    break;
                }
            }
        }
    }

    IEnumerator TransitionCamera(Transform target)
    {
        while (cameraView.transform.position != target.position)
        {
            cameraView.transform.position = Vector3.MoveTowards(cameraView.transform.position, target.position, 1 * Time.deltaTime);
            yield return null;
        }
    }
}
