using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelMaster : MonoBehaviour
{
    public GameObject baseObject;
    public GameObject entranceDoorLocation;
    public GameObject ExitDoorLocation;
    public GameObject[] puzzlesobj = new GameObject[10];
    public Puzzles[] puzzles;
    public GameObject door;
    public bool levelCompleted = false;

    public GameObject CameraPos;
    public AudioClip music;

    public UnityEvent OnComplete;
    // Start is called before the first frame update
    void Start()
    {
        //set up the base object so the game master can move the level when needed;
        if(baseObject == null)
        {
            if(this.transform.parent != null)
            {
                baseObject = this.transform.parent.gameObject;
            }
            else
            {
                baseObject = this.gameObject;
            }
        }

        puzzles = new Puzzles[puzzlesobj.Length];
        for (int i = 0; i < puzzlesobj.Length; i++)
        {
            puzzles[i] = puzzlesobj[i].GetComponent<Puzzles>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Puzzles puzzle in puzzles)
        {
            if (!puzzle.PuzzleCompleted)
            {
                return;
            }
        }
        door.SetActive(false);
        levelCompleted = true;
        if (OnComplete != null)
        {
            OnComplete.Invoke();
        }
    }

    /// <summary>
    /// starts the level a little late
    /// </summary>
    public void StartLevel()
    {
        StartCoroutine(startLate());
    }
    /// <summary>
    /// Starts the level a little late so there isnt any errors
    /// </summary>
    /// <returns></returns>
    private IEnumerator startLate()
    {
        yield return new WaitForEndOfFrame();
        AudioManager.PlaySong(music);
        foreach (Puzzles puz in puzzles)
        {
            puz.StartPuzzle();
        }
        yield return null;
    }
}
