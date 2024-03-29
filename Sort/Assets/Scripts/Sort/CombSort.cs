﻿using System.Threading.Tasks;

/// <summary>
/// コムソート
/// </summary>
public class CombSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "ComSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public CombSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new CombSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        int next = 0, interval = (int)(Global.Length / 1.3f);
        bool isEnd = false;

        while (!isEnd)
        {
            isEnd = true;
            for (int i = 0; i <= Global.Length - interval - 1; i++)
            {
                next = i + interval;
                if (Array[i] < Array[next])
                {
                    await Task.Delay(Global.WaitTime);
                    Swap(i, next);
                    isEnd = false;
                }
            }
            interval = (int)(interval / 1.3f);
            interval = interval <= 0 ? 1 : interval;
        }
        SortEnd?.Invoke();
    }
}
