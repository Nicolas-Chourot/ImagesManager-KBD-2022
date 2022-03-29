using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImagesManager.Models
{
    [MetadataType(typeof(ImageView))]
    public partial class Image
    {
        public Image ()
        {
            Rating = 1;
        }
        public string Data { get; set; }
        private static ImagesDAL.GUIDReference ImageReference =
            new ImagesDAL.GUIDReference(@"/ImagesData/", @"No_image.png", true);

        public string GetUrl(bool thumbnail = false)
        {
            return ImageReference.GetURL(GUID, thumbnail);
        }

        public void Save()
        {
            GUID = ImageReference.SaveImage(Data, GUID);
        }

        public void Remove()
        {
            ImageReference.Remove(GUID);
        }
    }


    public class ImageView
    {
        [Display(Name = "Titre"), Required(ErrorMessage = "Obligatoire")]
        public string Title { get; set; }

        [Display(Name = "Description"), Required(ErrorMessage = "Obligatoire")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string GUID { get; set; }

        [Display(Name = "Évaluation"), Range(1, 5, ErrorMessage = "Obligatoire")]
        public double Rating { get; set; }
    }
}