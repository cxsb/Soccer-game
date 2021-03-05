using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score2 : MonoBehaviour
{

    private int TeamBScore;
    IEnumerator ie;
    // Use this for initialization
    void Start()
    {
        GameObject.Find("Canvas/team B score").GetComponent<Text>().text = "队伍B得分："+TeamBScore;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Soccer Ball Mesh")
        {
            TeamBScore++;
            GameObject.Find("Canvas/team B score").GetComponent<Text>().text = "队伍B得分："+TeamBScore;
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "队伍B进球！";
            ie=waitFourSeconds();
		    StartCoroutine(ie);
        }
    }

    IEnumerator waitFourSeconds(){
		yield return new WaitForSeconds(4.0f);
        if(GameObject.Find("Canvas/status").GetComponent<Text>().text.CompareTo("队伍B进球！")==0)
        {
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "";
        }
	}
}
