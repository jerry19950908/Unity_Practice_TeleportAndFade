using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    private Image effect;


    private void Start()
    {
        effect = GameObject.Find("轉場畫面").GetComponent<Image>();

        StartCoroutine(Level2());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "傳送門")
        {
            StartCoroutine(nextlevel());

        }
    }



    /// <summary>
    /// 下一關效果畫面
    /// </summary>
    /// <returns></returns>
    private IEnumerator nextlevel()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("第二關");

        async.allowSceneActivation = false;

        for (int i = 0; i < 20; i++)
        {
            effect.color += new Color(0, 0, 0, 0.05f);
            yield return new WaitForSeconds(0.1f);
        }
      

        async.allowSceneActivation = true;
       
    }
    /// <summary>
    /// 剛開始的轉場效果
    /// </summary>
    /// <returns></returns>
    private IEnumerator Level2()
    {
        effect.color = new Color(0, 0, 0, 1);

       for (int i = 0; i < 20; i++)
        {
           effect.color += new Color(0, 0, 0, -0.05f);
            yield return new WaitForSeconds(0.1f);
        }
    }


}

