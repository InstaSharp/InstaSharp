namespace System
{
    internal class SerializableAttribute : Attribute
    {
    }
}

namespace System.Runtime.InteropServices
{
    [AttributeUsageAttribute(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    internal class ComVisibleAttribute : Attribute
    {
        public ComVisibleAttribute(bool visible)
        {

        }
    }

    [AttributeUsageAttribute(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    internal sealed class GuidAttribute : Attribute
    {
        public GuidAttribute(string guid)
        {
            
        }
    }
}
