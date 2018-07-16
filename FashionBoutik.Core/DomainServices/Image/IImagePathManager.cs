
using System;

namespace FashionBoutik.DomainServices
{

    public interface IImagePathManager
    {
        // Used for web access: https://host/container/path/name.ext
        string GetImageUrl(int id, string name);

        // Used for web access: https://host/container/path/name.ext
        string GetImageUrl(int id, string name, string type);
    }
}