using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterController : MonoBehaviour
{
    [SerializeField] private Slider[] slider = new Slider[Global.Length];

    [SerializeField] private Text sortName;

    [SerializeField] protected int[] Array;

    public Base sortController = null;

    private void Reset()
    {
        for (int i = 0; i < Global.Length; i++)
        {
            slider[i] = GameObject.Find("Meter" + (i + 1).ToString()).GetComponent<Slider>();
        }

        sortName = GameObject.Find("SortName").GetComponent<Text>();

        GameObject obj = null;

        obj = GameObject.Find("BubbleSort");
        if (obj) obj.GetComponent<Button>().onClick.AddListener(OnClickBubbleSort);
        obj = null;
    }

    public void Changed(ChangedData data)
    {
        slider[data.fromIndex].value = data.fromValue;
        slider[data.toIndex].value = data.toValue;
    }

    public void OnClickPlay()
    {

        Array = new int[Global.Length];

        for (int i = 0; i < Global.Length; i++)
        {
            Array[i] = i + 1;
        }

        // 配列をシャッフルする
        Array = Array.OrderBy(i => Guid.NewGuid()).ToArray();

    }

    public void OnClickBubbleSort()
    {
        sortName.text = "Bubble Sort";
        sortController = new BubbleSort(Changed);
    }
}
