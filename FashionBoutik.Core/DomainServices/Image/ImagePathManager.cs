using System;

namespace FashionBoutik.DomainServices
{
    public class ImagePathManager : DomainService, IImagePathManager {

        public string GetImageUrl(int id, string img) {

            string baseUrl = "https://todo/images";

            if (!string.IsNullOrEmpty(img)) {
                return $"{baseUrl}/{id}/{img}";
            }
            return $"{baseUrl}/missing.png";
        }

        public string GetImageUrl(int id, string name, string type)
        {
            return this.GetImageUrl(id, name);
        }
    }
}