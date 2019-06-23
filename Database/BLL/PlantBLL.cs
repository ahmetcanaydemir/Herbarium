using Herbarium.Class.BLL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herbarium
{
    class PlantBLL : IBusinessLayer<plant,int>
    {
        public Location Location;
        ConnectionFactory connection;
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
                entities.Entry(entity).CurrentValues.SetValues(plant);
                entities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
            return h.id;
        }
        
        public void addGrids(plant plant,string text)
        {
            plant.grid.Clear();
            foreach (var item in text.Split(','))
            {
                var grd = entities.grid.FirstOrDefault(x => x.name == item);
                if (grd != null)
                {
                    plant.grid.Add(grd);
                }
            }
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

        public List<plant> GetAll()
        {
            try
            {
                connection.Open();
                List<plant> list = connection.getSqlConnection().Query<plant>("SELECT * FROM [dbo].[plant]").AsList();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAll error in PlantBLL",ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Save(plant item)
        {
            throw new NotImplementedException();
        }

        public bool Update(plant item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(plant item)
        {
            throw new NotImplementedException();
        }
    }
}
