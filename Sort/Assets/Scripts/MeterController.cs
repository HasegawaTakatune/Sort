﻿using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メーターの制御
/// </summary>
public class MeterController : MonoBehaviour
{
    /// <summary>
    /// イベント辞書
    /// </summary>
    Dictionary<string, int> clickEvent = new Dictionary<string, int>() {
        {"Play",0 },
        {"BubbleSort",1 },
        {"ShakerSort",2 },
        {"ComSort",3 }
    };

    /// <summary>
    /// スライダーUI（メーター）
    /// </summary>
    [SerializeField] private Slider[] slider = new Slider[Global.Length];

    /// <summary>
    /// ソート名Text
    /// </summary>
    [SerializeField] private Text sortName;

    /// <summary>
    /// 実行回数
    /// </summary>
    [SerializeField] private Text Counter;

    /// <summary>
    /// ソートクラス
    /// </summary>
    public Base sortController = null;

    /// <summary>
    /// 配置したボタンを格納
    /// </summary>
    public Button[] buttons;

    [SerializeField] private Color FromButtonColor = new Color();
    [SerializeField] private Color ToButtonColor = new Color();

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        // ボタンクリックイベントをアタッチする
        buttons[clickEvent["Play"]].onClick.AddListener(OnClickPlay);
        buttons[clickEvent["BubbleSort"]].onClick.AddListener(() => { SetAction(new BubbleSort(Changed, SortEnd)); });
        buttons[clickEvent["ShakerSort"]].onClick.AddListener(() => { SetAction(new ShakerSort(Changed, SortEnd)); });
        buttons[clickEvent["ComSort"]].onClick.AddListener(() => { SetAction(new ComSort(Changed, SortEnd)); });
    }

    /// <summary>
    /// コンポーネントアタッチ時orリセット時の実行処理（エディタ上のみ）
    /// </summary>
    private void Reset()
    {
        // メーターを取得
        for (int i = 0; i < Global.Length; i++)
        {
            slider[i] = GameObject.Find("Meter" + (i + 1).ToString()).GetComponent<Slider>();
        }

        // ソート名Textを取得
        sortName = GameObject.Find("SortName").GetComponent<Text>();

        // カウンター取得
        Counter = GameObject.Find("Counter").GetComponent<Text>();

        // 配置したボタンを取得
        buttons = new Button[clickEvent.Count];
        foreach (string key in clickEvent.Keys)
        {
            buttons[clickEvent[key]] = GameObject.Find(key).GetComponent<Button>();
        }
    }

    /// <summary>
    /// インスペクタ変更時のイベント
    /// </summary>
    private void OnValidate()
    {
        float lerpNum = 1.0f / (float)(clickEvent.Count - 1);
        foreach (string key in clickEvent.Keys)
        {
            GameObject.Find(key).GetComponent<Image>().color = Color.Lerp(FromButtonColor, ToButtonColor, lerpNum * (float)clickEvent[key]);
        }

        lerpNum = 1.0f / (float)(Global.Length - 1);
        for (float i = 0; i < Global.Length; i++)
        {
            GameObject.Find("Meter" + (i + 1).ToString()).GetComponentInChildren<Image>().color = Color.Lerp(FromButtonColor, ToButtonColor, lerpNum * i);
        }
    }

    /// <summary>
    /// 配列の並び替え時に呼ばれるイベント
    /// </summary>
    /// <param name="data">変更箇所データ</param>
    public void Changed(ChangedData data)
    {
        Counter.text = data.count.ToString();
        slider[data.fromIndex].value = data.fromValue;
        slider[data.toIndex].value = data.toValue;
    }

    /// <summary>
    /// ソート終了通知
    /// </summary>
    public void SortEnd()
    {
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = true;
    }

    /// <summary>
    /// 実行クリックイベント
    /// </summary>
    public void OnClickPlay()
    {
        if (sortController == null) return;

        for (int i = 0; i < buttons.Length; i++)
            buttons[i].interactable = false;

        Counter.text = "0";

        // 配列の初期化
        int[] Array = new int[Global.Length];
        for (int i = 0; i < Global.Length; i++)
        {
            Array[i] = i + 1;
        }

        // 配列をシャッフルする
        Array = Array.OrderBy(i => Guid.NewGuid()).ToArray();

        for (int i = 0; i < Global.Length; i++)
        {
            slider[i].value = Array[i];
        }

        sortController.Play(Array);
    }

    /// <summary>
    /// アクションの設定
    /// </summary>
    /// <param name="base"></param>
    public void SetAction(Base @base)
    {
        sortController = @base;
        sortName.text = @base.Name();
    }
}
