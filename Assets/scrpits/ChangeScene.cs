using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
   public void onClick()
    {
        SceneManager.LoadScene("3DHomework");//4是要切换的场景的索引
    }
}