﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Enablegames;

public class egSceneManager : MonoBehaviour
{

    public static UnityEvent OnSceneChange = new UnityEvent();
	public string GameSceneName  = "eag_MoveCubeGame";
    public int layoutInt;
    public int layoutInt2;
    public int layoutInt3;

    private static egSceneManager instance;
    public static egSceneManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void Play()
    {
		EnableAPI.Instance.CreateNewSession(EnableAPI.Instance.Game, EnableAPI.Instance.Version);
        SessionCreator.Instance.CreateSession();
        StartGameRoutine();
    }
    /*
    public void LoadSave() {
        GameObject canvas = GameObject.FindGameObjectWithTag("mainCanvas");
        GameObject panelPrefab = Resources.Load("AblePrefabs/SessionCreatorPanel_New") as GameObject;
        GameObject instantiated = Instantiate(panelPrefab) as GameObject;
        instantiated.transform.SetParent(canvas.transform);
        instantiated.transform.SetAsLastSibling();
		((RectTransform)instantiated.transform).anchoredPosition = new Vector2 (0, -64);
    }
	*/
    void StartGameRoutine()
    {
        //GameObject canvas = GameObject.FindGameObjectWithTag("mainCanvas");
        Raise(OnSceneChange);
		if (GameSceneName != null)
			SceneManager.LoadScene(GameSceneName);
		else
			print ("Missing game scene name to load.");
    }

    public void SetSceneName(string name)
    {
        GameSceneName = name;
    }

    public void LoadScene(string name)
    {
        Raise(OnSceneChange);
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

    void Raise(UnityEvent toRaise)
    {
        if (toRaise != null)
        {
            toRaise.Invoke();
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void setLayoutFloat(float newLayout)
    {
        layoutInt = Mathf.FloorToInt(newLayout);
    }

    public void setLayout2Float(float newLayout)
    {
        layoutInt2 = Mathf.FloorToInt(newLayout);
    }

    public void setLayout3Float(float newLayout)
    {
        layoutInt3 = Mathf.FloorToInt(newLayout);
    }
}
