namespace ScriptableObjectArchitecture
{
    public interface ICallback<T>
    {
        void SetCallback(T @interface);
        void UnsetCallback(T @interface);
    }
}
