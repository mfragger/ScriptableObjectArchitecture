using System.Collections.Generic;

namespace ScriptableObjectArchitecture
{
    public static class SOArchitectureUtility
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

        internal static void Add(IResetValues resetValue)
        {
            resetValues.Add(resetValue);
        }
        internal static void Remove(IResetValues resetValue)
        {
            resetValues.Remove(resetValue);
        }
    }
}
