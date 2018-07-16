using System;

namespace FashionBoutik.Models {

    public class ColorModel {

        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Gradation
        /// </summary>
        public string ColorValue { get; set; }

        public string Status { get; set; }
    }
}