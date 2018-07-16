using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FashionBoutik.Web.Utils
{
    public static class HtmlHelper
    {
        /// <summary>
        /// @Html.Image(Model.ImgBytes)
        /// </summary>
        /// <param name="html"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        /*public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            return new MvcHtmlString("<img src='" + img + "' />");
        }*/

        //public static IHtmlString GetBytes<TModel, TValue>(this HtmlHelper<TModel> helper, System.Linq.Expressions.Expression<Func<TModel, TValue>> expression, byte[] array, string Id)
        //{
        //    TagBuilder tb = new TagBuilder("img");
        //    tb.MergeAttribute("id", Id);
        //    var base64 = Convert.ToBase64String(array);
        //    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
        //    tb.MergeAttribute("src", imgSrc);
        //    return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        //}

        //public static byte[] ImageToByteArray(Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    return ms.ToArray();
        //}
        //public static Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    using (MemoryStream ms = new MemoryStream(byteArrayIn))
        //    {
        //        Image returnImage = Image.FromStream(ms);
        //        return returnImage;
        //    }
        //}

        public static string GetImageSource(byte[] imageBytes)
        {
            string mimeType = System.Net.Mime.MediaTypeNames.Image.Gif;
            string base64 = Convert.ToBase64String(imageBytes);
            return string.Format("data:{0};base64,{1}", mimeType, base64);
        }
    }
}
