using System.Threading.Tasks;

/// <summary>
/// 選択ソート
/// </summary>
public class SelectionSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "SelectionSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public SelectionSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得インスタンス取得」
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new SelectionSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        int max = 0, selected = 0;
        bool isChange = false;

        for (int i = 0; i < Global.Length - 1; i++)
        {
            isChange = false;
            max = Array[i];
            selected = i;

            for (int j = i; j < Global.Length; j++)
            {
                if (max < Array[j])
                {
                    max = Array[j];
                    selected = j;
                    isChange = true;
                }
            }
            if (isChange)
            {
                await Task.Delay(Global.WaitTime);
                Swap(i, selected);
            }
        }
        SortEnd?.Invoke();
    }
}
