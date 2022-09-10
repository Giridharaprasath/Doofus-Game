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

    public void OnCreation()
    {
        PulpitManager.instance.pulpitList.Add(this);
    }

    private void Start()
    {
        currPulpitTime = Random.Range(4f, 5f);
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
        if (currPulpitTime < 2.5f && canCreateNewPulpit && PulpitManager.instance.pulpitList.Count < 2)
        {
            PulpitManager.instance.SetNewPulpitPos(this.transform.position);
            canCreateNewPulpit = false;
        }
    }
}