using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class soccerboundary : NetworkBehaviour {
	[SyncVar]
    public int TeamAScore = 0,TeamBScore = 0;

	IEnumerator ie;

	// Use this for initialization
	public float BoundarySideMinus,BoundarySidePositive,BoundaryBackMinus,BoundaryBackPositive;
	public float BallRadius;
	public float GateLong,GateHeight;
	private float GateBoundarySideMinus,GateBoundarySidePositive;
	public float FieldHeight;

	void Start () {
		GameObject.Find("Canvas/team B score").GetComponent<Text>().text = "队伍B得分："+TeamBScore;
		GameObject.Find("Canvas/team A score").GetComponent<Text>().text = "队伍A得分："+TeamAScore;
	BoundarySideMinus=BoundarySideMinus-BallRadius;
	BoundarySidePositive=BoundarySidePositive+BallRadius;
	BoundaryBackMinus=BoundaryBackMinus-BallRadius;
	BoundaryBackPositive=+BoundaryBackPositive+BallRadius;
	GateBoundarySideMinus=((BoundarySideMinus+BoundarySidePositive)-GateLong)/2;
	GateBoundarySidePositive=((BoundarySideMinus+BoundarySidePositive)+GateLong)/2;
	GateHeight=GateHeight+FieldHeight;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		if(pos.x<BoundarySideMinus||pos.x>BoundarySidePositive||pos.z<BoundaryBackMinus||pos.z>BoundaryBackPositive)
		{
            GetComponent<Rigidbody>().velocity=Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity=Vector3.zero;
			pos.y=-1;
			if(pos.x<BoundarySideMinus)
			{
				pos.x= BoundarySideMinus+(float)0.1;
			}
			if(pos.x>BoundarySidePositive)
			{
				pos.x= BoundarySidePositive-(float)0.1;
			}
			if(pos.z<BoundaryBackMinus)
			{
				if(pos.x<GateBoundarySidePositive&&pos.x>GateBoundarySideMinus&&pos.y<GateHeight)
				{
            		pos.x = (BoundarySideMinus+BoundarySidePositive)/2;
            		pos.y = FieldHeight+7;
            		pos.z = (BoundaryBackMinus+BoundaryBackPositive)/2;
					RpcAGoal();
				}
				else
				{
					pos.z= BoundaryBackMinus+(float)2;
					pos.x=(BoundarySideMinus+BoundarySidePositive)/2;
				}
			}
			if(pos.z>BoundaryBackPositive)
			{
				if(pos.x<GateBoundarySidePositive&&pos.x>GateBoundarySideMinus&&pos.y<GateHeight)
				{
					pos.x = (BoundarySideMinus+BoundarySidePositive)/2;
            		pos.y = FieldHeight+7;
            		pos.z = (BoundaryBackMinus+BoundaryBackPositive)/2;
					RpcBGoal();
				}
				else
				{
					pos.z= BoundaryBackPositive-(float)2;
					pos.x=(BoundarySideMinus+BoundarySidePositive)/2;
				}
			}
			transform.position = pos;
		}
	}

	IEnumerator waitFourSecondsA(){
		yield return new WaitForSeconds(4.0f);
        if(GameObject.Find("Canvas/status").GetComponent<Text>().text.CompareTo("队伍A进球！")==0)
        {
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "";
        }
	}

	IEnumerator waitFourSecondsB(){
		yield return new WaitForSeconds(4.0f);
        if(GameObject.Find("Canvas/status").GetComponent<Text>().text.CompareTo("队伍B进球！")==0)
        {
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "";
        }
	}

	[ClientRpc]
    void RpcAGoal()//只能传递值类型参数
    {
        TeamAScore++;
        GameObject.Find("Canvas/team A score").GetComponent<Text>().text = "队伍A得分："+TeamAScore;
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "队伍A进球！";
            ie=waitFourSecondsA();
		    StartCoroutine(ie);
    }

	[ClientRpc]
    void RpcBGoal()//只能传递值类型参数
    {
        TeamBScore++;
        GameObject.Find("Canvas/team B score").GetComponent<Text>().text = "队伍B得分："+TeamBScore;
            GameObject.Find("Canvas/status").GetComponent<Text>().text = "队伍B进球！";
            ie=waitFourSecondsB();
		    StartCoroutine(ie);
    }
}
