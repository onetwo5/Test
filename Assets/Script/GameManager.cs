using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    public int input;
    //private bool isLock;
    private Vector3 firstPos;
    public float count;
    public GameObject prefab;
    public Transform  button;
    

    public Transform  text;
    GUIStyle style = new GUIStyle();

    public static GameManager Instance = null;

    private void Awake()
    {
        
        Instance = this;
        score = 0;
    }
    void Start()
    {
        
        style.fontSize = 40;
        style.fontStyle = FontStyle.Bold;
        //isLock  = true;
    }

    
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 100), "当前分：" + score, style);
        GUI.Label(new Rect(0, 50, 200, 100), "剩余球：" + count,style);
        //if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 50), "开始游戏") && isLock)
        //{
        //}
        if (score != 0 && score == input)
        {
            GUI.Label(new Rect(400, 400, 400, 200), "游戏胜利！", style);
        }
        if (GUI.Button(new Rect(800, 0, 200, 50), "重新开始"))
            {
            button.gameObject.SetActive(true);
                score = 0;
                //isLock = true;
                text.gameObject.SetActive(true);
                SceneManager.LoadScene("SampleScene");
            }
    }
    

    public void ButtonStartGame()
    {
        //isLock = false;
        button.gameObject.SetActive(false);
        input = int.Parse(text.GetComponent<InputField>().text);
        count = input;
        for (int i = 0; i < input; i++)
        {
            int ran1 = Random.Range(-4, 4);
            int ran2 = Random.Range(-4, 4);
            firstPos = new Vector3(ran1, 0.25f, ran2);
            GameObject ball = Instantiate(prefab.gameObject);
            ball.transform.position = firstPos;
            text.gameObject.SetActive(false);
        }
        
    }
}
