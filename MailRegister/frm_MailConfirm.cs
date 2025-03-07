using MailRegister.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailRegister
{
    public partial class frm_MailConfirm: Form
    {
        public frm_MailConfirm()
        {
            InitializeComponent();
        }
        private DbMailRegisterEntities1 context = new DbMailRegisterEntities1();
        public string email;
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            var value = context.TblUser.Where(x => x.UserEmail==txt_Email.Text).Select(y=>y.UserConfirmCode).FirstOrDefault();

            if (txt_Code.Text==value.ToString())
            {
                var value2 = context.TblUser.Where(x => x.UserEmail == txt_Email.Text).FirstOrDefault();
                value2.UserIsConfirm = true;
                context.SaveChanges();
                MessageBox.Show("Hesabınız Aktif Edildi");

            }
            else
            {
                MessageBox.Show("Hatalı Kod");
            }
        }

        private void frm_MailConfirm_Load(object sender, EventArgs e)
        {
            txt_Email.Text = email;
        }
    }
}
