using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herbarium.Class
{
    class UserBLL
    {
        public static user ActiveUser;
        herbariumEntities entities = new herbariumEntities();
        public readonly List<user_auths> YetkiListesi;

        public UserBLL ()
        {
            YetkiListesi = entities.user_auths.ToList();
        }
        public System.Data.DataTable GetUserList()
        {
            var list = (from u in entities.user
             select new { ID= u.id, Kullanici_Adi = u.name,Tarih = u.date, Son_Giris= u.lastlogin }).ToList();
             return new DataProcess().GetDataTableFromList(list); 

            // return new DataProcess().GetDataTableFromList(entities.user.Select.ToList()); 
        }

        public static bool YekisiYok(string yetki)
        {
            bool yetkisiYokMu = ActiveUser.user_auths.FirstOrDefault(x => x.name == yetki) == null;

            if (yetkisiYokMu)
                ShowMessage.Error("Bu alana erişebilmek için " + yetki +" yetkisine sahip olmanız gerekiyor!");
            return yetkisiYokMu;
        }

        public user_auths findAuth(int authId)
        {
            return entities.user_auths.Find(authId);
        }
        public user findUser(int id)
        {
            return entities.user.Find(id);
        }

        public void Sil(user user)
        {
            entities.user.Remove(user);
            entities.SaveChanges();
        }

        public void Guncelle(user user)
        {
            var entity = entities.user.Find(user.id);
            entities.Entry(entity).CurrentValues.SetValues(user);
            entities.SaveChanges();
        }

        public void Ekle(user user)
        {
            user.date = DateTime.Now;
            entities.user.Add(user);
            entities.SaveChanges();
        }

        
    }
}
