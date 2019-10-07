using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メーターの制御
/// </summary>
public class MeterController : MonoBehaviour
{

    /// <summary>
    /// スライダーUI（メーター）
    /// </summary>
    [SerializeField] private Slider[] slider = new Slider[Global.Length];

    /// <summary>
    /// ソート名Text
    /// </summary>
    [SerializeField] private Text sortName;

    /// <summary>
    /// 配列
    /// </summary>
    [SerializeField] protected int[] Array;

    /// <summary>
    /// ソートクラス
    /// </summary>
    public Base sortController = null;

    /// <summary>
    /// 配置したボタンを格納
    /// </summary>
    public Button[] buttons = new Button[(int)UI_BUTTON.LENGTH];

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        // ボタンクリックイベントをアタッチする
        buttons[(int)UI_BUTTON.Play].onClick.AddListener(OnClickPlay);
        buttons[(int)UI_BUTTON.BubbleSort].onClick.AddListener(OnClickBubbleSort);

        buttons = null;
    }

    /// <summary>
    /// コンポーネントアタッチ時の実行処理（エディタ上のみ）
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

        // 配置したボタンを取得
        buttons[(int)UI_BUTTON.Play] = GameObject.Find(UI_BUTTON.Play.ToString()).GetComponent<Button>();
        buttons[(int)UI_BUTTON.BubbleSort] = GameObject.Find(UI_BUTTON.BubbleSort.ToString()).GetComponent<Button>();
        
    }

    /// <summary>
    /// 配列の並び替え時に呼ばれるイベント
    /// </summary>
    /// <param name="data">変更箇所データ</param>
    public void Changed(ChangedData data)
    {
        slider[data.fromIndex].value = data.fromValue;
        slider[data.toIndex].value = data.toValue;
    }

    /// <summary>
    /// 実行クリックイベント
    /// </summary>
    public void OnClickPlay()
    {
        if (sortController == null) return;

        // 配列の初期化
        Array = new int[Global.Length];
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
    /// バブルソート選択イベント
    /// </summary>
    public void OnClickBubbleSort()
    {
        sortName.text = "Bubble Sort";
        sortController = new BubbleSort(Changed);
    }
}
