using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public static class ScriptableObjectArchitectureUtility
    {
        internal static readonly List<IResetValues> resetValues = new();

        public static void ResetValues()
        {
            var count = resetValues.Count;
            for (int i = 0; i < count; i++)
            {
                resetValues[i].ResetValues();
            }
        }

        public static void Add(IResetValues resetValue)
        {
            resetValues.Add(resetValue);
        }
        public static void Remove(IResetValues resetValue)
        {
            resetValues.Remove(resetValue);
        }
    }
}
