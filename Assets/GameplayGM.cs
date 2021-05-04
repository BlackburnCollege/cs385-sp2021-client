using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayGM : MonoBehaviour
{
    public static GameplayGM gamplayGM { get; set; }
    public GameObject PlayerPrefab;
    public GameObject[] spawnPoints = new GameObject[8];
    public List<Player> Players = new List<Player>();

    private Coroutine gameOverCourtine;
    // Start is called before the first frame update
    void Start()
    {
        if(ClientWS.clientWs == null)
        {
            gameOverCourtine = StartCoroutine(GameOver());
        }

        gamplayGM = this;
        for (int i = 0; i < ClientWS.clientWs.controllers.Length; i++)
        {
            if(ClientWS.clientWs.controllers[i] != null)
            {
                GameObject go = Instantiate(PlayerPrefab);
                go.transform.position = spawnPoints[i].transform.position;
                Players.Add(go.GetComponent<Player>());
                go.GetComponent<Player>().controller = ClientWS.clientWs.controllers[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0, j = 0; i < Players.Count; i++)
        {
            if (Players[i].IsDead)
            {
                j++;
                if(j == Players.Count)
                {
                    if (gameOverCourtine == null) {
                        gameOverCourtine = StartCoroutine(GameOver());
                    }
                }
            }
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
