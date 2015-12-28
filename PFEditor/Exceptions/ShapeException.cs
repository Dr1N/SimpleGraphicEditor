using System;

namespace PFEditor
{
    /// <summary>
    /// Ислючение бросется объектами фигур при попытке вызвать метод Draw, при неверных параметрах
    /// </summary>
    [Serializable]
    class ShapeException : Exception
    {
        public ShapeException(string message) : base(message) { }
    }
}
