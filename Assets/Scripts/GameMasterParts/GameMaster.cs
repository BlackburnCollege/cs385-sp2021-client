using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject cameraView;
    public List<GameObject> levelsPrefab = new List<GameObject>();
    public List<LevelMaster> levels = new List<LevelMaster>();
    private LevelMaster curLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        int levelsPrefabIndex = 0;
        for (int i = 1 ; i < levels.Count; i++)
        {
            if(levels[i] == null)
            {
                Vector3 spwnPos = (levels[i - 1].transform.position + (levels[i - 1].ExitDoorLocation.transform.parent != null ? Vector3.Scale(levels[i - 1].ExitDoorLocation.transform.localPosition, levels[i - 1].ExitDoorLocation.transform.parent.localScale) : levels[i - 1].ExitDoorLocation.transform.localPosition));
                GameObject nextLvl = Instantiate(levelsPrefab[levelsPrefabIndex], spwnPos, Quaternion.Euler(0, 0, 0));
                levels[i] = nextLvl.GetComponentInChildren<LevelMaster>();
                nextLvl.transform.position -=  Vector3.Scale(levels[i].entranceDoorLocation.transform.localPosition, levels[i].transform.parent.localScale);

                levelsPrefabIndex++;
            }
        }
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

                    
                    return;
                }
            }
            SceneManager.LoadScene("GameWon");
        }
    }

    IEnumerator TransitionCamera(Transform target)
    {
        while (cameraView.transform.position != target.position)
        {
            cameraView.transform.position = Vector3.MoveTowards(cameraView.transform.position, target.position, 3 * Time.deltaTime);
            yield return null;
        }
        curLevel.StartLevel();
    }
}
