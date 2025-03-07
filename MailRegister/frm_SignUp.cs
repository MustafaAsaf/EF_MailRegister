using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailRegister.Models;
using MailRegister.Properties;
using MailKit;
using MimeKit;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using MailKit.Security;

namespace MailRegister
{
    public partial class frm_SignUp: Form
    {
        public frm_SignUp()
        {
            InitializeComponent();
        }

        private DbMailRegisterEntities1 context = new DbMailRegisterEntities1();
        Random random = new Random();
        

        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            KayıtOlustur();
        
        }

        public void KayıtOlustur()
        {
            try
            {
                int confirmCode = random.Next(100000, 1000000);

                TblUser user = new TblUser();
                user.UserEmail = txt_Email.Text;
                user.UserName = txt_Name.Text;
                user.UserPassword = txt_Password.Text;
                user.UserSurname = txt_LastName.Text;
                user.UserIsConfirm = false;
                user.UserConfirmCode = confirmCode.ToString();

                DialogResult result = MessageBox.Show("Kaydetmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (txt_Password.Text != txt_PasswordAgain.Text)
                    {
                        MessageBox.Show("Parola Alanları Aynı Değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        context.TblUser.Add(user);
                        context.SaveChanges();
                        MailMessage(confirmCode);
                        ClearForm();
                        MessageBox.Show("Kaydedildi!");
                        frm_MailConfirm frmMailConfirm = new frm_MailConfirm();
                        frmMailConfirm.email = txt_Email.Text;
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("İşlem iptal edildi.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public void ClearForm()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }

        public void MailMessage(int confirmCode)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("AdminRegister", "MAİL GÖNDERECEK MAİL ADRESİ");
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", txt_Email.Text);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo); // HATA DÜZELTİLDİ

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Email Adresinizin Konfirmasyon Kodu: " + confirmCode;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Email Konfirmasyon Kodu";

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls); // TLS EKLENDİ
                smtpClient.Authenticate("MAİL GÖNDERECEK MAİL ADRESİ", "GOOGLE HESAP/UYGULAMA ŞİFRELERİ ÜZERİNDEN ALINAN ŞİFRE"); //googledan alınan şifrede arada boşluklar olmayacak
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }

            MessageBox.Show("Mail Adresinize Doğrulama Kodu Gönderilmiştir.");
            frm_MailConfirm frmMailConfirm = new frm_MailConfirm();
            frmMailConfirm.Show();
            
        }

    }
}
