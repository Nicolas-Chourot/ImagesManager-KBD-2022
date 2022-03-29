using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImagesManager.Models
{
    public static class DAL
    {
        public static Image Add_Image(this ImagesDBEntities DB, Image image)
        {
            image.CreationDate = DateTime.Now;
            image.Save();
            image = DB.Images.Add(image);
            DB.SaveChanges();
            return image;
        }

        public static bool Update_Image(this ImagesDBEntities DB, Image image)
        {
            image.Save();
            DB.Entry(image).State = EntityState.Modified;
            DB.SaveChanges();
            return true;
        }

        public static bool Remove_Image(this ImagesDBEntities DB, int imageId)
        {
            Image imageToDelete = DB.Images.Find(imageId);
            if (imageToDelete != null)
            {
                imageToDelete.Remove();
                DB.Images.Remove(imageToDelete);
                DB.SaveChanges();
                return true;
            }
            return false;
        }
    }
}