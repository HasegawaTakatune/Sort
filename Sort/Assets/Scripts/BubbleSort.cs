using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// バブルソート
/// </summary>
public class BubbleSort : Base
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delegate">登録するイベント</param>
    public BubbleSort(Delegate @delegate) : base(@delegate)
    {

    }

    /// <summary>
    /// 実行
    /// </summary>
    /// <param name="values">配列</param>
    public override void Play(int[] values)
    {
        base.Play(values);

        Sort();
    }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        for (int i = 0; i < Global.Length - 1; i++)
            for (int j = Global.Length - 1; j >= i + 1; j--)
            {
                await Task.Delay(waitTime);
                if (Array[j] < Array[j - 1])
                {
                    int tmp = Array[j];
                    Array[j] = Array[j - 1];
                    Array[j - 1] = tmp;

                    Changed?.Invoke(new ChangedData(j, Array[j], j - 1, Array[j - 1]));
                }
            }
    }
}
