using System.Threading.Tasks;
/// <summary>
/// マージソート
/// </summary>
public class MergeSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "MergeSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public MergeSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new MergeSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public async override void Sort()
    {
        int[] temp = new int[Array.Length];
        await Sort(Array, temp, 0, Array.Length - 1);

        SortEnd?.Invoke();
    }

    /// <summary>
    /// ソート
    /// </summary>
    /// <param name="array"></param>
    /// <param name="temp"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    async Task Sort(int[] array, int[] temp, int left, int right)
    {
        int mid;

        if (right > left)
        {
            // 配列を分割してソートをかける
            mid = (right + left) / 2;
            await Sort(array, temp, left, mid);
            await Sort(array, temp, mid + 1, right);

            await Merge(array, temp, left, mid + 1, right);
        }
    }

    /// <summary>
    /// マージ
    /// </summary>
    /// <param name="array"></param>
    /// <param name="temp"></param>
    /// <param name="left"></param>
    /// <param name="mid"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    async Task Merge(int[] array, int[] temp, int left, int mid, int right)
    {
        int  left_end, num_elements, tmp_pos;

        left_end = mid - 1;
        tmp_pos = left;
        num_elements = right - left + 1; /* 配列の要素数 */

        /* 2つのリストに要素が残っている */
        while ((left <= left_end) && (mid <= right))
        {
            if (array[left] <= array[mid])
            {
                temp[tmp_pos] = array[left];
                tmp_pos = tmp_pos + 1;
                left = left + 1;
            }
            else
            {
                temp[tmp_pos] = array[mid];
                tmp_pos = tmp_pos + 1;
                mid = mid + 1;
            }
        }

        /* 左側のリスト */
        while (left <= left_end)
        {
            temp[tmp_pos] = array[left];
            left = left + 1;
            tmp_pos = tmp_pos + 1;
        }
        /* 右側のリスト */
        while (mid <= right)
        {
            temp[tmp_pos] = array[mid];
            mid = mid + 1;
            tmp_pos = tmp_pos + 1;
        }

        /* 昇順に整列するようひとつのリストにまとめる */
        for (int i = 0; i <= num_elements; i++)
        {
            await Task.Delay(Global.WaitTime);
            Change(right, temp[right]);
            right = right - 1;
            if (right < 0) break;
        }
    }
}
