using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionMonster : MonoBehaviour {
    public bool isGazed;
    public GameObject player, processIndicator;

    GameController gc;

    float time = 0;
    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isGazed && Vector3.Distance(this.transform.position, player.transform.position) < 15)
        {
            time += Time.deltaTime;
            processIndicator.GetComponent<Image>().fillAmount = time / 3;
            if (time > 3)
            {
                processIndicator.SetActive(false);
                Destroy(this.gameObject);
            }
        }

        else
        {
            time = 0;
        }
    }

    public void Gazed() {
        isGazed = true;
        processIndicator.SetActive(true);
    }

    public void UnGazed()
    {
        isGazed = false;
        processIndicator.SetActive(false);
    }

    private void OnDestroy()
    {
        gc.treeCount -= 1;
    }
}
