/// <summary>
/// インターフェイス
/// </summary>
public interface Interface
{
    void Sort();
}

/// <summary>
/// 配列を並び替えた時のデータを格納する構造体
/// </summary>
public struct ChangedData
{
    public int fromIndex;
    public float fromValue;
    public int toIndex;
    public float toValue;
    public int count;

    public ChangedData(int fromIndex, int fromValue, int toIndex, int toValue, int count) : this()
    {
        this.fromIndex = fromIndex;
        this.fromValue = fromValue;
        this.toIndex = toIndex;
        this.toValue = toValue;
        this.count = count;
    }
}

/// <summary>
/// 共通変数
/// </summary>
public static class Global
{

    /// <summary>
    /// 配列の長さ
    /// </summary>
    public const int Length = 20;

    /// <summary>
    /// 待ち時間
    /// </summary>
    public const int WaitTime = 100;
}
