using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public static int statesSize = 8;

    public string[] states = new string[8];

    public GameObject tutText;
    public GameObject prevBut;
    public GameObject nextBut;

    private int state = 0;

    public void NextText()
    {
        state++;
        if (state >= statesSize)
        {
            state = 0;
            tutText.SetActive(false);
            prevBut.SetActive(false);
            nextBut.SetActive(false);
            nextBut.GetComponentInChildren<TMP_Text>().text = "Next";

            return;
        }

        if (state == statesSize - 1)
        {
            //nextBut.SetActive(true);
            nextBut.GetComponentInChildren<TMP_Text>().text = "Play";
        }

        tutText.GetComponent<TMP_Text>().text = states[state];

        tutText.SetActive(true);
        prevBut.SetActive(true);
    }

    public void PrevTut()
    {
        state--;
        if (state >= 1)
            prevBut.SetActive(true);
        else
            prevBut.SetActive(false);

        tutText.GetComponent<TMP_Text>().text = states[state];

        nextBut.SetActive(true);
        tutText.SetActive(true);
    }

    public void RestartTutorial()
    {
        state = 0;
        tutText.GetComponent<TMP_Text>().text = states[state];
        nextBut.GetComponentInChildren<TMP_Text>().text = "Next";
        prevBut.SetActive(false);
        nextBut.SetActive(true);
        tutText.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        RestartTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            RestartTutorial();
    }
}
