using System;
namespace Laba5
{
    public interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
