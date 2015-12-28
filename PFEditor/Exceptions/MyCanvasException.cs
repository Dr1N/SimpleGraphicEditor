using System;

namespace PFEditor
{
    /// <summary>
    /// Бросается при невозможности создать, инициализировать холст
    /// </summary>
    [Serializable]
    class MyCanvasException : Exception
    {
        public MyCanvasException(string message) : base(message) { }
    }
}
