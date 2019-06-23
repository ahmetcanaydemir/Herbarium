using Herbarium.Class.BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herbarium.Class.BIL
{
    class PlantBLL
    {
        public herbariumEntities entities = new herbariumEntities();
        public Location Location;
        public bool AddPlant(plant plant)
        {
            try
            {
                if (plant.speciesid == null)
                    return false;
                entities.plant.Add(plant);
                entities.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdatePlant(plant plant)
        {
            try
            {

                var entity = entities.plant.Find(plant.id);
                //entity.grid.Clear();
                //foreach (var childModel in plant.grid)
                //{
                //    var existingChild = entities.plant.Find(childModel.id);

                //    entity.grid.Add(childModel);
                //    entities.Attach(entity);
                //}  
                //   entities.Entry(entity.grid).CurrentValues.SetValues(plant.grid);
                
                entities.Entry(entity).CurrentValues.SetValues(plant);
                //entity.grid = plant.grid;

                // entity = entities.plant.Find(plant.id);
                //UpdateGrid(entity);
                entities.SaveChanges();


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public grid findGrid(string gridName)
        {
            return entities.grid.FirstOrDefault(x=>x.name==gridName);
        }
        public void UpdateGrid(plant plant)
        {
            var entity = entities.plant.Find(plant.id);

            if (entity != null)
            {
                // Update and Insert children

              

                entities.Entry(entity).CurrentValues.SetValues(plant);
            }
        }
        public int getHabitatId(string text)
        {
            var hbt = entities.habitat.FirstOrDefault(x => x.name == text);
            if (hbt != null)
            {
                return hbt.id;
            }
            habitat h = new habitat();
            h.name = text;
            entities.habitat.Add(h);
            entities.SaveChanges();
            return h.id;
        }
        
        
        public void openImage(Image image)
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "herbarium-view-image.jpg");

            image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

            System.Diagnostics.Process.Start(path);
        }
        public Image getPhoto(plant plant)
        {
            if (plant.photo == null || plant.photo.Length == 4)
                return null;

            return Image.FromStream(new System.IO.MemoryStream(plant.photo));
        }
    }
}
