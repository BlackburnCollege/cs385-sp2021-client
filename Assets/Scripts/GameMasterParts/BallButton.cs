using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour 
{
    public BallPuzzle ballPuzzle;
    public float clicksRequired;
    public int numberOfClicks = 0;
    public Color failed;
    public Color succes;
    public Color hint;
    private Color deactive;
    public Color clicked;
    public Material mat;
    public MeshRenderer meshRender;
    public bool canClick = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (canClick)
        {
            mat.color = clicked;
            numberOfClicks++;
        } 

        if (numberOfClicks > clicksRequired)
        {
            mat.color = failed;
            numberOfClicks = 0;
            ballPuzzle.Reset();
        }
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (canClick)
        {
            mat.color = deactive;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        clicksRequired = (int) Random.Range(2, 5);
        mat = new Material(mat);
        meshRender.material = mat;
        deactive = mat.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This gives the hint
    public void GiveHint()
    {
        StartCoroutine(FlashHint());
    }
    //This is where the flash hint is made so if a player fails the puzzle it will show the hint
    IEnumerator FlashHint()
    {
        yield return new WaitForSeconds(1);
        canClick = false;
        for (int i = 0; i < clicksRequired; i++)
        {
            mat.color = hint;
            yield return new WaitForSeconds(1);
            mat.color = deactive;
            yield return new WaitForSeconds(1);
        }
        canClick = true;
       
    }
}
