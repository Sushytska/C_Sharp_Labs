using System;
namespace Laba2
{
    public interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
