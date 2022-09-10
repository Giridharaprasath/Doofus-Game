using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pulpit : MonoBehaviour
{
    [SerializeField]
    private float currPulpitTime;
    [SerializeField]
    private bool canCreateNewPulpit = true;

    [SerializeField]
    private TMP_Text pulpitTimer;

    #region HIDDEN DATA

    [SerializeField]
    private float minPulpitDT;
    [SerializeField]
    private float maxPulpitDT;
    [SerializeField]
    private float spawnPulpitTime;

    #endregion

    public void OnCreation()
    {
        PulpitManager.instance.pulpitList.Add(this);
        minPulpitDT = GameManager.instance.doofusDiary.diaryData.pulpit_data.min_pulpit_destroy_time;
        maxPulpitDT = GameManager.instance.doofusDiary.diaryData.pulpit_data.max_pulpit_destroy_time;
        spawnPulpitTime = GameManager.instance.doofusDiary.diaryData.pulpit_data.pulpit_spawn_time;
        currPulpitTime = Random.Range(minPulpitDT, maxPulpitDT);
    }

    private void Update()
    {
        if (currPulpitTime > 0)
        {
            currPulpitTime -= Time.deltaTime;
            pulpitTimer.text = currPulpitTime.ToString("F2");
        }
        if (currPulpitTime < 0)
        {
            Destroy(this.gameObject);
            PulpitManager.instance.pulpitList.Remove(this);
        }
        if (currPulpitTime < spawnPulpitTime && canCreateNewPulpit && PulpitManager.instance.pulpitList.Count < 2)
        {
            PulpitManager.instance.SetNewPulpitPos(this.transform.position);
            canCreateNewPulpit = false;
        }
    }
}