using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using System.Diagnostics;

namespace Herbarium.Class
{
    class DataProcess
    {

        public DataProcess()
        {
        }

        public DataTable GetPlantsView()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Kod");
            dt.Columns.Add("Familya");
            dt.Columns.Add("Cins");
            dt.Columns.Add("Tür");
            dt.Columns.Add("Sinonim");
            dt.Columns.Add("Kare");
            dt.Columns.Add("Türkçe İsim");
            dt.Columns.Add("Alt Tür");
            dt.Columns.Add("Varyete");
            dt.Columns.Add("Endemik");
            dt.Columns.Add("Tip Örneği");
            dt.Columns.Add("İl");
            dt.Columns.Add("İlçe");
            dt.Columns.Add("Lokalite");
            dt.Columns.Add("Habitat");
            dt.Columns.Add("Minimum");
            dt.Columns.Add("Maksimum");
            dt.Columns.Add("Tarih");
            dt.Columns.Add("Koordinatlar");
            dt.Columns.Add("Toplayıcı");
            dt.Columns.Add("Teşhis Eden"); 
            dt.Columns.Add("Açıklama");
            var entities = new herbariumEntities();
            var plants = entities.plant;
            foreach (plant plant in plants)
            {
                try
                {
                    synonym synonym;
                    species species;
                    habitat habitat = entities.habitat.Find(plant.habitat);
                    if (plant.issynonym ?? false)
                    {
                        synonym = entities.synonym.Find(plant.speciesid);
                        if (synonym is null) continue;
                        species = synonym.species;
                    }
                    else
                    {
                        synonym = null;
                        species = entities.species.Find(plant.speciesid);
                        if (species is null) continue;
                    }
                    DataRow row = dt.NewRow();
                    row["ID"] = plant.id;
                    row["Kod"] = plant.herbno;
                    row["Familya"] = species?.genus?.family?.name;
                    row["Cins"] = species?.genus?.name;
                    row["Tür"] = synonym is null ? species.name : synonym.name;
                    row["Sinonim"] = plant.issynonym ?? false ? "Evet" : "Hayır";
                    row["Kare"] = string.Join(",", plant.grid.ToList().Select(x => x.name));
                    row["Türkçe İsim"] = plant.localname;
                    row["Alt Tür"] = plant.subsp;
                    row["Varyete"] = plant.variety;
                    row["Endemik"] = plant.endemism ?? false ? "Evet" : "Hayır";
                    row["Tip Örneği"] = plant.typeexample;
                    row["İl"] = plant.district?.city.name;
                    row["İlçe"] = plant.district?.name;
                    row["Lokalite"] = plant.localite;
                    row["Habitat"] = habitat?.name;
                    row["Minimum"] = plant.minimum;
                    row["Maksimum"] = plant.maximum;
                    row["Tarih"] = plant.date is null? null : plant.date.Value.ToShortDateString();
                    //Class.BLL.Location location = new BLL.Location(plant.latitude is null || plant.longitude is null ? "" : plant.latitude.ToString().Replace(",",".") + ", " + plant.longitude.ToString().Replace(",", "."));
                    //row["Koordinatlar"] = plant.latitude is null || plant.longitude is null ? string.Empty : location.DegLatitude + ", " + location.DegLongitude;
                    row["Koordinatlar"] = plant.coordinates;
                    row["Toplayıcı"] = plant.collector;
                    row["Teşhis Eden"] = plant.diagnose;
                    row["Açıklama"] = plant.explanation;

                    dt.Rows.Add(row);
                }
                catch(Exception ex)
                {
                    Log.Error("[Bitki Listeleme Hatası]: ID:" + plant.id, ex);
                }
            }
            return dt;
            //return GetDataTableFromList(new herbariumEntities().v_plants.ToList());
        }
        public DataTable GetLogsView()
        {
            herbariumEntities entities = new herbariumEntities();
            var q = entities.log.Select(x => new { ID = x.id, Tip = x.type, Log = x.logtext, Tarih = x.datetime, Kullanıcı = x.user.name }).OrderByDescending(x => x.ID);
           
            return GetDataTableFromList(q.ToList());
        }

        public DataTable GetDataTableFromList<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
        TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name.Replace("_"," "));
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        
    }
}
