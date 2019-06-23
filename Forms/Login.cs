using EasyTabs;
using Herbarium.Class;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Herbarium.Forms
{
    public partial class Login : Form
    {
        public static Container tabbedApp = new Container();
        public static TitleBarTabsApplicationContext ApplicationContext;

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            KullaniciAdlariniDoldur();
        }
        herbariumEntities entities = new herbariumEntities();
        private void KullaniciAdlariniDoldur()
        {
            try
            {
                DataTable dt = new DataProcess().GetDataTableFromList(entities.user.ToList());
    
                cboxKadi.DataSource = entities.user.ToList();
                cboxKadi.DisplayMember = "name";
                cboxKadi.ValueMember = "id";
                cboxKadi.Invalidate();
                if (cboxKadi.Items.Count > 0)
                {
                 //   int varsayilanId = Convert.ToInt32(Settings.Default.VarsayilanKullanici);
                    int varsayilanId = 1;
                    if (varsayilanId != 1) cboxKadi.SelectedValue = varsayilanId;

                    if (cboxKadi.SelectedValue == null || varsayilanId == 1) cboxKadi.SelectedItem = cboxKadi.Items[0];
                }
            }
            catch (Exception ex)
            {
                ShowMessage.Error("Lütfen tekrar deneyin. Eğer sorununuz devam ediyorsa sistem yöneticisine başvurmayı deneyin.\n\nAyrıca http://www.kodvizit.com adresinden de destek alabilirsiniz.\n\n" + ex.Message.ToString());
                Log.Error("[Veri Çekme Hatası] Kullanıcı isimleri doldurulamadı", ex);
            }
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
#if DEBUG
            DoLogin();
#endif
#if !DEBUG
            try
            {
                DoLogin();
            }
            catch (Exception exception)
            {
                ShowMessage.Error("Giriş yapılamadı\n" + exception.Message);
                Log.Error("[Giriş Hatası] Giriş sırasında hata oluştu", exception);
            }
#endif
        }



        private void DoLogin()
        {
            if (!(cboxKadi.SelectedItem is user)) return;
            user user = (user)cboxKadi.SelectedItem;
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı");

            var sifre = user.password;
            if (sifre != txtSifre.Text)
            {
                ShowMessage.Warning("Şifre yanlış.");
                Log.Warning("[Yanlış Şifre]: " +  user.name, $"{user.name} isimli kullanıcı {DateTime.Now.ToString()} tarihinde yanlış şifre ile giriş yapmaya çalıştı.");

                return;
            }
            user.lastlogin = DateTime.Now;
            new UserBLL().Guncelle(user);
            UserBLL.ActiveUser = user;

            MainForm ana = new MainForm
            {
                Text = "Yönetim Paneli"
            };
            tabbedApp.Tabs.Add(new TitleBarTab(tabbedApp)
            {
                Content = ana,
                ShowCloseButton = false
            });
            tabbedApp.SelectedTabIndex = 0;
            Forms.Container.MainForm = ana; 

            ApplicationContext = new TitleBarTabsApplicationContext();
            ApplicationContext.Start(tabbedApp);
           
            this.Hide();
            //ana.Show();
            txtSifre.Text = string.Empty;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kapat();
        }
        public static void Kapat()
        {
            Environment.Exit(0);
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Info().Show();
        }

    }
}
