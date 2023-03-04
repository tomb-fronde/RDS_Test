using System;

namespace NZPostOffice.Shared.LogicUnits
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MapInfoIndex : Attribute
    {
        public MapInfoIndex(string[] index)
        {
            this.index = index;
        }

        public string[] GetIndex()
        {
            return index;
        }

        private string[] index;
    }
}
