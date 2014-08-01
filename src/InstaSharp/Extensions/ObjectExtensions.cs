namespace InstaSharp.Extensions
{
    public static class ObjectExtensions
    {
        public static T To<T>(this object o)
        { 
            return (T)o;
        }
    }
}
