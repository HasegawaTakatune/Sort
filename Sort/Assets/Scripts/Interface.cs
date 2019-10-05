/// <summary>
/// インターフェイス
/// </summary>
public interface Interface
{
    void Sort();

}

public struct ChangedData { public int fromIndex; public float fromValue; public int toIndex; public float toValue;

    public ChangedData(int fromIndex, int fromValue, int toIndex, int toValue) : this()
    {
        this.fromIndex = fromIndex;
        this.fromValue = fromValue;
        this.toIndex = toIndex;
        this.toValue = toValue;
    }
}

public static class Global
{
    public const int Length = 10;

}