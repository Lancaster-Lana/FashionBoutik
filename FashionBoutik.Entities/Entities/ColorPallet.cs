
using System.Drawing;

namespace FashionBoutik.Entities
{
    public class ColorPallet : BaseEntity<int>
    {
        //TODO: enum
        /// <summary>
        /// Color.ToArgb()
        /// </summary>
        public int ColorValue { get; set; }

        public int FromColor { get; set; }

        public int ToColor { get; set; }

        //public Image Image { get; set; }
    }
}