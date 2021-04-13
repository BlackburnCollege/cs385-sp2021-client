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
    public bool canClick = false;

    private void OnCollisionEnter(Collision collision)
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
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        mat.color = deactive;
    }
    // Start is called before the first frame update
    void Start()
    {
        clicksRequired = (int) Random.Range(2, 5);
        mat = this.GetComponent<Material>();
        deactive = mat.color;
        GiveHint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GiveHint()
    {
        StartCoroutine(FlashHint());
    }

    IEnumerator FlashHint()
    {
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
