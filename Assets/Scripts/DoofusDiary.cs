using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class DoofusDiary : MonoBehaviour
{
    [Serializable]
    public class DiaryData
    {
        public playerdata player_data;
        public pulpitdata pulpit_data;
    }

    [Serializable]
    public class playerdata
    {
        public float speed;
    }

    [Serializable]
    public class pulpitdata
    {
        public float min_pulpit_destroy_time;
        public float max_pulpit_destroy_time;
        public float pulpit_spawn_time;
    }

    public static DoofusDiary instance;

    public DiaryData diaryData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            StartCoroutine(GetData());
        }
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json"))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Successfully downloaded data");

                var text = www.downloadHandler.text;
                diaryData = JsonUtility.FromJson<DiaryData>(text);
                if (diaryData != null)
                    GameManager.instance.doofusDiary = this;
            }
        }
    }
}
