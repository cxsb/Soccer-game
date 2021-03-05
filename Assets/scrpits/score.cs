using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    private int TeamAScore;
    IEnumerator ie;
	// Use this for initialization
	void Start () {
        GameObject.Find("Canvas/team A score").GetComponent<Text>().text = "队伍A得分："+TeamAScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Soccer Ball Mesh")
        {

            TeamAScore++;
            GameObject.Find("Canvas/team A score").GetComponent<Text>().text = "队伍A得分："+TeamAScore;
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "队伍A进球！";
            ie=waitFourSeconds();
		    StartCoroutine(ie);

        }
    }

    IEnumerator waitFourSeconds(){
		yield return new WaitForSeconds(4.0f);
        if(GameObject.Find("Canvas/status").GetComponent<Text>().text.CompareTo("队伍A进球！")==0)
        {
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "";
        }
	}
}
