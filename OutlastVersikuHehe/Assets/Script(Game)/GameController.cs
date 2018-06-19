using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject[] magicTrees;
    public int treeCount;
    public GameObject hintText, winText, loseText;
    public bool isOver;
	// Use this for initialization
	void Start () {
        magicTrees = GameObject.FindGameObjectsWithTag("MagicTree");
        treeCount = magicTrees.Length;
        StartCoroutine(closeHint());
	}
	
	// Update is called once per frame
	void Update () {
		if(treeCount <= 0)
        {
            winText.SetActive(true);
            isOver = true;
        }

        else if(treeCount != 0 && isOver == true)
        {
            loseText.SetActive(true);
        }

        if (isOver)
        {
            EndGameInput();
        }
	}

    IEnumerator closeHint()
    {
        yield return new WaitForSeconds(3f);
        hintText.SetActive(false);
        yield break;
    }

    void EndGameInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
