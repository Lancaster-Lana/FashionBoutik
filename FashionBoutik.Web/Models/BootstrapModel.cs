using FashionBoutik.Web.Code;

namespace FashionBoutik.Models
{
    public class BootstrapModel
    {
        public string ID { get; set; }
        public string AreaLabeledId { get; set; }

        /// <summary>
        /// Default size is medium
        /// </summary>
        public ModalSize Size { get; set; } = ModalSize.Medium;
        public string Message { get; set; }
        public string ModalSizeClass
        {
            get
            {
                switch (this.Size)
                {
                    case ModalSize.Small:
                        return "modal-sm";
                    case ModalSize.Large:
                        return "modal-lg";
                    case ModalSize.Medium:
                    default:
                        return "modal-md";
                }
            }
        }


    }
}