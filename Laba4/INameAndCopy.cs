using System;
namespace Laba4
{
    public interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }
}
